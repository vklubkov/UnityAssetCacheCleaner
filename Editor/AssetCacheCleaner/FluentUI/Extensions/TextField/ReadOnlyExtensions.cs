using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class TextFieldExtensions {
        [NotNull] public static T AsReadOnly<T>([NotNull] this T element, bool value = true)
                where T : TextField {
            element.isReadOnly = value;
            return element;
        }
    }
}