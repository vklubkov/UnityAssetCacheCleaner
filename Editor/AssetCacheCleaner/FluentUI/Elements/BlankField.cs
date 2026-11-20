using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public class BlankField<T> : BaseField<T> {
        public BlankField() : base(null, null) { }
        public BlankField(string label, VisualElement visualInput) : base(label, visualInput) { }
    }

    public class BlankField : BlankField<ValueTuple> {
        public BlankField() : base(null, null) { }
        public BlankField(string label, VisualElement visualInput) : base(label, visualInput) { }
    }
}