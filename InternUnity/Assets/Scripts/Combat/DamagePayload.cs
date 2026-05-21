using System;
using UnityEngine;

namespace Stackspire.Combat
{
    [Serializable]
    public readonly struct DamagePayload
    {
        public DamagePayload(int hearts, GameObject sourceObject, string sourceLabel)
        {
            Hearts = Mathf.Max(0, hearts);
            SourceObject = sourceObject;
            SourceLabel = string.IsNullOrWhiteSpace(sourceLabel) ? "Unknown" : sourceLabel;
        }

        public int Hearts { get; }

        public GameObject SourceObject { get; }

        public string SourceLabel { get; }
    }
}
