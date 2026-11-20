using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using static System.String;
using static UnityEditor.EditorUtility;

namespace AssetCacheCleaner {
    internal class AssetCacheCleanerWindow : EditorWindow {
        const string _bannerPath = "Packages/com.vklubkov.assetcachecleaner/Editor Resources/Banner.png";

        readonly Preferences _preferences = new();
        readonly Assets _assets = new();

        Texture2D _bannerImage;

        VisualElement _mainContainer;
        VisualElement _banner;
        EditableLabelField _cachePath;
        MultiColumnListView _assetsList;

        [MenuItem("Tools/Asset Cache Cleaner")]
        static void ShowWindow() {
            var window = GetWindow<AssetCacheCleanerWindow>();
            window.minSize = new Vector2(600, 400);
            window.titleContent = new GUIContent("Asset Cache Cleaner");
        }

        public void CreateGUI() {
            RefreshAssets();
            ClearRootVisualElement();
            CreateBanner();
            CreateRoot();
            CreateSettings();
            CreateHeader();
            CreateAssets();
        }

        void ClearRootVisualElement() => rootVisualElement
            .AsClear()
            .WithFlexDirection(FlexDirection.Column)
            .WithFlexGrow(1);

        void CreateBanner() {
            if (!_preferences.ShowBanner)
                return;

            CreateBanner(rootVisualElement);
        }

        void CreateRoot() => _mainContainer = New
            .VisualElement()
            .WithPadding(8)
            .WithFlexDirection(FlexDirection.Column)
            .WithFlexGrow(1)
            .AddTo(rootVisualElement);

        void CreateSettings() {
            var settings = New
                .VisualElement()
                .WithFlexDirection(FlexDirection.Column)
                .WithFlexShrink(0)
                .AddTo(_mainContainer);

            var togglesRow = New
                .VisualElement()
                .WithFlexDirection(FlexDirection.Row)
                .WithFlexGrow(1)
                .AddTo(settings);

            New
                .Toggle("Show banner")
                .WithOnLabelElement(label => label
                    .WithMarginTop(1)
                    .WithMinWidth(0)
                    .WithMarginRight(15))
                .WithValueWithoutNotify(_preferences.ShowBanner)
                .WithOnValueChanged(OnShowBannerChanged)
                .AddTo(togglesRow);

            New
                .Toggle("Show confirmation dialog")
                .WithTooltip("Show confirmation dialog before removing assets")
                .WithOnLabelElement(label => label
                    .WithMarginTop(1)
                    .WithMinWidth(0)
                    .WithMarginRight(15))
                .WithValueWithoutNotify(_preferences.ShowConfirmation)
                .WithOnValueChanged(OnShowConfirmationChanged)
                .WithMarginLeft(30)
                .AddTo(togglesRow);

            var container = New
                .VisualElement()
                .WithFlexDirection(FlexDirection.Row)
                .WithFlexGrow(1)
                .WithMarginRight(3)
                .AddTo(settings);

            _cachePath = New
                .EditableLabelField()
                .WithLabel("Asset Store Cache path:")
                .WithOnLabelElement<EditableLabelField, string>(label => label
                    .WithMarginTop(1)
                    .WithMinWidth(150)
                    .WithFontStyleAndWeight(FontStyle.Bold))
                .WithValueWithoutNotify(_preferences.AssetStoreCachePath)
                .WithOnValueChanged(OnAssetStoreCachePathChanged)
                .WithFlexGrow(1)
                .WithMarginRight(0)
                .AddTo(container);

            New
                .SquaredButton()
                .WithText("...")
                .WithTooltip("Select the Asset Store Cache folder")
                .WithMarginTopBottom(2)
                .WithMarginLeftRight(2, 0)
                .WithOnClick(OnSelectFolderButtonClick)
                .AddTo(container);

            New
                .VisualElement()
                .WithBackgroundColor(Color.gray5)
                .WithHeight(2)
                .WithMarginTopBottom(5)
                .WithAlignSelf(Align.Center)
                .WithWidth(new StyleLength(Length.Percent(100)))
                .AddTo(settings);
        }

        void OnShowBannerChanged(ChangeEvent<bool> changeEvent) =>
            CreateOrRemoveBannerIfNeeded(_preferences.ShowBanner = changeEvent.newValue);

        void CreateOrRemoveBannerIfNeeded(bool showBanner) => rootVisualElement
            .WithCondition(condition: _banner == null && showBanner, onTrue: CreateBanner)
            .WithCondition(condition: _banner != null && !showBanner, onTrue: RemoveBanner);

        void CreateBanner(VisualElement parent) {
            if (_bannerImage == null)
                _bannerImage = AssetDatabase.LoadAssetAtPath<Texture2D>(_bannerPath);

            if (_bannerImage == null)
                return;

            _banner = New
                .Image()
                .WithImage(_bannerImage)
                .WithScaleMode(ScaleMode.ScaleToFit)
                .WithAspectRatio((float)_bannerImage.width / _bannerImage.height)
                .WithFlexShrink(0)
                .InsertInto(parent, atIndex: 0);
        }

        void RemoveBanner(VisualElement parent) {
            _banner?.Remove();
            _banner = null;
        }

        void OnShowConfirmationChanged(ChangeEvent<bool> changeEvent) =>
            _preferences.ShowConfirmation = changeEvent.newValue;

        void OnAssetStoreCachePathChanged(ChangeEvent<string> changeEvent) {
            _preferences.AssetStoreCachePath = changeEvent.newValue;
            _cachePath.SetValueWithoutNotify(_preferences.AssetStoreCachePath);
            RefreshAssetsAndRebuildList();
        }

        void RefreshAssetsAndRebuildList() {
            RefreshAssets();
            _assetsList.WithRebuild();
        }

        void RefreshAssets() => _assets.Refresh(_preferences.AssetStoreCachePath);

        void OnSelectFolderButtonClick(ClickEvent evt) {
            var cachePath = _preferences.AssetStoreCachePath;
            var defaultFolder = IsNullOrEmpty(cachePath) ? Application.dataPath : cachePath;
            var result = OpenFolderPanel("Select Asset Store Cache folder", defaultFolder, "");
            if (IsNullOrEmpty(result))
                return;

            _cachePath.value = result;
        }

        void CreateHeader() {
            var headerContainer = New
                .VisualElement()
                .WithFlexGrow(0)
                .WithMinHeight(21)
                .WithFlexDirection(FlexDirection.Row)
                .AddTo(_mainContainer);

            New
                .Label("Downloaded assets")
                .WithFontSize(18)
                .WithTextAlign(TextAnchor.MiddleCenter)
                .WithFontStyleAndWeight(FontStyle.Bold)
                .WithFlexGrow(1)
                .AddTo(headerContainer);

            New
                .Button()
                .WithText("Remove all")
                .WithTooltip("Remove all assets from disk")
                .WithBackgroundColor(Palette.Background.Negative.Color)
                .WithPosition(Position.Absolute)
                .WithMinWidth(89)
                .WithMinHeight(19)
                .WithOnClick(OnRemoveAllButtonClick)
                .AddTo(headerContainer);

            New
                .SquaredButton()
                .WithText("↻")
                .WithTooltip("Refresh the assets from disk")
                .WithBackgroundColor(Palette.Background.Neutral.Color)
                .WithPosition(Position.Absolute)
                .WithRight(0)
                .WithMinHeight(19)
                .WithOnClick(OnRefreshButtonClick)
                .AddTo(headerContainer);
        }

        void OnRemoveAllButtonClick(ClickEvent evt) {
            if (_assets.AssetsInfo.Count == 0)
                return;

            var shouldRemove = !_preferences.ShowConfirmation || EditorUtility.DisplayDialog(
                "Confirm Asset Removal",
                "Are you sure you want to remove all assets " +
                "from the Asset Store cache folder on your disk?\n\n" +
                "You will need to re-download the assets from the Asset Store whenever you need them again.\n\n" +
                "Assets in your project(s) are untouched.",
                "Remove", "Cancel");

            if (!shouldRemove)
                return;

            _assets.RemoveAll();
            _assetsList.WithRebuild();
        }

        void OnRefreshButtonClick(ClickEvent evt) => RefreshAssetsAndRebuildList();

        void CreateAssets() => _assetsList = New
            .MultiColumnListView(new Columns())
            .AsReorderable()
            .WithItemsSource(_assets.AssetsInfo)
            .WithSortingMode(ColumnSortingMode.Custom)
            .WithAlternatingRowBackgrounds(AlternatingRowBackground.All)
            .WithFlexGrow(1)
            .WithMinWidth(572)
            .WithOnGeometryChanged(static (_, thisElement) =>
                thisElement.WithOnScrollView(static scrollView =>
                    scrollView.WithMode(ScrollViewMode.VerticalAndHorizontal)))
            .WithOnColumns(data: this, static (columns, thisWindow) => {
                New
                    .Column()
                    .AsSortable(false)
                    .WithName("Action")
                    .WithMinWidth(80)
                    .WithMakeCell(OnRemoveButtonColumnMakeCell)
                    .WithBindCell(thisWindow.OnRemoveButtonColumnBindCell)
                    .AddTo(columns);

                New
                    .Column()
                    .AsSortable(true)
                    .AsStretchable(true)
                    .WithName("Asset")
                    .WithTitle("Asset")
                    .WithMinWidth(100)
                    .WithMakeCell(OnAssetColumnMakeCell)
                    .WithBindCell(thisWindow.OnAssetColumnBindCell)
                    .AddTo(columns);

                New
                    .Column()
                    .AsSortable(true)
                    .AsStretchable(true)
                    .WithName("Publisher")
                    .WithTitle("Publisher")
                    .WithMinWidth(100)
                    .WithMakeCell(OnPublisherColumnMakeCell)
                    .WithBindCell(thisWindow.OnPublisherColumnBindCell)
                    .AddTo(columns);
            })
            .WhenColumnSortingChanged(OnColumnSortingChanged)
            .WithRebuild()
            .AddTo(_mainContainer);

        static VisualElement OnRemoveButtonColumnMakeCell() => New
            .Button()
            .WithText("Remove")
            .WithTooltip("Remove the assets from disk")
            .WithBackgroundColor(Palette.Background.Negative.Color);

        void OnRemoveButtonColumnBindCell(VisualElement element, int index) {
            if (element is not Button button)
                return;

            button.WithOnClick(index, OnRemoveButtonClick);
        }

        void OnRemoveButtonClick(ClickEvent evt, int index) {
            var asset = _assets.GetAsset(index);
            if (IsNullOrEmpty(asset))
                return;

            var shouldRemove = !_preferences.ShowConfirmation || DisplayDialog(
                "Confirm Asset Removal",
                $"Are you sure you want to remove\n\n   {asset}\n\n" +
                "from the Asset Store cache folder on your disk?\n\n" +
                "You will need to re-download the asset from the Asset Store whenever you need it again.\n\n" +
                "Assets in your project(s) are untouched.",
                "Remove", "Cancel");

            if (!shouldRemove)
                return;

            _assets.Remove(index);
            _assetsList.WithRebuild();
        }

        static VisualElement OnAssetColumnMakeCell() => New.SelectableLabel();

        void OnAssetColumnBindCell(VisualElement element, int index) {
            if (element is not SelectableLabel label)
                return;

            label.WithValue(_assets.GetAsset(index));
        }

        static VisualElement OnPublisherColumnMakeCell() => New.SelectableLabel();

        void OnPublisherColumnBindCell(VisualElement element, int index) {
            if (element is not SelectableLabel label)
                return;

            label.WithValue(_assets.GetPublisher(index));
        }

        void OnColumnSortingChanged() {
            var sortedColumns = _assetsList.sortedColumns.ToArray();
            if (sortedColumns.Length is 0 or > 2)
                return;

            var firstColumn = sortedColumns[0];
            if (sortedColumns.Length == 1) {
                if (firstColumn.columnName == "Asset")
                    _assets.SortByAsset(firstColumn.direction);
                else if (firstColumn.columnName == "Publisher")
                    _assets.SortByPublisher(firstColumn.direction);
            }
            else {
                var secondColumn = sortedColumns[1];
                if (firstColumn.columnName == "Asset" && secondColumn.columnName == "Publisher")
                    _assets.SortByAssetThenPublisher(firstColumn.direction, secondColumn.direction);
                else if (firstColumn.columnName == "Publisher" && secondColumn.columnName == "Asset")
                    _assets.SortByPublisherThenByAsset(firstColumn.direction, secondColumn.direction);
            }

            _assetsList.WithRefreshItems();
        }
    }
}