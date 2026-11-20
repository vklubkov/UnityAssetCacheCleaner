using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithBorderTopWidth<T>([NotNull] this T element, StyleFloat width)
                where T : VisualElement {
            element.style.borderTopWidth = width;
            return element;
        }

        [NotNull] public static T WithBorderLeftWidth<T>([NotNull] this T element, StyleFloat width)
                where T : VisualElement {
            element.style.borderLeftWidth = width;
            return element;
        }

        [NotNull] public static T WithBorderBottomWidth<T>([NotNull] this T element, StyleFloat width)
                where T : VisualElement {
            element.style.borderBottomWidth = width;
            return element;
        }

        [NotNull] public static T WithBorderRightWidth<T>([NotNull] this T element, StyleFloat width)
                where T : VisualElement {
            element.style.borderRightWidth = width;
            return element;
        }

        [NotNull] public static T WithBorderWidth<T>([NotNull] this T element, StyleFloat width)
                where T : VisualElement {
            element.style.borderTopWidth = width;
            element.style.borderLeftWidth = width;
            element.style.borderBottomWidth = width;
            element.style.borderRightWidth = width;
            return element;
        }

        [NotNull] public static T WithBorderWidth<T>(
            [NotNull] this T element,
            StyleFloat leftRight,
            StyleFloat topBottom)
                where T : VisualElement {
            element.style.borderLeftWidth = leftRight;
            element.style.borderRightWidth = leftRight;
            element.style.borderTopWidth = topBottom;
            element.style.borderBottomWidth = topBottom;
            return element;
        }

        [NotNull] public static T WithBorderWidth<T>(
            [NotNull] this T element,
            StyleFloat left,
            StyleFloat right,
            StyleFloat top,
            StyleFloat bottom)
                where T : VisualElement {
            element.style.borderTopWidth = top;
            element.style.borderLeftWidth = left;
            element.style.borderBottomWidth = bottom;
            element.style.borderRightWidth = right;
            return element;
        }

        [NotNull] public static T WithBorderTopLeftRadius<T>([NotNull] this T element, StyleLength radius)
                where T : VisualElement {
            element.style.borderTopLeftRadius = radius;
            return element;
        }

        [NotNull] public static T WithBorderBottomLeftRadius<T>([NotNull] this T element, StyleLength radius)
                where T : VisualElement {
            element.style.borderBottomLeftRadius = radius;
            return element;
        }

        [NotNull] public static T WithBorderTopRightRadius<T>([NotNull] this T element, StyleLength radius)
                where T : VisualElement {
            element.style.borderTopRightRadius = radius;
            return element;
        }

        [NotNull] public static T WithBorderBottomRightRadius<T>([NotNull] this T element, StyleLength radius)
                where T : VisualElement {
            element.style.borderBottomRightRadius = radius;
            return element;
        }

        [NotNull] public static T WithBorderRadius<T>([NotNull] this T element, StyleLength radius)
                where T : VisualElement {
            element.style.borderTopLeftRadius = radius;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderTopRightRadius = radius;
            element.style.borderBottomRightRadius = radius;
            return element;
        }

        [NotNull] public static T WithBorderRadius<T>(
            [NotNull] this T element,
            StyleLength topLeft,
            StyleLength bottomLeft,
            StyleLength topRight,
            StyleLength bottomRight)
                where T : VisualElement {
            element.style.borderTopLeftRadius = topLeft;
            element.style.borderBottomLeftRadius = bottomLeft;
            element.style.borderTopRightRadius = topRight;
            element.style.borderBottomRightRadius = bottomRight;
            return element;
        }

        [NotNull] public static T WithBorderTopColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.borderTopColor = color;
            return element;
        }

        [NotNull] public static T WithBorderLeftColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.borderLeftColor = color;
            return element;
        }

        [NotNull] public static T WithBorderBottomColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.borderBottomColor = color;
            return element;
        }

        [NotNull] public static T WithBorderRightColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.borderRightColor = color;
            return element;
        }

        [NotNull] public static T WithBorderColor<T>([NotNull] this T element, StyleColor color)
                where T : VisualElement {
            element.style.borderTopColor = color;
            element.style.borderLeftColor = color;
            element.style.borderBottomColor = color;
            element.style.borderRightColor = color;
            return element;
        }

        [NotNull] public static T WithBorderColor<T>(
            [NotNull] this T element,
            StyleColor leftRight,
            StyleColor topBottom)
            where T : VisualElement {
            element.style.borderLeftColor = leftRight;
            element.style.borderRightColor = leftRight;
            element.style.borderTopColor = topBottom;
            element.style.borderBottomColor = topBottom;
            return element;
        }

        [NotNull] public static T WithBorderColor<T>(
            [NotNull] this T element,
            StyleColor left,
            StyleColor right,
            StyleColor top,
            StyleColor bottom)
                where T : VisualElement {
            element.style.borderLeftColor = left;
            element.style.borderRightColor = right;
            element.style.borderTopColor = top;
            element.style.borderBottomColor = bottom;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleFloat width,
            StyleLength radius)
                where T : VisualElement {
            element.style.borderLeftWidth = width;
            element.style.borderRightWidth = width;
            element.style.borderTopWidth = width;
            element.style.borderBottomWidth = width;
            element.style.borderTopLeftRadius = radius;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderTopRightRadius = radius;
            element.style.borderBottomRightRadius = radius;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleFloat width,
            StyleColor color)
                where T : VisualElement {
            element.style.borderLeftWidth = width;
            element.style.borderRightWidth = width;
            element.style.borderTopWidth = width;
            element.style.borderBottomWidth = width;
            element.style.borderLeftColor = color;
            element.style.borderRightColor = color;
            element.style.borderTopColor = color;
            element.style.borderBottomColor = color;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleLength radius,
            StyleColor color)
                where T : VisualElement {
            element.style.borderTopLeftRadius = radius;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderTopRightRadius = radius;
            element.style.borderBottomRightRadius = radius;
            element.style.borderLeftColor = color;
            element.style.borderRightColor = color;
            element.style.borderTopColor = color;
            element.style.borderBottomColor = color;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleFloat width,
            StyleLength radius,
            StyleColor color)
                where T : VisualElement {
            element.style.borderLeftWidth = width;
            element.style.borderRightWidth = width;
            element.style.borderTopWidth = width;
            element.style.borderBottomWidth = width;
            element.style.borderTopLeftRadius = radius;
            element.style.borderBottomLeftRadius = radius;
            element.style.borderTopRightRadius = radius;
            element.style.borderBottomRightRadius = radius;
            element.style.borderLeftColor = color;
            element.style.borderRightColor = color;
            element.style.borderTopColor = color;
            element.style.borderBottomColor = color;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleFloat topWidth,
            StyleFloat leftWidth,
            StyleFloat bottomWidth,
            StyleFloat rightWidth,
            StyleLength topLeftRadius,
            StyleLength bottomLeftRadius,
            StyleLength topRightRadius,
            StyleLength bottomRightRadius)
                where T : VisualElement {
            element.style.borderLeftWidth = leftWidth;
            element.style.borderRightWidth = rightWidth;
            element.style.borderTopWidth = topWidth;
            element.style.borderBottomWidth = bottomWidth;
            element.style.borderTopLeftRadius = topLeftRadius;
            element.style.borderBottomLeftRadius = bottomLeftRadius;
            element.style.borderTopRightRadius = topRightRadius;
            element.style.borderBottomRightRadius = bottomRightRadius;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleFloat topWidth,
            StyleFloat leftWidth,
            StyleFloat bottomWidth,
            StyleFloat rightWidth,
            StyleColor topColor,
            StyleColor leftColor,
            StyleColor bottomColor,
            StyleColor rightColor)
                where T : VisualElement {
            element.style.borderLeftWidth = leftWidth;
            element.style.borderRightWidth = rightWidth;
            element.style.borderTopWidth = topWidth;
            element.style.borderBottomWidth = bottomWidth;
            element.style.borderLeftColor = leftColor;
            element.style.borderRightColor = rightColor;
            element.style.borderTopColor = topColor;
            element.style.borderBottomColor = bottomColor;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleLength topLeftRadius,
            StyleLength bottomLeftRadius,
            StyleLength topRightRadius,
            StyleLength bottomRightRadius,
            StyleColor topColor,
            StyleColor leftColor,
            StyleColor bottomColor,
            StyleColor rightColor)
                where T : VisualElement {
            element.style.borderTopLeftRadius = topLeftRadius;
            element.style.borderBottomLeftRadius = bottomLeftRadius;
            element.style.borderTopRightRadius = topRightRadius;
            element.style.borderBottomRightRadius = bottomRightRadius;
            element.style.borderLeftColor = leftColor;
            element.style.borderRightColor = rightColor;
            element.style.borderTopColor = topColor;
            element.style.borderBottomColor = bottomColor;
            return element;
        }

        [NotNull] public static T WithBorder<T>(
            [NotNull] this T element,
            StyleFloat topWidth,
            StyleFloat leftWidth,
            StyleFloat bottomWidth,
            StyleFloat rightWidth,
            StyleLength topLeftRadius,
            StyleLength bottomLeftRadius,
            StyleLength topRightRadius,
            StyleLength bottomRightRadius,
            StyleColor topColor,
            StyleColor leftColor,
            StyleColor bottomColor,
            StyleColor rightColor)
                where T : VisualElement {
            element.style.borderLeftWidth = leftWidth;
            element.style.borderRightWidth = rightWidth;
            element.style.borderTopWidth = topWidth;
            element.style.borderBottomWidth = bottomWidth;
            element.style.borderTopLeftRadius = topLeftRadius;
            element.style.borderBottomLeftRadius = bottomLeftRadius;
            element.style.borderTopRightRadius = topRightRadius;
            element.style.borderBottomRightRadius = bottomRightRadius;
            element.style.borderLeftColor = leftColor;
            element.style.borderRightColor = rightColor;
            element.style.borderTopColor = topColor;
            element.style.borderBottomColor = bottomColor;
            return element;
        }
    }
}