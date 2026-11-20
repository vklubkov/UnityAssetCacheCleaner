using JetBrains.Annotations;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static SelectableLabel SelectableLabel() => new();
        [NotNull] public static SelectableLabel SelectableLabel(string text) => new(text);
    }
}