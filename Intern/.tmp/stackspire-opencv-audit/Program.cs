using System.Globalization;
using System.Text;
using OpenCvSharp;

record AssetAudit(
    string Path,
    int Width,
    int Height,
    bool HasAlpha,
    int ForegroundPixels,
    double ForegroundRatio,
    int BBoxX,
    int BBoxY,
    int BBoxW,
    int BBoxH,
    int PadL,
    int PadT,
    int PadR,
    int PadB,
    bool EdgeTouch,
    int Components,
    int LargeComponents,
    int TinyFragments,
    int EdgeComponents,
    int LowAlphaResidue,
    int VisibleGreenResidue,
    string Flags
);

static class Program
{
    static int Main(string[] args)
    {
        var root = args.Length > 0 ? Path.GetFullPath(args[0]) : Directory.GetCurrentDirectory();
        var outDir = args.Length > 1 ? Path.GetFullPath(args[1]) : Path.Combine(root, ".tmp", "opencv-asset-audit-output");
        Directory.CreateDirectory(outDir);

        var assetRoot = Path.Combine(root, "Assets", "Generated", "MVP");
        var files = Directory.GetFiles(assetRoot, "*.png", SearchOption.AllDirectories)
            .Where(p => !p.Contains($"{Path.DirectorySeparatorChar}_source_atlases{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
            .OrderBy(p => p, StringComparer.OrdinalIgnoreCase)
            .ToList();

        var audits = new List<AssetAudit>();
        foreach (var file in files)
        {
            using var img = Cv2.ImRead(file, ImreadModes.Unchanged);
            if (img.Empty()) continue;
            var rel = Path.GetRelativePath(root, file).Replace('\\', '/');
            audits.Add(AuditOne(rel, img));
        }

        WriteTsv(Path.Combine(outDir, "atlas_asset_audit.tsv"), audits);
        WriteContactSheet(Path.Combine(outDir, "atlas_asset_contact_all.png"), root, audits, 5, 220, false);
        WriteContactSheet(Path.Combine(outDir, "atlas_asset_contact_flagged.png"), root, audits.Where(a => a.Flags.Length > 0).ToList(), 4, 260, true);
        WriteSummary(Path.Combine(outDir, "atlas_asset_audit_summary.txt"), audits);

        Console.WriteLine($"Audited {audits.Count} active atlas-derived PNGs.");
        Console.WriteLine($"Flagged {audits.Count(a => a.Flags.Length > 0)} candidates.");
        Console.WriteLine(Path.Combine(outDir, "atlas_asset_audit.tsv"));
        Console.WriteLine(Path.Combine(outDir, "atlas_asset_contact_flagged.png"));
        return 0;
    }

    static AssetAudit AuditOne(string rel, Mat img)
    {
        var hasAlpha = img.Channels() == 4;
        Mat alpha;
        if (hasAlpha)
        {
            alpha = new Mat();
            Cv2.ExtractChannel(img, alpha, 3);
        }
        else
        {
            alpha = new Mat(img.Rows, img.Cols, MatType.CV_8UC1, Scalar.All(255));
        }

        using var strong = new Mat();
        Cv2.Threshold(alpha, strong, 8, 255, ThresholdTypes.Binary);
        using var low = new Mat();
        Cv2.InRange(alpha, new Scalar(1), new Scalar(7), low);

        var foreground = Cv2.CountNonZero(strong);
        var ratio = foreground / (double)(img.Rows * img.Cols);

        var bbox = new Rect(0, 0, 0, 0);
        using var points = new Mat();
        Cv2.FindNonZero(strong, points);
        if (!points.Empty())
            bbox = Cv2.BoundingRect(points);

        var padL = bbox.X;
        var padT = bbox.Y;
        var padR = img.Cols - (bbox.X + bbox.Width);
        var padB = img.Rows - (bbox.Y + bbox.Height);
        var edgeTouch = foreground > 0 && (padL == 0 || padT == 0 || padR == 0 || padB == 0);

        using var labels = new Mat();
        using var stats = new Mat();
        using var cents = new Mat();
        var componentCount = foreground > 0 ? Cv2.ConnectedComponentsWithStats(strong, labels, stats, cents, PixelConnectivity.Connectivity8) - 1 : 0;

        var largeComponents = 0;
        var tinyFragments = 0;
        var edgeComponents = 0;
        var total = Math.Max(foreground, 1);
        for (var i = 1; i <= componentCount; i++)
        {
            var x = stats.Get<int>(i, (int)ConnectedComponentsTypes.Left);
            var y = stats.Get<int>(i, (int)ConnectedComponentsTypes.Top);
            var w = stats.Get<int>(i, (int)ConnectedComponentsTypes.Width);
            var h = stats.Get<int>(i, (int)ConnectedComponentsTypes.Height);
            var area = stats.Get<int>(i, (int)ConnectedComponentsTypes.Area);
            var frac = area / (double)total;
            if (frac >= 0.04) largeComponents++;
            if (area <= 10 || frac < 0.002) tinyFragments++;
            if (x == 0 || y == 0 || x + w >= img.Cols || y + h >= img.Rows) edgeComponents++;
        }

        var lowAlphaResidue = Cv2.CountNonZero(low);
        var visibleGreenResidue = CountVisibleGreenResidue(img, hasAlpha);
        var flags = BuildFlags(rel, hasAlpha, ratio, edgeTouch, largeComponents, tinyFragments, edgeComponents, lowAlphaResidue, visibleGreenResidue, img.Cols, img.Rows);

        alpha.Dispose();
        return new AssetAudit(rel, img.Cols, img.Rows, hasAlpha, foreground, ratio, bbox.X, bbox.Y, bbox.Width, bbox.Height,
            padL, padT, padR, padB, edgeTouch, componentCount, largeComponents, tinyFragments, edgeComponents, lowAlphaResidue, visibleGreenResidue, flags);
    }

    static string BuildFlags(string rel, bool hasAlpha, double ratio, bool edgeTouch, int largeComponents, int tinyFragments,
        int edgeComponents, int lowAlphaResidue, int visibleGreenResidue, int width, int height)
    {
        var flags = new List<string>();
        var isSheet = rel.Contains("_sheet.", StringComparison.OrdinalIgnoreCase);
        var isFullCanvasAllowed = rel.Contains("/world/rooms/world_floor_tile", StringComparison.OrdinalIgnoreCase);
        var isDoorOrProp = rel.Contains("/world/", StringComparison.OrdinalIgnoreCase);

        if (!hasAlpha && !isFullCanvasAllowed) flags.Add("no_alpha");
        if (edgeTouch && !isFullCanvasAllowed) flags.Add("edge_touch_possible_cutoff");
        if (!isSheet && largeComponents >= 3 && !isDoorOrProp) flags.Add("multiple_large_components");
        if (tinyFragments >= 12) flags.Add("many_tiny_fragments");
        if (edgeComponents > 0 && !isFullCanvasAllowed) flags.Add("component_on_edge");
        if (lowAlphaResidue > Math.Max(20, width * height / 5000)) flags.Add("low_alpha_residue");
        if (visibleGreenResidue > 0) flags.Add("visible_chroma_green_residue");
        if (ratio < 0.005) flags.Add("very_sparse_or_empty");
        if (ratio > 0.92 && !isFullCanvasAllowed) flags.Add("mostly_opaque_background");

        return string.Join(",", flags.Distinct());
    }

    static int CountVisibleGreenResidue(Mat img, bool hasAlpha)
    {
        using var bgr = new Mat();
        if (img.Channels() == 4) Cv2.CvtColor(img, bgr, ColorConversionCodes.BGRA2BGR);
        else if (img.Channels() == 3) img.CopyTo(bgr);
        else Cv2.CvtColor(img, bgr, ColorConversionCodes.GRAY2BGR);

        using var green = new Mat();
        Cv2.InRange(bgr, new Scalar(0, 220, 0), new Scalar(70, 255, 70), green);

        if (hasAlpha)
        {
            using var alpha = new Mat();
            Cv2.ExtractChannel(img, alpha, 3);
            using var visible = new Mat();
            Cv2.Threshold(alpha, visible, 8, 255, ThresholdTypes.Binary);
            using var both = new Mat();
            Cv2.BitwiseAnd(green, visible, both);
            return Cv2.CountNonZero(both);
        }
        return Cv2.CountNonZero(green);
    }

    static void WriteTsv(string path, IReadOnlyList<AssetAudit> audits)
    {
        var sb = new StringBuilder();
        sb.AppendLine("path\twidth\theight\thas_alpha\tfg_pixels\tfg_ratio\tbbox_x\tbbox_y\tbbox_w\tbbox_h\tpad_l\tpad_t\tpad_r\tpad_b\tedge_touch\tcomponents\tlarge_components\ttiny_fragments\tedge_components\tlow_alpha_residue\tvisible_green_residue\tflags");
        foreach (var a in audits)
        {
            sb.AppendLine(string.Join('\t',
                a.Path, a.Width, a.Height, a.HasAlpha, a.ForegroundPixels,
                a.ForegroundRatio.ToString("0.0000", CultureInfo.InvariantCulture),
                a.BBoxX, a.BBoxY, a.BBoxW, a.BBoxH, a.PadL, a.PadT, a.PadR, a.PadB,
                a.EdgeTouch, a.Components, a.LargeComponents, a.TinyFragments, a.EdgeComponents, a.LowAlphaResidue, a.VisibleGreenResidue, a.Flags));
        }
        File.WriteAllText(path, sb.ToString());
    }

    static void WriteSummary(string path, IReadOnlyList<AssetAudit> audits)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"Audited active atlas-derived PNGs: {audits.Count}");
        sb.AppendLine($"Flagged candidates: {audits.Count(a => a.Flags.Length > 0)}");
        foreach (var a in audits.Where(a => a.Flags.Length > 0))
            sb.AppendLine($"{a.Path} :: {a.Flags}");
        File.WriteAllText(path, sb.ToString());
    }

    static void WriteContactSheet(string path, string root, IReadOnlyList<AssetAudit> audits, int columns, int tile, bool flagged)
    {
        if (audits.Count == 0)
        {
            using var empty = new Mat(120, 640, MatType.CV_8UC3, Scalar.All(245));
            Cv2.PutText(empty, "No flagged assets", new Point(20, 70), HersheyFonts.HersheySimplex, 1, Scalar.Black, 2);
            Cv2.ImWrite(path, empty);
            return;
        }

        var labelH = flagged ? 76 : 62;
        var rows = (int)Math.Ceiling(audits.Count / (double)columns);
        using var sheet = new Mat(rows * (tile + labelH), columns * tile, MatType.CV_8UC3, new Scalar(235, 235, 235));

        for (var i = 0; i < audits.Count; i++)
        {
            var a = audits[i];
            using var src = Cv2.ImRead(Path.Combine(root, a.Path.Replace('/', Path.DirectorySeparatorChar)), ImreadModes.Unchanged);
            using var vis = CompositeOnChecker(src, tile, tile - 8);
            var x = (i % columns) * tile;
            var y = (i / columns) * (tile + labelH);
            vis.CopyTo(new Mat(sheet, new Rect(x, y, tile, tile - 8)));

            var color = a.Flags.Length > 0 ? new Scalar(0, 0, 210) : new Scalar(20, 90, 20);
            Cv2.Rectangle(sheet, new Rect(x + 1, y + 1, tile - 3, tile - 10), color, 2);
            Cv2.PutText(sheet, ShortName(a.Path), new Point(x + 4, y + tile + 10), HersheyFonts.HersheySimplex, 0.38, Scalar.Black, 1);
            Cv2.PutText(sheet, $"{a.Width}x{a.Height} c:{a.Components} lc:{a.LargeComponents}", new Point(x + 4, y + tile + 28), HersheyFonts.HersheySimplex, 0.35, Scalar.Black, 1);
            if (flagged)
                Cv2.PutText(sheet, a.Flags.Length > 42 ? a.Flags[..42] : a.Flags, new Point(x + 4, y + tile + 47), HersheyFonts.HersheySimplex, 0.32, color, 1);
        }
        Cv2.ImWrite(path, sheet);
    }

    static Mat CompositeOnChecker(Mat src, int targetW, int targetH)
    {
        using var bgr = new Mat();
        if (src.Channels() == 4)
        {
            using var alpha = new Mat();
            Cv2.ExtractChannel(src, alpha, 3);
            using var rgb = new Mat();
            Cv2.CvtColor(src, rgb, ColorConversionCodes.BGRA2BGR);
            bgr.Create(src.Rows, src.Cols, MatType.CV_8UC3);
            var checker = MakeChecker(src.Cols, src.Rows);
            rgb.CopyTo(bgr, alpha);
            using var inv = new Mat();
            Cv2.BitwiseNot(alpha, inv);
            checker.CopyTo(bgr, inv);
            checker.Dispose();
        }
        else if (src.Channels() == 3)
        {
            src.CopyTo(bgr);
        }
        else
        {
            Cv2.CvtColor(src, bgr, ColorConversionCodes.GRAY2BGR);
        }

        var scale = Math.Min(targetW / (double)bgr.Cols, targetH / (double)bgr.Rows);
        var w = Math.Max(1, (int)Math.Round(bgr.Cols * scale));
        var h = Math.Max(1, (int)Math.Round(bgr.Rows * scale));
        using var resized = new Mat();
        Cv2.Resize(bgr, resized, new Size(w, h), 0, 0, InterpolationFlags.Area);
        var canvas = new Mat(targetH, targetW, MatType.CV_8UC3, Scalar.All(250));
        var roi = new Rect((targetW - w) / 2, (targetH - h) / 2, w, h);
        resized.CopyTo(new Mat(canvas, roi));
        return canvas;
    }

    static Mat MakeChecker(int w, int h)
    {
        var checker = new Mat(h, w, MatType.CV_8UC3);
        const int s = 12;
        for (var y = 0; y < h; y += s)
        for (var x = 0; x < w; x += s)
        {
            var dark = ((x / s) + (y / s)) % 2 == 0;
            Cv2.Rectangle(checker, new Rect(x, y, Math.Min(s, w - x), Math.Min(s, h - y)),
                dark ? new Scalar(210, 210, 210) : new Scalar(245, 245, 245), -1);
        }
        return checker;
    }

    static string ShortName(string path)
    {
        var name = Path.GetFileName(path);
        return name.Length <= 34 ? name : name[..31] + "...";
    }
}
