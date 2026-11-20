using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class MultiColumnListViewExtensions {
        [NotNull] public static T WithSortingMode<T>(
            [NotNull] this T element,
            ColumnSortingMode sortingMode)
                where T : MultiColumnListView {
            element.sortingMode = sortingMode;
            return element;
        }
    }
}