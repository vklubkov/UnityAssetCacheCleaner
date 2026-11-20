using UnityEditor;
using UnityEngine;
// ReSharper disable MemberHidesStaticFromOuterClass
// ReSharper disable PartialTypeWithSinglePart

namespace AssetCacheCleaner {
    public static partial class Palette {
        public static partial class Hover {
            public static partial class Background {
                public static partial class Neutral {
                    public static Color Color =>
                        EditorGUIUtility.isProSkin
                            ? DarkTheme.Hover.Background.Neutral.Color
                            : LightTheme.Hover.Background.Neutral.Color;
                }
            }
        }

        public static partial class Background {
            public static partial class Neutral {
                public static Color Color =>
                    EditorGUIUtility.isProSkin
                        ? DarkTheme.Background.Neutral.Color
                        : LightTheme.Background.Neutral.Color;
            }
        }

        public static partial class DarkTheme {
            public static partial class Hover {
                public static partial class Background {
                    public static partial class Neutral {
                        public static Color Color => new(0.3f, 0.5f, 0.8f);
                    }
                }
            }

            public static partial class Background {
                public static partial class Neutral {
                    public static Color Color => new(0.2f, 0.4f, 0.7f);
                }
            }
        }


        public static partial class LightTheme {
            public static partial class Hover {
                public static partial class Background {
                    public static partial class Neutral {
                        public static Color Color => new(0.3f, 0.5f, 0.9f);
                    }
                }
            }

            public static partial class Background {
                public static partial class Neutral {
                    public static Color Color => new(0.2f, 0.5f, 0.8f);
                }
            }
        }
    }
}