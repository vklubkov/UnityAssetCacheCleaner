using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AssetRemover {
    internal class AssetRemoverWindow : EditorWindow {
        const string _editorPrefsAssetStoreCachePathKey = "AssetRemover_AssetStoreCachePath";

        string _cachePath = string.Empty;
        readonly SortedList<string, (string Publisher, string Path)> _assets = new();
        Vector2 _scrollPosition = Vector2.zero;

        [MenuItem("Tools/Asset Remover")]
        static void ShowWindow() {
            var window = GetWindow<AssetRemoverWindow>();
            window.minSize = new Vector2(500, 600);
            window.titleContent = new GUIContent("Asset Remover");
            window.UpdateAssetStoreCachePath();
            window.UpdatePackagesList();
        }

        void UpdateAssetStoreCachePath() {
            _cachePath = EditorPrefs.GetString(_editorPrefsAssetStoreCachePathKey);
            if (Directory.Exists(_cachePath))
                return;

#if UNITY_EDITOR_WIN
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _cachePath = Path.Combine(appData, "Unity", "Asset Store-5.x");
#elif UNITY_EDITOR_OSX
            // NOTE: not tested on OS X!
            _cachePath = "~/Library/Unity/Asset Store-5.x";
#elif UNITY_EDITOR_LINUX
            var userProfile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
            _cachePath = Path.Combine(userProfile, ".local/share/unity3d/Asset Store-5.x");
#endif
        }

        void UpdatePackagesList() {
            if (!Directory.Exists(_cachePath))
                return;

            var directories = Directory.GetDirectories(_cachePath);
            foreach (var directory in directories) {
                var publisher = Path.GetFileName(directory);
                var subDirectories = Directory.GetDirectories(directory);
                foreach (var subDirectory in subDirectories) {
                    var files = Directory.GetFiles(subDirectory);
                    foreach (var file in files) {
                        if (file.EndsWith(".unitypackage")) {
                            var asset = Path.GetFileNameWithoutExtension(file);
                            _assets[asset] = (publisher, file);
                        }
                    }
                }
            }
        }

        void OnGUI() {
            EditorGUILayout.Space(15);
            EditorGUILayout.BeginVertical();

            _cachePath = EditorGUILayout.TextField("Asset Store Cache path", _cachePath);
            if (GUILayout.Button("Update Asset List from path")) {
                _assets.Clear();
                _scrollPosition = Vector2.zero;
                EditorPrefs.SetString(_editorPrefsAssetStoreCachePathKey, _cachePath);
                UpdatePackagesList();
            }

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space(15);
            _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

            foreach (var (key, value) in _assets.ToList()) {
                EditorGUILayout.BeginHorizontal();

                if (GUILayout.Button("Remove")) {
                    File.Delete(value.Path);
                    _assets.Remove(key);
                }

                GUILayout.Label(key + " by " + value.Publisher);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUILayout.EndScrollView();
        }
    }
}