using System.Text;
using OpenCvSharp;

record CutSpec(string Atlas, int Cols, int Rows, int Index, string OutRel, int Width, int Height, bool PreserveAspect = true);

static class Program
{
    static int Main(string[] args)
    {
        var root = args.Length > 0 ? Path.GetFullPath(args[0]) : Directory.GetCurrentDirectory();
        var outRoot = Path.Combine(root, "Assets", "Generated", "MVP");
        var atlasRoot = PickAtlasRoot(root);
        var reportDir = Path.Combine(root, ".tmp", "opencv-recutter-output");
        Directory.CreateDirectory(reportDir);

        var specs = BuildSpecs();
        var restored = new List<string>();
        var skippedExisting = new List<string>();
        var skippedMissingAtlas = new List<string>();
        var failed = new List<string>();

        foreach (var spec in specs)
        {
            var outPath = Path.Combine(outRoot, spec.OutRel.Replace('/', Path.DirectorySeparatorChar));
            if (File.Exists(outPath))
            {
                skippedExisting.Add(spec.OutRel);
                continue;
            }

            var atlasPath = Path.Combine(atlasRoot, spec.Atlas);
            if (!File.Exists(atlasPath))
            {
                skippedMissingAtlas.Add($"{spec.OutRel} <= {spec.Atlas}");
                continue;
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(outPath)!);
                using var atlas = Cv2.ImRead(atlasPath, ImreadModes.Color);
                using var cut = CutOne(atlas, spec);
                Cv2.ImWrite(outPath, cut);
                restored.Add(spec.OutRel);
            }
            catch (Exception ex)
            {
                failed.Add($"{spec.OutRel}: {ex.Message}");
            }
        }

        WriteReport(Path.Combine(reportDir, "recut_missing_assets_summary.txt"), atlasRoot, restored, skippedExisting, skippedMissingAtlas, failed);
        WriteContactSheet(Path.Combine(reportDir, "recut_missing_assets_contact.png"), root, restored);

        Console.WriteLine($"atlas_root={atlasRoot}");
        Console.WriteLine($"restored={restored.Count}");
        Console.WriteLine($"skipped_existing={skippedExisting.Count}");
        Console.WriteLine($"skipped_missing_atlas={skippedMissingAtlas.Count}");
        Console.WriteLine($"failed={failed.Count}");
        Console.WriteLine(Path.Combine(reportDir, "recut_missing_assets_summary.txt"));
        return failed.Count == 0 ? 0 : 1;
    }

    static string PickAtlasRoot(string root)
    {
        var preferred = Path.Combine(root, "Assets", "Generated", "MVP", "source_atlases");
        if (Directory.Exists(preferred)) return preferred;
        var actual = Path.Combine(root, "Assets", "Generated", "MVP", "_source_atlases");
        if (Directory.Exists(actual)) return actual;
        throw new DirectoryNotFoundException("No source_atlases or _source_atlases folder found under Assets/Generated/MVP.");
    }

    static List<CutSpec> BuildSpecs() => new()
    {
        // atlas_ui_icons.png is a 7x3 atlas. The previous 6x3 split caused cross-cell fragments.
        new("atlas_ui_icons.png", 7, 3, 0, "ui/icons/ui_icon_coin.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 1, "ui/icons/ui_icon_heart_full.png", 48, 48),
        new("atlas_ui_icons.png", 7, 3, 2, "ui/icons/ui_icon_heart_empty.png", 48, 48),
        new("atlas_ui_icons.png", 7, 3, 3, "ui/icons/ui_icon_heart_armor_pip.png", 48, 48),
        new("atlas_ui_icons.png", 7, 3, 4, "ui/icons/ui_icon_heart_damage_flash.png", 48, 48),
        new("atlas_ui_icons.png", 7, 3, 5, "ui/icons/ui_icon_pause.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 6, "ui/icons/ui_icon_settings.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 7, "ui/icons/ui_icon_back.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 7, "ui/icons/ui_icon_warrior_sword.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 8, "ui/icons/ui_icon_archer_bow.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 9, "ui/icons/ui_icon_mage_staff.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 10, "ui/icons/ui_icon_upgrade_toughness.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 11, "ui/icons/ui_icon_upgrade_power.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 12, "ui/icons/ui_icon_upgrade_agility.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 13, "ui/icons/ui_icon_upgrade_greed.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 14, "ui/icons/ui_icon_upgrade_warrior_special.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 15, "ui/icons/ui_icon_upgrade_archer_special.png", 64, 64),
        new("atlas_ui_icons.png", 7, 3, 16, "ui/icons/ui_icon_upgrade_mage_special.png", 64, 64),

        new("atlas_world.png", 4, 4, 0, "world/rooms/world_room_template_stone_chamber.png", 1536, 864),
        new("atlas_world.png", 4, 4, 1, "world/rooms/world_floor_tile_stone_sheet.png", 384, 128),
        new("atlas_world.png", 4, 4, 2, "world/doors/world_south_entrance.png", 320, 160),
        new("atlas_world.png", 4, 4, 3, "world/doors/world_north_exit_locked.png", 320, 160),
        new("atlas_world.png", 4, 4, 4, "world/doors/world_north_exit_unlocked_sheet.png", 640, 160),
        new("atlas_world.png", 4, 4, 5, "world/props/world_wall_stone_segment.png", 192, 256),
        new("atlas_world.png", 4, 4, 6, "world/props/world_torch_prop.png", 96, 160),
        new("atlas_world.png", 4, 4, 7, "world/props/world_candle_prop.png", 64, 96),
        new("atlas_world.png", 4, 4, 8, "world/props/world_rubble_prop.png", 160, 128),
        new("atlas_world.png", 4, 4, 9, "world/props/world_skull_bone_prop.png", 96, 96),
        new("atlas_world.png", 4, 4, 10, "world/props/world_chain_cage_prop.png", 160, 224),
        new("atlas_world.png", 4, 4, 11, "world/props/world_banner_crimson_prop.png", 128, 192),
        new("atlas_world.png", 4, 4, 12, "world/pickups/world_coin_reward_visual_sheet.png", 128, 64),

        // This source atlas is currently absent on disk; listed so the report makes the gap explicit.
        new("atlas_ui_components.png", 4, 4, 8, "ui/panels/ui_panel_stone_rounded_sheet.png", 1024, 512),
    };

    static Mat CutOne(Mat atlas, CutSpec spec)
    {
        var cellW = atlas.Width / spec.Cols;
        var cellH = atlas.Height / spec.Rows;
        var cellRect = new Rect((spec.Index % spec.Cols) * cellW, (spec.Index / spec.Cols) * cellH, cellW, cellH);
        using var cellBgr = new Mat(atlas, cellRect).Clone();

        using var subject = BuildSubjectMask(cellBgr);

        using var points = new Mat();
        Cv2.FindNonZero(subject, points);
        if (points.Empty())
            return new Mat(spec.Height, spec.Width, MatType.CV_8UC4, Scalar.All(0));

        var bbox = Cv2.BoundingRect(points);
        bbox = Expand(bbox, 8, cellBgr.Width, cellBgr.Height);

        using var cropBgr = new Mat(cellBgr, bbox).Clone();
        using var cropAlpha = new Mat(subject, bbox).Clone();

        using var cropBgra = new Mat();
        Cv2.CvtColor(cropBgr, cropBgra, ColorConversionCodes.BGR2BGRA);
        Cv2.InsertChannel(cropAlpha, cropBgra, 3);
        using (var transparent = new Mat())
        {
            Cv2.InRange(cropAlpha, new Scalar(0), new Scalar(0), transparent);
            cropBgra.SetTo(new Scalar(0, 0, 0, 0), transparent);
        }

        var canvas = new Mat(spec.Height, spec.Width, MatType.CV_8UC4, Scalar.All(0));
        var maxW = Math.Max(1, spec.Width - 4);
        var maxH = Math.Max(1, spec.Height - 4);
        var scale = spec.PreserveAspect
            ? Math.Min(maxW / (double)cropBgra.Width, maxH / (double)cropBgra.Height)
            : 1.0;
        var w = spec.PreserveAspect ? Math.Max(1, (int)Math.Round(cropBgra.Width * scale)) : spec.Width;
        var h = spec.PreserveAspect ? Math.Max(1, (int)Math.Round(cropBgra.Height * scale)) : spec.Height;

        using var resized = new Mat();
        Cv2.Resize(cropBgra, resized, new Size(w, h), 0, 0, w < cropBgra.Width || h < cropBgra.Height ? InterpolationFlags.Area : InterpolationFlags.Cubic);
        var roi = new Rect((spec.Width - w) / 2, (spec.Height - h) / 2, w, h);
        resized.CopyTo(new Mat(canvas, roi));
        return canvas;
    }

    static Mat BuildSubjectMask(Mat bgr)
    {
        using var hsv = new Mat();
        Cv2.CvtColor(bgr, hsv, ColorConversionCodes.BGR2HSV);
        using var hsvGreen = new Mat();
        Cv2.InRange(hsv, new Scalar(35, 95, 105), new Scalar(90, 255, 255), hsvGreen);

        using var pureGreen = new Mat();
        Cv2.InRange(bgr, new Scalar(0, 155, 0), new Scalar(150, 255, 150), pureGreen);
        using var green = new Mat();
        Cv2.BitwiseOr(hsvGreen, pureGreen, green);

        var subject = new Mat();
        Cv2.BitwiseNot(green, subject);
        using var kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(3, 3));
        Cv2.MorphologyEx(subject, subject, MorphTypes.Open, kernel);

        using var labels = new Mat();
        using var stats = new Mat();
        using var cents = new Mat();
        var count = Cv2.ConnectedComponentsWithStats(subject, labels, stats, cents, PixelConnectivity.Connectivity8);
        if (count <= 1) return subject;

        var largest = 0;
        for (var i = 1; i < count; i++)
            largest = Math.Max(largest, stats.Get<int>(i, (int)ConnectedComponentsTypes.Area));

        var cleaned = new Mat(subject.Rows, subject.Cols, MatType.CV_8UC1, Scalar.All(0));
        for (var i = 1; i < count; i++)
        {
            var x = stats.Get<int>(i, (int)ConnectedComponentsTypes.Left);
            var y = stats.Get<int>(i, (int)ConnectedComponentsTypes.Top);
            var w = stats.Get<int>(i, (int)ConnectedComponentsTypes.Width);
            var h = stats.Get<int>(i, (int)ConnectedComponentsTypes.Height);
            var area = stats.Get<int>(i, (int)ConnectedComponentsTypes.Area);
            var touchesEdge = x == 0 || y == 0 || x + w >= subject.Cols || y + h >= subject.Rows;
            var largeEnough = area >= Math.Max(24, largest * 0.01);
            var likelyMainEdgeObject = area >= largest * 0.45;
            if (largeEnough && (!touchesEdge || likelyMainEdgeObject))
            {
                using var componentMask = new Mat();
                Cv2.InRange(labels, new Scalar(i), new Scalar(i), componentMask);
                cleaned.SetTo(new Scalar(255), componentMask);
            }
        }

        subject.Dispose();
        return cleaned;
    }

    static Rect Expand(Rect r, int pad, int maxW, int maxH)
    {
        var x = Math.Max(0, r.X - pad);
        var y = Math.Max(0, r.Y - pad);
        var right = Math.Min(maxW, r.X + r.Width + pad);
        var bottom = Math.Min(maxH, r.Y + r.Height + pad);
        return new Rect(x, y, Math.Max(1, right - x), Math.Max(1, bottom - y));
    }

    static void WriteReport(string path, string atlasRoot, List<string> restored, List<string> existing, List<string> missingAtlas, List<string> failed)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"atlas_root={atlasRoot}");
        sb.AppendLine($"restored={restored.Count}");
        foreach (var item in restored) sb.AppendLine($"restored\t{item}");
        sb.AppendLine($"skipped_existing={existing.Count}");
        foreach (var item in existing) sb.AppendLine($"existing\t{item}");
        sb.AppendLine($"skipped_missing_atlas={missingAtlas.Count}");
        foreach (var item in missingAtlas) sb.AppendLine($"missing_atlas\t{item}");
        sb.AppendLine($"failed={failed.Count}");
        foreach (var item in failed) sb.AppendLine($"failed\t{item}");
        File.WriteAllText(path, sb.ToString());
    }

    static void WriteContactSheet(string path, string root, List<string> restored)
    {
        if (restored.Count == 0)
        {
            using var empty = new Mat(120, 640, MatType.CV_8UC3, Scalar.All(245));
            Cv2.PutText(empty, "No assets restored", new Point(20, 70), HersheyFonts.HersheySimplex, 1, Scalar.Black, 2);
            Cv2.ImWrite(path, empty);
            return;
        }

        const int tile = 210;
        const int labelH = 44;
        const int cols = 5;
        var rows = (int)Math.Ceiling(restored.Count / (double)cols);
        using var sheet = new Mat(rows * (tile + labelH), cols * tile, MatType.CV_8UC3, new Scalar(235, 235, 235));
        for (var i = 0; i < restored.Count; i++)
        {
            var rel = restored[i];
            using var src = Cv2.ImRead(Path.Combine(root, "Assets", "Generated", "MVP", rel.Replace('/', Path.DirectorySeparatorChar)), ImreadModes.Unchanged);
            using var vis = CompositeOnChecker(src, tile, tile - 8);
            var x = (i % cols) * tile;
            var y = (i / cols) * (tile + labelH);
            vis.CopyTo(new Mat(sheet, new Rect(x, y, tile, tile - 8)));
            Cv2.Rectangle(sheet, new Rect(x + 1, y + 1, tile - 3, tile - 10), new Scalar(20, 120, 20), 2);
            Cv2.PutText(sheet, ShortName(Path.GetFileName(rel)), new Point(x + 4, y + tile + 14), HersheyFonts.HersheySimplex, 0.36, Scalar.Black, 1);
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
            checker.CopyTo(bgr);
            rgb.CopyTo(bgr, alpha);
            checker.Dispose();
        }
        else src.CopyTo(bgr);

        var scale = Math.Min(targetW / (double)bgr.Cols, targetH / (double)bgr.Rows);
        var w = Math.Max(1, (int)Math.Round(bgr.Cols * scale));
        var h = Math.Max(1, (int)Math.Round(bgr.Rows * scale));
        using var resized = new Mat();
        Cv2.Resize(bgr, resized, new Size(w, h), 0, 0, InterpolationFlags.Area);
        var canvas = new Mat(targetH, targetW, MatType.CV_8UC3, Scalar.All(250));
        resized.CopyTo(new Mat(canvas, new Rect((targetW - w) / 2, (targetH - h) / 2, w, h)));
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

    static string ShortName(string name) => name.Length <= 34 ? name : name[..31] + "...";
}
