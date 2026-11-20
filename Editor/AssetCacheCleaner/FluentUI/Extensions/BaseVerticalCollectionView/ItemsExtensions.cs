using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class BaseVerticalCollectionViewExtensions {
        [NotNull] public static T WhenItemsChosen<T>(
            [NotNull] this T element,
            [CanBeNull] Action<IEnumerable<object>> itemsChosen)
                where T : BaseVerticalCollectionView {
            element.itemsChosen += itemsChosen;
            return element;
        }

        [NotNull] public static T WithoutItemsChosen<T>(
            [NotNull] this T element,
            [CanBeNull] Action<IEnumerable<object>> itemsChosen)
                where T : BaseVerticalCollectionView {
            element.itemsChosen -= itemsChosen;
            return element;
        }

        [NotNull] public static T WithItemsSource<T>([NotNull] this T element, [NotNull] IList itemsSource)
                where T : BaseVerticalCollectionView {
            element.itemsSource = itemsSource;
            return element;
        }

        [NotNull] public static T WithRebuild<T>([NotNull] this T element)
                where T : BaseVerticalCollectionView {
            element.Rebuild();
            return element;
        }

        [NotNull] public static T WithRefreshItems<T>([NotNull] this T element)
                where T : BaseVerticalCollectionView {
            element.RefreshItems();
            return element;
        }
    }
}