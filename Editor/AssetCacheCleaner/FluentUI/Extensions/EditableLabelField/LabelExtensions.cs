#if !UNITY_6000_6_OR_NEWER

using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class EditableLabelFieldExtensions {
        [NotNull] public static T WithLabel<T>([NotNull] this T element, [CanBeNull] string label)
                where T : EditableLabelField {
            element.label = label;
            return element;
        }

        [NotNull] public static T WithoutLabel<T>([NotNull] this T element)
                where T : EditableLabelField {
            element.label = "";
            return element;
        }

        [NotNull] public static T WithBlankLabel<T>([NotNull] this T element)
                where T : EditableLabelField {
            element.label = " ";
            return element;
        }

        [NotNull] public static T WithBoundSerializedPropertyDisplayNameLabel<T>([NotNull] this T element)
                where T : EditableLabelField {
            element.label = null;
            return element;
        }
    }
}

#endif