using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class ColumnExtensions {
        [NotNull] public static T AddTo<T>(
            [NotNull] this T column,
            [NotNull] Columns columns)
                where T : Column {
            columns.Add(column);
            return column;
        }

        [NotNull] public static T WithName<T>(
            [NotNull] this T column,
            [CanBeNull] string name)
                where T : Column {
            column.name = name;
            return column;
        }

        [NotNull] public static T WithTitle<T>(
            [NotNull] this T column,
            [CanBeNull] string title)
                where T : Column {
            column.title = title;
            return column;
        }

        [NotNull] public static T AsSortable<T>(
            [NotNull] this T column,
            bool sortable = true)
                where T : Column {
            column.sortable = sortable;
            return column;
        }

        [NotNull] public static T AsStretchable<T>(
            [NotNull] this T column,
            bool stretchable = true)
                where T : Column {
            column.stretchable = stretchable;
            return column;
        }

        [NotNull] public static T WithMinWidth<T>(
            [NotNull] this T column,
            Length minWidth)
                where T : Column {
            column.minWidth = minWidth;
            return column;
        }

        [NotNull] public static T WithWidth<T>(
            [NotNull] this T column,
            Length width)
                where T : Column {
            column.width = width;
            return column;
        }

        [NotNull] public static T WithMaxWidth<T>(
            [NotNull] this T column,
            Length maxWidth)
                where T : Column {
            column.maxWidth = maxWidth;
            return column;
        }

        [NotNull]
        public static T WithMakeCell<T>(
            [NotNull] this T column,
            [CanBeNull] Func<VisualElement> makeCell)
                where T : Column {
            column.makeCell = makeCell;
            return column;
        }

        [NotNull]
        public static T WithoutMakeCell<T>(
            [NotNull] this T column)
            where T : Column {
            column.makeCell = null;
            return column;
        }

        [NotNull]
        public static T WithBindCell<T>(
            [NotNull] this T column,
            [CanBeNull] Action<VisualElement, int> bindCell)
            where T : Column {
            column.bindCell = bindCell;
            return column;
        }

        [NotNull]
        public static T WithoutBindCell<T>(
            [NotNull] this T column)
                where T : Column {
            column.bindCell = null;
            return column;
        }
    }
}