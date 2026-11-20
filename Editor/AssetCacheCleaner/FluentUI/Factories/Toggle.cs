using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static Toggle Toggle() => new();
        [NotNull] public static Toggle Toggle(string label) => new(label);
    }
}