using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public class EditableLabelField : BlankField<string> {
        readonly TextField _textField;

        bool _didButtonClickStartWhileTextFieldWasFocused;

        public EditableLabelField(string label = null) {
            var container = New
                .VisualElement()
                .WithFlexGrow(1)
                .WithFlexDirection(FlexDirection.Row);

            _textField = New
                .TextField()
                .AsDelayed()
                .WithoutLabel()
                .WithFlexGrow(1)
                .WithMarginLeft(0)
                .WithSelf(MakeTextFieldReadOnlyIfNeeded)
                .WithOnTextElement(this, static (textElement, thisElement) => textElement
                    .WithOnFocusOut(thisElement.OnTextElementFocusOut))
                .WithOnValueChanged(OnTextFieldValueChanged)
                .AddTo(container);

            New
                .SquaredButton()
#if UNITY_6000_7_OR_NEWER
                .WithText("🖉")
#else
                .WithText("✏️")
#endif
                .WithMarginLeft(2)
                .WithMarginRight(3)
                .WithOnPointerDown(OnButtonPointerDown, TrickleDown.TrickleDown) // Doesn't propagate on bubble up
                .WithOnPointerCancel(OnButtonPointerCancel)
                .WithOnPointerLeave(OnButtonPointerLeave)
                .WithOnClick(OnButtonClick)
                .AddTo(container);

            this
                .WithLabel(label)
#if UNITY_6000_6_OR_NEWER
                .WithVisualInput(container);
#else
                .WithVisualInput<EditableLabelField, string>(container);
#endif
        }

        //-----------------------------------------------------------
        // We need to work with the TextField value internally,
        // but for the outer world, the EditableLabelField
        // should look like if it owns the value.
        //
        // Luckily, the parent BaseField<string> has the value
        // property, so we can use it to fake the ownership.
        //
        // 1. Get and set the TextField value
        public override string value {
            get => _textField.value;
            set => _textField.value = value; // Triggers OnTextFieldValueChange
        }

        // 2. Subscribe to the TextField value change event.
        // Update the base value, so EditableLabelField
        // triggers the change event, and stop propagation
        // of the TextField event to avoid notifying the
        // EditableLabelField value change listeners twice.
        void OnTextFieldValueChanged(ChangeEvent<string> evt) {
            evt.StopImmediatePropagation();
            base.value = evt.newValue;
        }

        // 3. Update both values without notifying the listeners
        public override void SetValueWithoutNotify(string newValue) {
            _textField.SetValueWithoutNotify(newValue);
            base.SetValueWithoutNotify(newValue);
        }
        //-----------------------------------------------------------

        //-----------------------------------------------------------
        // In case the TextElement of the TextField is focused,
        // clicking anything outside it should unfocus it,
        // including clicking the Edit Button. By default,
        // unfocusing happens before the ClickEvent of the Button,
        // so clicking the Button unfocuses it on mouse button
        // press and then immediately focuses it on release,
        // which is not the desired behavior.
        //
        // The order of events in this case is:
        // - PointerDownEvent on the Button
        // - FocusOutEvent on the TextElement
        // - ClickEvent of the Button
        //
        // This means that we can use the PointerDownEvent to
        // check whether TextElement is focused. Looks like
        // checking hasFocusPseudoState is enough.
        //
        // We also need the PointerCancelEvent and the PointerLeaveEvent
        // to handle the edge cases when the PointerDownEvent happened
        // but the user didn't end up actually clicking the button.

        // 1. Detect whether the Button was clicked while the TextField was focused.
        void OnButtonPointerDown(PointerDownEvent evt) =>
            _textField.WithOnTextElement(this, (textElement, thisElement) => {
                if (!textElement.hasFocusPseudoState)
                    return;

                thisElement._didButtonClickStartWhileTextFieldWasFocused = true;
            });

        // 2. Make the TextField read-only when it loses focus.
        void OnTextElementFocusOut(FocusOutEvent evt) => MakeTextFieldReadOnlyIfNeeded(_textField);

        // 3. Reset the Button click state when the Button is canceled or left.
        void OnButtonPointerCancel(PointerCancelEvent evt) => _didButtonClickStartWhileTextFieldWasFocused = false;
        void OnButtonPointerLeave(PointerLeaveEvent evt) => _didButtonClickStartWhileTextFieldWasFocused = false;

        // 4. Process the Button click only if the TextField wasn't focused.
        void OnButtonClick(ClickEvent evt) {
            if (_didButtonClickStartWhileTextFieldWasFocused) {
                _didButtonClickStartWhileTextFieldWasFocused = false;
                return;
            }

            MakeTextFieldReadOnlyIfNeeded(_textField);
            MakeTextFieldEditableIfNeeded(_textField);
        }
        //-----------------------------------------------------------


        //-----------------------------------------------------------
        // Switch styles of the TextField to make it look like a
        // label in one case, and like a normal TextField in the other.
        static void MakeTextFieldReadOnlyIfNeeded(TextField textField) => textField
            .WithCondition(
                condition: textField.isReadOnly,
                onFalse: static textField => textField
                    .AsReadOnly()
                    .WithOnTextInput(static textInput => textInput
                        .WithBackgroundColor(Color.clear) // Remove the color
                        .WithBorderWidth(0)
                        .WithMargin(1))); // Compensate for border, so the text stays in the same place.

        static void MakeTextFieldEditableIfNeeded(TextField textField) => textField
            .WithCondition(
                condition: textField.isReadOnly,
                onTrue: static textField => textField
                    .AsReadOnly(false)
                    .WithOnTextInput(static textInput => textInput
                        .WithBackgroundColor(StyleKeyword.Null) // Get the original color
                        .WithBorderWidth(1)
                        .WithMargin(0)) // Remove the border compensation.
                    .WithOnTextElement(textElement => textElement.WithFocus()));
        //-----------------------------------------------------------
    }
}