using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class VisualElementExtensions {
        [NotNull] public static T WithFont<T>(
            [NotNull] this T element,
            StyleFont font)
                where T : VisualElement {
            element.style.unityFont = font;
            return element;
        }

        [NotNull] public static T WithFontSize<T>(
            [NotNull] this T element,
            StyleLength fontSize)
                where T : VisualElement {
            element.style.fontSize = fontSize;
            return element;
        }

        [NotNull] public static T WithFontStyleAndWeight<T>(
            [NotNull] this T element,
            StyleEnum<FontStyle> fontStyleAndWeight)
                where T : VisualElement {
            element.style.unityFontStyleAndWeight = fontStyleAndWeight;
            return element;
        }

        [NotNull] public static T WithTextAlign<T>(
            [NotNull] this T element,
            StyleEnum<TextAnchor> textAlign)
                where T : VisualElement {
            element.style.unityTextAlign = textAlign;
            return element;
        }


    }
}
