using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class TextFieldExtensions {
        [NotNull] public static T AsDelayed<T>([NotNull] this T element, bool isDelayed = true)
                where T : TextField {
            element.isDelayed = isDelayed;
            return element;
        }
    }
}