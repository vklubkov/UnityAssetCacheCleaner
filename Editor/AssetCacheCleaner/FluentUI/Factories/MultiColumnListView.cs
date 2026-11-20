using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static MultiColumnListView MultiColumnListView() => new();
        [NotNull] public static MultiColumnListView MultiColumnListView(Columns columns) => new(columns);
    }
}