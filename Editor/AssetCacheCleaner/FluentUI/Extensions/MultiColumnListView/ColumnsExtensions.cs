using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class MultiColumnListViewExtensions {
        [NotNull] public static T WithOnColumns<T>(
            [NotNull] this T element,
            [CanBeNull] Action<Columns> callback)
                where T : MultiColumnListView {
            callback?.Invoke(element.columns);
            return element;
        }

        [NotNull] public static T WithOnColumns<T>(
            [NotNull] this T element,
            [CanBeNull] Action<T, Columns> callback)
                where T : MultiColumnListView {
            callback?.Invoke(element, element.columns);
            return element;
        }

        [NotNull] public static T WithOnColumns<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<Columns, TData> callback)
                where T : MultiColumnListView {
            callback?.Invoke(element.columns, data);
            return element;
        }

        [NotNull] public static T WithOnColumns<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, Columns, TData> callback)
                where T : MultiColumnListView {
            callback?.Invoke(element, element.columns, data);
            return element;
        }
    }
}