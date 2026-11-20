using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class TextFieldExtensions {
        /// Makes the TextField look like a Label (read-only, no border, no background, no padding).
        /// Note: you will likely want to use <c>WithWhiteSpace()</c> together with this method.
        [NotNull] public static T AsSelectableLabel<T>([NotNull] this T element, bool shrink = true)
                where T : TextField => element
            .AsReadOnly()
            .WithOnLabelElement(static labelElement => labelElement.WithDisplay(DisplayStyle.None))
            .WithMargin(0)
            .WithPadding(0)
            .WithOnAttachToPanel(data: shrink, static (evt, shrink) => (evt.currentTarget as T)
                ?.WithOnTextInput(static textInput => textInput
                    .WithBackgroundColor(Color.clear)
                    .WithBorderWidth(0)
                    .WithMargin(0)
                    .WithPaddingTopBottom(0)
                    .WithPaddingLeftRight(left: 1, right: 2))
                .WithOnTextElement(data: shrink, static (textElement, shrink) => textElement
                    .WithFlexGrow(shrink ? 0 : 1)
                    .WithMargin(0)
                    .WithPadding(0)
                    .WithPaddingRight(1))); // When text has 0 horizontal padding, it may scroll during selection.
    }
}