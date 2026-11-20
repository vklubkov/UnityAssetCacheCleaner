using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class TextElementExtensions {
        [NotNull] public static T WithText<T>([NotNull] this T element, string text)
                where T : TextElement {
            element.text = text;
            return element;
        }

        [NotNull] public static T WithoutText<T>([NotNull] this T element)
                where T : TextElement {
            element.text = "";
            return element;
        }

        [NotNull] public static T WithEmptyText<T>([NotNull] this T element)
                where T : TextElement {
            element.text = " ";
            return element;
        }

        [NotNull] public static T WithBoundSerializedPropertyDisplayNameLabel<T>([NotNull] this T element)
                where T : TextElement {
            element.text = null;
            return element;
        }
    }
}