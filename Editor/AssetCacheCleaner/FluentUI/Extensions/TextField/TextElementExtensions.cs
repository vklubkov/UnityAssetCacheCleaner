using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;
using static UnityEngine.Debug;

namespace AssetCacheCleaner {
    public static partial class TextFieldExtensions {
        [NotNull] public static T WithOnTextElement<T>(
            [NotNull] this T element,
            [CanBeNull] Action<TextElement> callback)
                where T : TextField {
            var textElement = element.GetTextElement();
            if (textElement != null)
                callback?.Invoke(textElement);

            return element;
        }

        [NotNull] public static T WithOnTextElement<T>(
            [NotNull] this T element,
            [CanBeNull] Action<T, TextElement> callback)
                where T : TextField {
            var textElement = element.GetTextElement();
            if (textElement != null)
                callback?.Invoke(element, textElement);

            return element;
        }

        [NotNull] public static T WithOnTextElement<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<TextElement, TData> callback)
                where T : TextField {
            var textElement = element.GetTextElement();
            if (textElement != null)
                callback?.Invoke(textElement, data);

            return element;
        }

        [NotNull] public static T WithOnTextElement<T, TData>(
            [NotNull] this T element,
            [CanBeNull] TData data,
            [CanBeNull] Action<T, TextElement, TData> callback)
                where T : TextField {
            var textElement = element.GetTextElement();
            if (textElement != null)
                callback?.Invoke(element, textElement, data);

            return element;
        }

        static TextElement GetTextElement<T>([NotNull] this T element) where T : TextField {
            TextElement textElement = null;

            var textInput = element.GetTextInput();
            if (textInput != null) {
                textElement = TextFieldTextInputReflection.IsSupported(textInput.GetType())
                    ? new TextFieldTextInputReflection(textInput).TextElement
                    : textInput.Q<TextElement>();
            }

            if (textElement == null) {
                LogWarning("Fluent Editor UIElements: TextElement of text input " +
                    $"not found for element of type {element.GetType().Name}");
            }

            return textElement;
        }
    }
}