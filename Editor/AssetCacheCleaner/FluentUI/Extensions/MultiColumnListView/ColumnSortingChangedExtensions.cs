using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class MultiColumnListViewExtensions {
        [NotNull] public static T WhenColumnSortingChanged<T>(
            [NotNull] this T element,
            [CanBeNull] Action columnSortingChanged)
                where T : MultiColumnListView {
            element.columnSortingChanged += columnSortingChanged;
            return element;
        }

        [NotNull] public static T WithoutColumnSortingChanged<T>(
            [NotNull] this T element,
            [CanBeNull] Action columnSortingChanged)
                where T : MultiColumnListView {
            element.columnSortingChanged -= columnSortingChanged;
            return element;
        }
    }
}