using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using static UnityEngine.Debug;

namespace AssetCacheCleaner {
    public static partial class BaseVerticalCollectionViewExtensions {
        [NotNull] public static T WithOnScrollView<T>(
            [NotNull] this T element,
            [CanBeNull] Action<ScrollView> callback)
                where T : BaseVerticalCollectionView {
            var scrollView = element.Q<ScrollView>();
            if (scrollView == null) {
                LogWarning("Fluent Editor UIElements: child ScrollView not " +
                    $"found for element of type {element.GetType().Name}");

                return element;
            }

            callback?.Invoke(scrollView);
            return element;
        }
        
        [NotNull] public static T WithOnScrollView<T>(
            [NotNull] this T element,
            [CanBeNull] Action<T, ScrollView> callback)
                where T : BaseVerticalCollectionView {
            var scrollView = element.Q<ScrollView>();
            if (scrollView == null) {
                LogWarning("Fluent Editor UIElements: child ScrollView not " +
                    $"found for element of type {element.GetType().Name}");

                return element;
            }
            callback?.Invoke(element, scrollView);
            return element;
        }
        
        [NotNull] public static T WithOnScrollView<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<ScrollView, TData> callback)
                where T : BaseVerticalCollectionView {
            var scrollView = element.Q<ScrollView>();
            if (scrollView == null) {
                LogWarning("Fluent Editor UIElements: child ScrollView not " +
                    $"found for element of type {element.GetType().Name}");

                return element;
            }
            callback?.Invoke(scrollView, data);
            return element;
        }
        
        [NotNull] public static T WithOnScrollView<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, ScrollView, TData> callback)
                where T : BaseVerticalCollectionView {
            var scrollView = element.Q<ScrollView>();
            if (scrollView == null) {
                LogWarning("Fluent Editor UIElements: child ScrollView not " +
                    $"found for element of type {element.GetType().Name}");

                return element;
            }
            callback?.Invoke(element, scrollView, data);
            return element;
        }
    }
}