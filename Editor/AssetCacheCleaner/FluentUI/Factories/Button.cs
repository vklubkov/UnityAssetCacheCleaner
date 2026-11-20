using System;
using JetBrains.Annotations;
using UnityEngine.UIElements;

namespace AssetCacheCleaner {
    public static partial class New {
        [NotNull] public static Button Button() => new();
        [NotNull] public static Button Button(Action clickEvent) => new(clickEvent);

        [NotNull] public static Button Button(
            Background iconImage, Action clickEvent = null) =>
                new(iconImage, clickEvent);
    }
}