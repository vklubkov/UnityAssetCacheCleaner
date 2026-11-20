using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithWidth<T>([NotNull] this T element, StyleLength width)
                where T : VisualElement {
            element.style.width = width;
            return element;
        }

        [NotNull] public static T WithMinWidth<T>([NotNull] this T element, StyleLength width)
                where T : VisualElement {
            element.style.minWidth = width;
            return element;
        }

        [NotNull] public static T WithMaxWidth<T>([NotNull] this T element, StyleLength width)
                where T : VisualElement {
            element.style.maxWidth = width;
            return element;
        }

        [NotNull] public static T WithHeight<T>([NotNull] this T element, StyleLength height)
                where T : VisualElement {
            element.style.height = height;
            return element;
        }

        [NotNull] public static T WithMinHeight<T>([NotNull] this T element, StyleLength height)
                where T : VisualElement {
            element.style.minHeight = height;
            return element;
        }

        [NotNull] public static T WithMaxHeight<T>([NotNull] this T element, StyleLength height)
                where T : VisualElement {
            element.style.maxHeight = height;
            return element;
        }

        [NotNull] public static T WithSize<T>([NotNull] this T element, StyleLength size)
                where T : VisualElement {
            element.style.width = size;
            element.style.height = size;
            return element;
        }

        [NotNull] public static T WithSize<T>([NotNull] this T element, StyleLength width, StyleLength height)
                where T : VisualElement {
            element.style.width = width;
            element.style.height = height;
            return element;
        }

        [NotNull] public static T WithMinSize<T>([NotNull] this T element, StyleLength size)
                where T : VisualElement {
            element.style.minWidth = size;
            element.style.minHeight = size;
            return element;
        }

        [NotNull] public static T WithMinSize<T>([NotNull] this T element, StyleLength width, StyleLength height)
                where T : VisualElement {
            element.style.minWidth = width;
            element.style.minHeight = height;
            return element;
        }

        [NotNull] public static T WithMaxSize<T>([NotNull] this T element, StyleLength size)
                where T : VisualElement {
            element.style.maxWidth = size;
            element.style.maxHeight = size;
            return element;
        }

        [NotNull] public static T WithMaxSize<T>([NotNull] this T element, StyleLength width, StyleLength height)
                where T : VisualElement {
            element.style.maxWidth = width;
            element.style.maxHeight = height;
            return element;
        }

        [NotNull] public static T WithAspectRatio<T>([NotNull] this T element, StyleRatio aspectRatio)
                where T : VisualElement {
            element.style.aspectRatio = aspectRatio;
            return element;
        }
    }
}