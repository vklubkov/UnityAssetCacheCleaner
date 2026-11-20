using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    // Sealed because the constructor contains the virtual member calls.
    public sealed class SelectableLabel : TextField {
        public SelectableLabel() => Setup(this);
        public SelectableLabel(string text) => Setup(this).WithValue(text);

        static SelectableLabel Setup(SelectableLabel element) => element
            .AsSelectableLabel()
            .WithWhiteSpace(WhiteSpace.NoWrap)
            .WithSelectAllOnFocus(false)
            .WithSelectAllOnMouseUp(false);
    }
}