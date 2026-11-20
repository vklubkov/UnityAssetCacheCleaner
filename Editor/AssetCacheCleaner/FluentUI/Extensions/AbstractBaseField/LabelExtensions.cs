#if UNITY_6000_6_OR_NEWER

using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class AbstractBaseFieldExtensions {
        [NotNull] public static T WithLabel<T>([NotNull] this T element, [CanBeNull] string label)
                where T : AbstractBaseField {
            element.label = label;
            return element;
        }

        [NotNull] public static T WithoutLabel<T>([NotNull] this T element)
                where T : AbstractBaseField {
            element.label = "";
            return element;
        }

        [NotNull] public static T WithBlankLabel<T>([NotNull] this T element)
                where T : AbstractBaseField {
            element.label = " ";
            return element;
        }

        [NotNull] public static T WithBoundSerializedPropertyDisplayNameLabel<T>([NotNull] this T element)
                where T : AbstractBaseField {
            element.label = null;
            return element;
        }
    }
}

#endif