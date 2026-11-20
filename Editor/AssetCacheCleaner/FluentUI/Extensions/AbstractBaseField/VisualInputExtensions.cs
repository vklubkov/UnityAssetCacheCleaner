#if UNITY_6000_6_OR_NEWER

using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class AbstractBaseFieldExtensions {
        /// Sets the visualInput. Uses reflection.
        /// A workaround is to specify the visual input in the constructor.
        [NotNull] public static T WithVisualInput<T>([NotNull] this T element, [CanBeNull] VisualElement visualInput)
                where T : AbstractBaseField {
            if (AbstractBaseFieldReflection.IsSupported(element.GetType()))
                new AbstractBaseFieldReflection(element).VisualInput = visualInput;

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T>(
            [NotNull] this T element,
            [CanBeNull] Action<VisualElement> callback)
                where T : AbstractBaseField {
            var visualInput = element.GetVisualInput();
            if (visualInput != null)
                callback?.Invoke(visualInput);

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T>(
            [NotNull] this T element,
            [CanBeNull] Action<T, VisualElement> callback)
                where T : AbstractBaseField {
            var visualInput = element.GetVisualInput();
            if (visualInput != null)
                callback?.Invoke(element, visualInput);

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<VisualElement, TData> callback)
                where T : AbstractBaseField {
            var visualInput = element.GetVisualInput();
            if (visualInput != null)
                callback?.Invoke(visualInput, data);

            return element;
        }

        [NotNull] public static T WithOnVisualInput<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, VisualElement, TData> callback)
                where T : AbstractBaseField {
            var visualInput = element.GetVisualInput();
            if (visualInput != null)
                callback?.Invoke(element, visualInput, data);

            return element;
        }

        static VisualElement GetVisualInput<T>(this T element)
                where T : AbstractBaseField =>
            AbstractBaseFieldReflection.IsSupported(element.GetType())
                ? new AbstractBaseFieldReflection(element).VisualInput
                : null;
    }
}

#endif