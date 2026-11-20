using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class ScrollViewExtensions {
        [NotNull] public static T WithMode<T>([NotNull] this T element, ScrollViewMode scrollViewMode)
                where T : ScrollView {
            element.mode = scrollViewMode;
            return element;
        }

        [NotNull] public static T WithHorizontalScrollerVisibility<T>([NotNull] this T element, ScrollerVisibility visibility)
                where T : ScrollView {
            element.horizontalScrollerVisibility = visibility;
            return element;
        }

        [NotNull] public static T WithVerticalScrollerVisibility<T>([NotNull] this T element, ScrollerVisibility visibility)
                where T : ScrollView {
            element.verticalScrollerVisibility = visibility;
            return element;
        }
    }
}