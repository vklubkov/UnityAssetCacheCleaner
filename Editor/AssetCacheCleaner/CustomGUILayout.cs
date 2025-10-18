using UnityEditor;
using UnityEngine;

namespace AssetCacheCleaner {
	internal static class CustomGUILayout {
		static readonly GUILayoutOption[] _expandWidth = { GUILayout.ExpandWidth(true) };

		public static void Image(Texture2D texture) {
			if (texture == null)
				return;

			EditorGUILayout.Space();
			var textureAspect = (float)texture.width / texture.height;
			var textureRect = GUILayoutUtility.GetAspectRect(textureAspect, _expandWidth);
			EditorGUI.DrawPreviewTexture(textureRect, texture);
			EditorGUILayout.Space();
		}
	}
}