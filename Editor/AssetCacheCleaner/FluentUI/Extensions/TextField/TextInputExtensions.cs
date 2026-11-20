using JetBrains.Annotations;
using System;
using UnityEngine.UIElements;
using static UnityEngine.Debug;

namespace AssetCacheCleaner {
    public static partial class TextFieldExtensions {
        [NotNull] public static T WithOnTextInput<T>(
            [NotNull] this T element,
            [CanBeNull] Action<VisualElement> callback)
                where T : TextField {
            var textInput = element.GetTextInput();
            if (textInput != null)
                callback?.Invoke(textInput);

            return element;
        }

        [NotNull] public static T WithOnTextInput<T>(
            [NotNull] this T element,
            [CanBeNull] Action<T, VisualElement> callback)
                where T : TextField {
            var textInput = element.GetTextInput();
            if (textInput != null)
                callback?.Invoke(element, textInput);

            return element;
        }

        [NotNull] public static T WithOnTextInput<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<VisualElement, TData> callback)
                where T : TextField {
            var textInput = element.GetTextInput();
            if (textInput != null)
                callback?.Invoke(textInput, data);

            return element;
        }

        [NotNull] public static T WithOnTextInput<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, VisualElement, TData> callback)
                where T : TextField {
            var textInput = element.GetTextInput();
            if (textInput != null)
                callback?.Invoke(element, textInput, data);

            return element;
        }

        static VisualElement GetTextInput<T>([NotNull] this T element) where T : TextField {
            var textInput = TextFieldReflection.IsSupported(element.GetType())
                ? new TextFieldReflection(element).TextInput
                : element.Q(name: TextField.textInputUssName);

            if (textInput == null) {
                LogWarning("Fluent Editor UIElements: text input not found " +
                    $"for element of type {element.GetType().Name}");
            }

            return textInput;
        }
    }
}