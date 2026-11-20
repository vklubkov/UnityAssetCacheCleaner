using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static Label Label() => new();
        [NotNull] public static Label Label(string text) => new(text);
    }
}