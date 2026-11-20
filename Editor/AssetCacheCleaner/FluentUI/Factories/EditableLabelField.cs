using JetBrains.Annotations;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static EditableLabelField EditableLabelField() => new();
        [NotNull] public static EditableLabelField EditableLabelField(string label) => new(label);
    }
}