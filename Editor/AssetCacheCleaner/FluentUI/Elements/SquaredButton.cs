using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    // Sealed because the constructors contain the virtual member calls.
    public sealed class SquaredButton : Button {
        public SquaredButton(Action clickEvent = null) : base(clickEvent) => Setup(this);
        public SquaredButton(string text, Action clickEvent = null) : base(clickEvent) => Setup(this).WithText(text);

        static SquaredButton Setup(SquaredButton element) => element
            .WithPadding(0) // Remove the default button padding
            .WithOnGeometryChanged(static evt => {
                var button = (Button)evt.currentTarget;
                var height = evt.newRect.height;
                button.WithMinWidth(width: height > 0 ? height : 0);
            });
    }
}