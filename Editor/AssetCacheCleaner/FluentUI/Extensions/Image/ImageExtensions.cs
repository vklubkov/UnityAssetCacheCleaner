using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class ImageExtensions {
        [NotNull] public static T WithImage<T>([NotNull] this T element, [CanBeNull] Texture texture)
                where T : Image {
            element.image = texture;
            return element;
        }

        [NotNull] public static T WithScaleMode<T>([NotNull] this T element, ScaleMode scaleMode)
                where T : Image {
            element.scaleMode = scaleMode;
            return element;
        }
    }
}