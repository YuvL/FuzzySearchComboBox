using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using Timer = System.Timers.Timer;

// ReSharper disable once CheckNamespace

namespace Controls.FuzzySearchComboBox
{
    public partial class FuzzySearchCombobox : INotifyPropertyChanged
    {
        public new static readonly DependencyProperty NameProperty = DependencyProperty.Register("Name", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("FuzzySearchCombobox"));
        /// <summary>
        /// Name for this control (Property added to facilitate automated testing)
        /// </summary>
        public new string Name
        { get { return (string)GetValue(NameProperty); } set { SetValue(NameProperty, value); } }

        public static readonly DependencyProperty EmptyResultHeaderProperty = DependencyProperty.Register("EmptyResultHeader", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("Empty"));
        /// <summary>
        /// Header for empty search result
        /// </summary>
        public string EmptyResultHeader
        { get { return (string)GetValue(EmptyResultHeaderProperty); } set { SetValue(EmptyResultHeaderProperty, value); } }

        public static readonly DependencyProperty AllResultHeaderProperty = DependencyProperty.Register("AllResultHeader", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("All"));
        /// <summary>
        /// Header for all search result
        /// </summary>
        public string AllResultHeader
        { get { return (string)GetValue(AllResultHeaderProperty); } set { SetValue(AllResultHeaderProperty, value); } }

        public static readonly DependencyProperty StrongResultHeaderProperty = DependencyProperty.Register("StrongResultHeader", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("Strong"));
        /// <summary>
        /// Header for alphabetically search result
        /// </summary>
        public string StrongResultHeader
        { get { return (string)GetValue(StrongResultHeaderProperty); } set { SetValue(StrongResultHeaderProperty, value); } }

        public static readonly DependencyProperty FuzzyResultHeaderProperty = DependencyProperty.Register("FuzzyResultHeader", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("Fuzzy"));
        /// <summary>
        /// Header for fuzzy search result
        /// </summary>
        public string FuzzyResultHeader
        { get { return (string)GetValue(FuzzyResultHeaderProperty); } set { SetValue(FuzzyResultHeaderProperty, value); } }

        public static readonly DependencyProperty RenamedResultHeaderProperty = DependencyProperty.Register("RenamedResultHeader", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("Renamed"));
        /// <summary>
        /// Header for renamed search result
        /// </summary>
        public string RenamedResultHeader
        { get { return (string)GetValue(RenamedResultHeaderProperty); } set { SetValue(RenamedResultHeaderProperty, value); } }

        public static readonly DependencyProperty ShowAllButtonTextProperty = DependencyProperty.Register("ShowAllButtonText", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("ShowAll"));
        /// <summary>
        /// Text for ShowAll button
        /// </summary>
        public string ShowAllButtonText
        { get { return (string)GetValue(ShowAllButtonTextProperty); } set { SetValue(ShowAllButtonTextProperty, value); } }

        public static readonly DependencyProperty FilteredByLabelProperty = DependencyProperty.Register("FilteredByLabel", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata("Filtered by:"));
        /// <summary>
        /// Label for "filtered by" panel
        /// </summary>
        public string FilteredByLabel
        { get { return (string)GetValue(FilteredByLabelProperty); } set { SetValue(FilteredByLabelProperty, value); } }


        public ResultItem AlwaysShow { get; private set; }

        public int BounceProtectionDelay { get; set; }

        public Dictionary<int?, ValueContainer> ChildItems
        {
            get { return (Dictionary<int?, ValueContainer>)GetValue(ChildItemsProperty); }
            set
            {
                SetValue(ChildItemsProperty, value);
                OnPropertyChanged("ChildItems");
            }
        }

        public Dictionary<int?, ValueContainer> ChildItemsSource
        {
            get { return (Dictionary<int?, ValueContainer>)GetValue(ChildItemsSourceProperty); }
            set
            {
                SetValue(ChildItemsSourceProperty, value);
                OnPropertyChanged("ChildItemsSource");
            }
        }

        public static IEnumerable<FuzzySearchCombobox> Comboboxes { get; private set; }

        public int CountToOutputValues { get { return (int)GetValue(CountToOutputValuesProperty); } set { SetValue(CountToOutputValuesProperty, value); } }

        public int DropDownMinWidth { get; set; }

        public string Filters
        {
            get
            {
                if (string.IsNullOrEmpty(GroupName))
                {
                    return string.Empty;
                }

                var dependentComboboxes = GetDependentComboboxes(this);
                //SelectedItem with PredefinedKey do not used in filters
                var filterdBy = dependentComboboxes
                    .Where(combobox => combobox.SelectedItem != null && combobox.SelectedItem.Value.Value != null && combobox.SelectedItem.Value.Key != PredefinedKey)
                    .Select(combobox => combobox.SelectedItem.Value.Value.ToString());

                var filters = string.Join("; ", filterdBy);
                return filters;
            }
        }

        public string GroupName { get; set; }

        public bool IsSearches
        {
            get { return _isSearches; }
            set
            {
                _isSearches = value;
                OnPropertyChanged("IsSearches");
            }
        }

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set
            {
                SetValue(IsValidProperty, value);

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValid"));
            }
        }

        public Dictionary<int, string> ItemsSource
        {
            get { return (Dictionary<int, string>)GetValue(ItemsSourceProperty); }
            set
            {
                SetValue(ItemsSourceProperty, value);
                OnPropertyChanged("ItemsSource");
            }
        }

        public int MaxDropDownListHeight
        {
            get { return (int)GetValue(MaxDropDownListHeightProperty); }
            set
            {
                SetValue(MaxDropDownListHeightProperty, value);
                OnPropertyChanged("MaxDropDownListHeight");
            }
        }

        public bool NoData
        {
            get { return _noData; }
            private set
            {
                _noData = value;
                OnPropertyChanged("NoData");
            }
        }

        public string NoDataText { get { return (string)GetValue(NoDataTextProperty); } set { SetValue(NoDataTextProperty, value); } }

        public Dictionary<int?, ValueContainer> ParentItems
        {
            get { return (Dictionary<int?, ValueContainer>)GetValue(ParentItemsProperty); }
            set
            {
                SetValue(ParentItemsProperty, value);
                OnPropertyChanged("ParentItems");
            }
        }

        public Dictionary<int?, ValueContainer> ParentItemsSource
        {
            get { return (Dictionary<int?, ValueContainer>)GetValue(ParentItemsSourceProperty); }
            set
            {
                SetValue(ParentItemsSourceProperty, value);
                OnPropertyChanged("ParentItemsSource");
            }
        }

        public List<ResultItem> SearchResult { get; set; }

        public ICollectionView SearchResultCollection { get { return (ICollectionView)GetValue(SearchResultCollectionProperty); } set { SetValue(SearchResultCollectionProperty, value); } }

        public KeyValuePair<int?, ValueContainer>? SelectedItem
        {
            get { return (KeyValuePair<int?, ValueContainer>?)GetValue(SelectedItemProperty); }
            set
            {
                SetValue(SelectedItemProperty, value);
                OnPropertyChanged("SelectedItem");
            }
        }

        public int? SelectedKey
        {
            get { return (int?)GetValue(SelectedKeyProperty); }
            set
            {
                SetValue(SelectedKeyProperty, value);
                OnPropertyChanged("SelectedKey");
            }
        }

        public ValueContainer SelectedValue
        {
            get { return (ValueContainer)GetValue(SelectedValueProperty); }
            set
            {
                SetValue(SelectedValueProperty, value);
                OnPropertyChanged("SelectedValue");
            }
        }

        public bool ShowDeletedItems
        {
            get { return (bool)GetValue(ShowDeletedItemsProperty); }
            set { SetValue(ShowDeletedItemsProperty, value); }
        }

        public string Text { get { return (string)GetValue(TextProperty); } set { SetValue(TextProperty, value); } }

        private const int DefaultBounceProtectionDelay = 200;
        private const double DefaultFuzziness = 0.35;
        private const int DefaultMaxDropDownHeight = 280;
        private const int DefaultNumberOutputValues = 8;

        private const string NoDataTextDefault = "- Нет данных для отображения -";
        public static readonly ILogger Logger = LoggerFactory.GetLogger();
        private static readonly char[] WordSplitters = "\t,.; ".ToCharArray();

        public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register("ItemsSource", typeof(Dictionary<int, string>), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(Dictionary<int, string>), ItemsSourcePropertyChangedCallback));

        public static readonly DependencyProperty ParentItemsSourceProperty = DependencyProperty.Register("ParentItemsSource", typeof(Dictionary<int?, ValueContainer>), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(Dictionary<int?, ValueContainer>), ParentItemSourceChangedCallBack));

        public static readonly DependencyProperty ChildItemsSourceProperty = DependencyProperty.Register("ChildItemsSource", typeof(Dictionary<int?, ValueContainer>), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(Dictionary<int?, ValueContainer>), ChildItemSourceChangedCallBack));

        public static readonly DependencyProperty InternalItemsSourceProperty = DependencyProperty.Register("InternalItemsSource", typeof(Dictionary<int?, ValueContainer>), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(Dictionary<int?, ValueContainer>), InternalItemsSourceChangedCallBack));

        public static readonly DependencyProperty CheckedProperty = DependencyProperty.Register("Checked", typeof(bool), typeof(FuzzySearchCombobox), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty ChildItemsProperty = DependencyProperty.Register("Childs", typeof(Dictionary<int?, ValueContainer>), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(Dictionary<int?, ValueContainer>)));

        public static readonly DependencyProperty CountToOutputValuesProperty = DependencyProperty.Register("CountToOutputValues", typeof(int), typeof(FuzzySearchCombobox), new UIPropertyMetadata(DefaultNumberOutputValues));

        public static readonly DependencyProperty IsValidProperty = DependencyProperty.Register("IsValid", typeof(bool), typeof(FuzzySearchCombobox), new PropertyMetadata(true));

        public static readonly DependencyProperty MaxDropDownListHeightProperty = DependencyProperty.Register("MaxDropDownListHeight", typeof(int), typeof(FuzzySearchCombobox), new PropertyMetadata(DefaultMaxDropDownHeight));

        public static readonly DependencyProperty ParentItemsProperty = DependencyProperty.Register("ParentItems", typeof(Dictionary<int?, ValueContainer>), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(Dictionary<int?, ValueContainer>)));

        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register("SelectedItem", typeof(KeyValuePair<int?, ValueContainer>?), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(KeyValuePair<int?, ValueContainer>?), SelectedItemChangedCallBack));

        public static readonly DependencyProperty SelectedKeyProperty = DependencyProperty.Register("SelectedKey", typeof(int?), typeof(FuzzySearchCombobox), new PropertyMetadata(default(int?), SelectedKeyChangedCallBack));

        public static readonly DependencyProperty SearchResultCollectionProperty = DependencyProperty.Register("SearchResultCollection", typeof(ICollectionView), typeof(FuzzySearchCombobox),
            new PropertyMetadata(default(ICollectionView)));

        public static readonly DependencyProperty SelectedValueProperty = DependencyProperty.Register("SelectedValue", typeof(ValueContainer), typeof(FuzzySearchCombobox), new PropertyMetadata(default(ValueContainer)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata(default(string), TextPropertyChangedCallback));

        public static readonly DependencyProperty NoDataTextProperty = DependencyProperty.Register("NoDataText", typeof(string), typeof(FuzzySearchCombobox), new PropertyMetadata(NoDataTextDefault));

        public static readonly DependencyProperty ShowDeletedItemsProperty =
            DependencyProperty.Register("ShowDeletedItems", typeof(bool), typeof(FuzzySearchCombobox), new PropertyMetadata(false));

        public static ResourceDictionary ResourceDictionary { get; set; }

        #region grop behavior............................................................................

        public bool DoAutocomplete { get; set; }

        public static readonly DependencyProperty IsValidInGroupProperty = DependencyProperty.Register("IsValidInGroup", typeof(bool), typeof(FuzzySearchCombobox), new PropertyMetadata(true));
        public bool IsValidInGroup
        {
            get { return (bool)GetValue(IsValidInGroupProperty); }
            set
            {
                SetValue(IsValidInGroupProperty, value);

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsValidInGroup"));
            }
        }

        
        private static void TryParentsAutoComplete(FuzzySearchCombobox combobox)
        {
            //if Autocomplete do not needed
            if (!combobox.DoAutocomplete)
                return;
            //If a predefined item is selected
            if (IsPredefinedItem(combobox.SelectedItem))
                return;

            var binding = combobox.GetBindingExpression(ParentItemsSourceProperty);
            var parentCombobox = binding.DataItem as FuzzySearchCombobox;

            if (IsParentalControlRequiresAutocomplete(parentCombobox))
            {
                var internalItemsSource = parentCombobox.InternalItemsSource;

                if (internalItemsSource != null && internalItemsSource.Count(x => !x.Value.IsDeleted) == 1)
                {
                    //Do autocomplete only using not deleted items
                    parentCombobox.SetSelectedItem(internalItemsSource.FirstOrDefault(x => !x.Value.IsDeleted));
                }
            }
        }

        private static bool IsParentalControlRequiresAutocomplete(FuzzySearchCombobox combobox)
        {
            //Do not autocomplete if SelectedItem is not null: perhaps this is item with isDeleted==true
            return combobox != null && combobox.SelectedItem == null;
        }

        private static void UpdateGroupValidation(FuzzySearchCombobox combobox)
        {
            if (!combobox.DoAutocomplete)
                return;

            var dependentComboboxes = GetGroupComboboxes(combobox).ToList();

            foreach (var item in dependentComboboxes)
            {
                var bindingChild = item.GetBindingExpression(ChildItemsSourceProperty);
                var bindingParent = item.GetBindingExpression(ParentItemsSourceProperty);

                var childCombobox = bindingChild != null ? bindingChild.DataItem as FuzzySearchCombobox : null;
                var parentCombobox = bindingParent != null ? bindingParent.DataItem as FuzzySearchCombobox : null;

                if (childCombobox == null && parentCombobox == null)
                    continue;

                //the lowest level always in the group is valid (City)
                if (parentCombobox != null && childCombobox == null)
                    continue;

                //the highest level (Country)
                if (parentCombobox == null && childCombobox != null)
                {
                    item.IsValidInGroup = item.SelectedItem != null || (childCombobox.SelectedItem == null && childCombobox.IsValidInGroup);
                    continue;
                }

                //middle level
                var validForChild = childCombobox.SelectedItem == null || item.SelectedItem != null;
                var validForParent = parentCombobox.SelectedItem != null && item.SelectedItem != null;
                item.IsValidInGroup = item.SelectedItem == null ? validForChild : validForChild || validForParent;
            }
        }

        #endregion............................................................................................

        #region Functionality associated with the presence in the data of a predefined element...

        private const int PredefinedKey = -1;

        private static bool IsPredefinedItem(KeyValuePair<int?, ValueContainer>? item)
        {
            return item != null && item.Value.Key == PredefinedKey;
        }

        public static readonly DependencyProperty PredefinedValueProperty =
            DependencyProperty.Register("PredefinedValue", typeof(string), typeof(FuzzySearchCombobox),
                new PropertyMetadata(default(string)));

        /// <summary>
        /// Predefined Value in DataSource of this control. This value will be added to DataSource, that is binding with this control.
        /// </summary>
        public string PredefinedValue
        {
            get { return (string)GetValue(PredefinedValueProperty); }
            set { SetValue(PredefinedValueProperty, value); }
        }

        private void AddPredefinedValueToResult(List<ResultItem> result)
        {
            string predefinedValue = null;
            Application.Current.Dispatcher.Invoke(new Action(() => { predefinedValue = PredefinedValue; }));

            if (String.IsNullOrEmpty(predefinedValue))
                return;
            if (result.Any(x => x.Key == PredefinedKey))
                return;

            ValueContainer container = new ValueContainer(PredefinedKey, predefinedValue);
            result.Insert(0, new ResultItem(new KeyValuePair<int?, ValueContainer>(PredefinedKey, container)));
        }



        #endregion.............................................................................................

        static FuzzySearchCombobox()
        {
            EventManager.RegisterClassHandler(typeof(FuzzySearchCombobox), Mouse.MouseWheelEvent, new MouseWheelEventHandler(OnMouseWheel), true);
            Comboboxes = new WeakReferenceCollection();
        }

        public FuzzySearchCombobox()
        {
            InitializeComponent();
            var weakReferenceCollection = (WeakReferenceCollection)Comboboxes;

            DataContextChanged += (sender, args) => weakReferenceCollection.ClearReferences();
            weakReferenceCollection.Add(this);

            SearchResult = new List<ResultItem>();
            SearchResultCollection = CollectionViewSource.GetDefaultView(SearchResult);
            VisualTreeParents = new List<DependencyObject>();
            _synchronizationContext = SynchronizationContext.Current;
            DataContextChanged += (sender, args) =>
            {
                if (GetBindingExpression(TextProperty) == null)
                    InputTextBox.Text = string.Empty;
                SearchResult.Clear();
                SearchResultCollection.Refresh();
            };

            Loaded += OnFuzzySearchComboboxLoaded;
            BounceProtectionDelay = DefaultBounceProtectionDelay;
            _fuzzySearchComboboxCreatedAt = DateTime.Now.ToString("HH:mm:ss.fff");
            Logger.DebugFormat(LoggingMessages.FuzzySearchComboBoxCreatedFormat, NameForDebug);

        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly Func<DependencyObject, bool> ItIsContentControl = x => x is ContentControl && !x.GetType().IsSubclassOf(typeof(ContentControl));
        private static IEnumerable<FuzzySearchCombobox> GetDependentComboboxes(FuzzySearchCombobox target)
        {
            Func<FuzzySearchCombobox, bool> inSameOrWithoutDataTemplate = combobox =>
            {
                var parentOfThisCombobox = combobox.VisualTreeParents.FirstOrDefault(ItIsContentControl);
                var parentOfOtherCombobox = target.VisualTreeParents.FirstOrDefault(ItIsContentControl);
                return ReferenceEquals(parentOfThisCombobox, parentOfOtherCombobox);
            };

            var groups = Comboboxes
                .Except(new[] { target })
                .Where(combobox => combobox.VisualTreeParents.Any(ItIsContentControl))
                .Where(inSameOrWithoutDataTemplate)
                .Where(combobox => combobox.GroupName == target.GroupName)
                .ToList();
            return groups;
        }

        private static IEnumerable<FuzzySearchCombobox> GetGroupComboboxes(FuzzySearchCombobox target)
        {
            Func<FuzzySearchCombobox, bool> inSameOrWithoutDataTemplate = combobox =>
            {
                var parentOfThisCombobox = combobox.VisualTreeParents.FirstOrDefault(ItIsContentControl);
                var parentOfOtherCombobox = target.VisualTreeParents.FirstOrDefault(ItIsContentControl);
                return ReferenceEquals(parentOfThisCombobox, parentOfOtherCombobox);
            };

            var groups = Comboboxes
                .Where(combobox => combobox.VisualTreeParents.Any(ItIsContentControl))
                .Where(inSameOrWithoutDataTemplate)
                .Where(combobox => combobox.GroupName == target.GroupName)
                .ToList();
            return groups;
        }

        private void OnFuzzySearchComboboxLoaded(object sender, RoutedEventArgs e)
        {
            DependencyObject current = this;
            while ((current = VisualTreeHelper.GetParent(current)) != null)
            {
                VisualTreeParents.Add(current);
            }

            UpdateUiAcordingStyle();

            if (IsFocused)
                InputTextBox.Focus();
        }

        private void UpdateUiAcordingStyle()
        {
            _allItemsHeader = new ResultItem(ResultType.All, AllResultHeader);
            _strongHeader = new ResultItem(ResultType.Strong, StrongResultHeader);
            _fuzzyHeader = new ResultItem(ResultType.Fuzzy, FuzzyResultHeader);
            _renamedItemsHeader = new ResultItem(ResultType.Renamed, RenamedResultHeader);
            _showAllButton = new ResultItem(ResultType.ShowAll, ShowAllButtonText);
        }

        private static void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var comboBox = (FuzzySearchCombobox)sender;
            if (comboBox.IsMouseOver)
                return;

            if (comboBox.PopupPanel.IsOpen)
                e.Handled = true;
        }

        private static bool ContainsSearch(IEnumerable<string> dictStrings, IEnumerable<string> searchSubstrings)
        {
            return searchSubstrings.All(searchStr => dictStrings.Any(dictStr => dictStr.Contains(searchStr)));
        }

        private static void SelectedKeyChangedCallBack(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var key = (int?)args.NewValue;
            ((FuzzySearchCombobox)o).SetSelectedItem(key);
        }

       
        private static void SelectedItemChangedCallBack(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var item = args.NewValue as KeyValuePair<int?, ValueContainer>?;
            var fuzzySearchCombobox = ((FuzzySearchCombobox)o);
            fuzzySearchCombobox.SetSelectedItem(item);
            Logger.DebugFormat(LoggingMessages.SelectedItemSettedTo, item != null && item.Value.Value != null ? item.Value.Value.ToString() : "null", fuzzySearchCombobox.NameForDebug);

            if (item == null)
                return;
            
            //Try parents combobox autocomplete
            TryParentsAutoComplete(fuzzySearchCombobox);
            //Update Validation in Group
            UpdateGroupValidation(fuzzySearchCombobox);
        }



        private static void ParentItemSourceChangedCallBack(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var dependencyObject = (FuzzySearchCombobox)o;

            Logger.DebugFormat(LoggingMessages.ParentItemSourceChangedInCombobox, dependencyObject.NameForDebug);

            //ItemsSource - наиболее приоритетный
            if (dependencyObject.ItemsSource != null) return;

            var parentItemSource = args.NewValue as Dictionary<int?, ValueContainer>;

            //если элементы пришли как от родительского, так и от дочернего Combobox'a
            if (dependencyObject.ChildItemsSource != null && parentItemSource != null)

                //найдем общие элементы
                dependencyObject.InternalItemsSource = parentItemSource.Where(pair => dependencyObject.ChildItemsSource.Any(valuePair => valuePair.Key == pair.Key)).ToDictionary(pair => pair.Key, pair => pair.Value);
            else
                dependencyObject.InternalItemsSource = parentItemSource;

            //если выбран какой-то элемент, то Combobox должен отдавать Child'ы выбранного элемента
            if (dependencyObject.SelectedItem != null)
            {
                var pair = dependencyObject.SelectedItem.GetValueOrDefault();
                if (pair.Value != null)
                    dependencyObject.ChildItems = dependencyObject.GetChilds(pair);
            }

            //иначе Child'ы элементов Combobox'a
            else
                dependencyObject.ChildItems = dependencyObject.GetChilds(parentItemSource);

            //если элементы пришли как от родительского, так и от дочернего Combobox'a
            if (dependencyObject.ChildItemsSource != null && parentItemSource != null)

                //найдем общие элементы 
                dependencyObject.InternalItemsSource = parentItemSource.Where(pair => dependencyObject.ChildItemsSource.Any(valuePair => valuePair.Key == pair.Key)).ToDictionary(pair => pair.Key, pair => pair.Value);
            else
                dependencyObject.InternalItemsSource = parentItemSource;

            dependencyObject.UpdateFilters();
        }

        private static void ChildItemSourceChangedCallBack(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var dependencyObject = (FuzzySearchCombobox)o;
            var childItemSource = args.NewValue as Dictionary<int?, ValueContainer>;

            if (childItemSource == null)
            {
                dependencyObject.InternalItemsSource = dependencyObject.ParentItemsSource;
                if (dependencyObject.SelectedItem == null)
                    dependencyObject.ParentItems = null;
            }
            else
            {
                //если элементы пришли как от родительского, так и от дочернего Combobox'a
                dependencyObject.InternalItemsSource = dependencyObject.ParentItemsSource != null
                    ? childItemSource.Where(
                        pair => dependencyObject.ParentItemsSource.Any(valuePair => valuePair.Key == pair.Key))
                        .ToDictionary(pair => pair.Key, pair => pair.Value)
                    : childItemSource;
                dependencyObject.ParentItems = dependencyObject.GetParents(childItemSource);
            }

            dependencyObject.UpdateFilters();
        }

        private static void ItemsSourcePropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var dependencyObject = (FuzzySearchCombobox)o;

            //проверка типа
            var typeMatch = args.NewValue is Dictionary<int, string>;
            if (!typeMatch && args.NewValue != null)
                throw new ItemsSourceTypeMismatchException();

            var items = args.NewValue as Dictionary<int, string>;
            if (items == null) return;

            //преобразование во внутреннее представление
            var itemSource = items.ToDictionary<KeyValuePair<int, string>, int?, ValueContainer>(item => item.Key, item => new ValueContainer(item.Key, item.Value));

            dependencyObject.InternalItemsSource = itemSource;
        }

        private static void InternalItemsSourceChangedCallBack(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var dependencyObject = (FuzzySearchCombobox)o;

            //отключим ComboBox если отсутствуют элементы для поиска -> отображения
            var nothingToShow = NothingToShow(dependencyObject);
            dependencyObject.NoData = nothingToShow;
            if (nothingToShow)
                dependencyObject.InputTextBox.Text = string.Empty;

            //если предполагается установка SelectedItem по его key, то установим SelectedItem (ситуация возникает если устанавливается key, а InternalItemsSource еще не указан)
            if (dependencyObject._setSelectedKeyRequest == null) return;
            dependencyObject.SetSelectedItem(dependencyObject._setSelectedKeyRequest);
            dependencyObject._setSelectedKeyRequest = null;
            dependencyObject.UpdateFilters();
        }

        private static bool NothingToShow(FuzzySearchCombobox combobox)
        {
            if (!String.IsNullOrEmpty(combobox.PredefinedValue))
                return false;

            return combobox.InternalItemsSource == null ||
                   combobox.InternalItemsSource.All(x => x.Value.IsDeleted) ||
                   combobox.InternalItemsSource.All(
                       x => combobox.AlwaysShow != null && Equals(x.Value, combobox.AlwaysShow.KeyValuePair.Value));
        }

        private static void TextPropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var combobox = (FuzzySearchCombobox)o;
            var value = args.NewValue as string;
            if (combobox.SelectedKey == null)
            {
                combobox.InputTextBox.Text = value;
            }
        }

        //закрытие popup
        private void DictionarySearchCombobox_OnIsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (!(IsMouseCaptureWithin || PopupPanel.IsMouseCaptureWithin || IsKeyboardFocusWithin || PopupPanel.IsKeyboardFocusWithin))
            {
                ClosePopup();
            }
        }

        //поиск, фокус на TextBox 
        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            Search();
            Keyboard.Focus(InputTextBox);
        }

        //"отжатие" кнопки
        private void PopupPanel_OnClosed(object sender, EventArgs e)
        {
            //если Popup по какой-то причине закрывается и указатель мыши не над кнопкой, 
            //то отожмем кнопку (иначе в начале нажатия на кнопку закроется Popup в конце нажатия - снова откроется)
            if (ToggleButton.IsMouseOver)
                Checked = false;
        }

        //управление фокусами
        private void SearchResultPanel_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var upPressedUnderFirstItem = e.Key == Key.Up && SearchResultCollection.CurrentPosition <= 1;

            var focusToTextBox = IsSymbolPressed(e) || upPressedUnderFirstItem;

            if (focusToTextBox)
                Keyboard.Focus(InputTextBox);

            if (e.Key == Key.Tab)
                ClosePopup();
        }

        private bool IsSymbolPressed(KeyEventArgs e)
        {
            var symbol = e.Key >= Key.A && e.Key <= Key.Z;
            var number = e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9;
            var space = e.Key == Key.Space;
            var back = e.Key == Key.Back;
            var delete = e.Key == Key.Delete;
            var ruKeys = e.Key >= Key.Oem1 && e.Key <= Key.Oem7;
            var oemComma = e.Key == Key.OemComma;
            var oemPeriod = e.Key == Key.OemPeriod;

            var symbolPressed = symbol || number || space || back || delete || ruKeys || oemComma || oemPeriod;
            return symbolPressed;
        }

        //установка выбранного элемента клавиатурой
        private void SearchResultPanel_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                SetSelectedItem(SearchResultCollection.CurrentItem as ResultItem);
        }

        //убирает выделение первого элемента
        private void SearchResultPanel_OnLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SearchResultCollection.MoveCurrentToFirst();
            SearchResultCollection.MoveCurrentToPrevious();
        }

        //выделяет элемент под мышью
        private void SearchResultPanel_OnMouseMove(object sender, MouseEventArgs e)
        {
            FocusManager.SetFocusedElement(this, SearchResultPanel);

            _selection = ((FrameworkElement)e.OriginalSource).DataContext as ResultItem;
            if (!SelectionIsHeader && SearchResultPanel.IsFocused)
                SearchResultCollection.MoveCurrentTo(_selection);

            SearchResultPanel.FocusItem(_selection);
        }

        //установка выбранного элемента мышью
        private void SearchResultPanelItem_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            SetSelectedItem(SearchResultCollection.CurrentItem as ResultItem);
        }

        private void SearchResultPanelItem_OnMouseEnter(object sender, MouseEventArgs e)
        {
            _selection = ((FrameworkElement)e.OriginalSource).DataContext as ResultItem;
            if (!SelectionIsHeader && SearchResultPanel.IsFocused)
                SearchResultCollection.MoveCurrentTo(_selection);

            SearchResultPanel.FocusItem(_selection);
        }

        //переносит фокус на popup
        private void InputTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab)
                ClosePopup();

            if (e.Key == Key.Escape)
                ClosePopup();

            if (e.Key != Key.Down) return;

            OpenPopupIfClose();
            SearchResultPanel.SelectedIndex = 1;
            Keyboard.Focus(SearchResultPanel);
        }

        private void InputTextBox_OnKeyUp(object sender, KeyEventArgs e)
        {
            if (IsSymbolPressed(e))
            {
                _bounceProtection.Elapsed -= T_Elapsed;
                _bounceProtection.Close();
                _bounceProtection = new Timer(BounceProtectionDelay);
                _bounceProtection.Elapsed += T_Elapsed;
                _bounceProtection.Start();
            }
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            _synchronizationContext.Send(state => OpenPopupIfClose(), null);
            _synchronizationContext.Send(state => Search(), null);
            _bounceProtection.Close();
        }

        //открвает popup
        private void InputTextBox_OnGotMouseCapture(object sender, MouseEventArgs e)
        {
            OpenPopupIfClose();
        }

        private void InputTextBox_OnPreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            SearchResultPanel.ScrollToTop();
        }

        //сбрасывает SelectedItem
        private void InputTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = (TextBox)sender;
            IsValid = GetValidValue(SelectedKey, textbox.Text, SelectedValue);
            Text = textbox.Text;

            SearchResult.Clear();
            SearchResultCollection.Refresh();

            if (IsKeyboardFocusWithin)
                SelectedItem = null;
        }

        //устаналивает Popup.StayOpen 
        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            SetStayOpenPopup();
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            SetStayOpenPopup();
        }

        private Dictionary<int?, ValueContainer> GetParents(Dictionary<int?, ValueContainer> childItemSource)
        {
            if (childItemSource == null)
                return null;

            var parents = new Dictionary<int?, ValueContainer>();

            ValueContainer k;
            var keyValuePairs = childItemSource.Values.Where(value => value.Parents != null).SelectMany(value => value.Parents.Where(parent => !parents.TryGetValue(parent.Key, out k)));

            foreach (var parent in keyValuePairs)
                parents.Add(parent.Key, parent.Value);

            return parents;
        }

        private Dictionary<int?, ValueContainer> GetParents(KeyValuePair<int?, ValueContainer> currentItem)
        {
            var valueContainer = currentItem.Value;
            return valueContainer == null ? null : valueContainer.Parents;
        }

        private Dictionary<int?, ValueContainer> GetChilds(Dictionary<int?, ValueContainer> parentItemSource)
        {
            if (parentItemSource == null || !parentItemSource.Any())
                return null;

            var childs = new Dictionary<int?, ValueContainer>();

            ValueContainer k;
            var keyValuePairs = parentItemSource.Values.Where(value => value.Childs != null).SelectMany(value => value.Childs.Where(child => !childs.TryGetValue(child.Key, out k)));

            foreach (var child in keyValuePairs)
                childs.Add(child.Key, child.Value);

            return childs;
        }

        private Dictionary<int?, ValueContainer> GetChilds(KeyValuePair<int?, ValueContainer> currentItem)
        {
            var valueContainer = currentItem.Value;
            return valueContainer == null ? null : valueContainer.Childs;
        }

        private void Search(bool showAllStrong = false)
        {
            var searchSubstring = InputTextBox.Text.Trim().ToLowerInvariant();

            if (_searchTask != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource = new CancellationTokenSource();
            }

            List<ResultItem> searchResult = null;
            _searchTask = new Task(() =>
            {
                IsSearches = true;
                try { searchResult = SearchImpl(_synchronizationContext, searchSubstring, showAllStrong); }
                catch (OperationCanceledException) { }
                finally
                {
                    IsSearches = false;
                }
            }, _cancellationTokenSource.Token);

            _searchTask.ContinueWith(task => _synchronizationContext.Send(state =>
            {
                SearchResult.Clear();
                SearchResultCollection.Refresh();

                if (searchResult != null)
                {
                    SearchResult.AddRange(searchResult);
                    SearchResultCollection.Refresh();
                }
            }, null), _cancellationTokenSource.Token);

            _searchTask.Start();
        }

        private List<ResultItem> SearchImpl(SynchronizationContext context, string searchSubstring, bool showAllStrong = false)
        {
            UpdateFilters();

            List<KeyValuePair<int?, ValueContainer>> searchSource = null;
            List<KeyValuePair<int?, ValueContainer>> searchSourceDeleted = null;
            var isItemSelected = false;
            char[] wordSplitters = null;
            var countToOutputValues = 0;
            var searchResult = new List<ResultItem>();
            AddPredefinedValueToResult(searchResult);

            context.Send(state =>
            {
                if (InternalItemsSource != null)
                {
                    searchSource = InternalItemsSource.Where(x => !x.Value.IsDeleted).ToList();
                    searchSourceDeleted = InternalItemsSource.Where(x => x.Value.IsDeleted).ToList();
                }
                isItemSelected = SelectedItem != null;
                wordSplitters = WordSplitters;
                countToOutputValues = CountToOutputValues;
                if (SelectedItem != null && SelectedItem.Value.Value != null && SelectedItem.Value.Value.IsDeleted)
                    AlwaysShow = new ResultItem(SelectedItem.Value);
            }, null);

            //не производить поиск если не указан действительный ItemSource
            if (searchSource == null) return null;

            var showAllItems = string.IsNullOrEmpty(searchSubstring) || string.IsNullOrWhiteSpace(searchSubstring) || isItemSelected;
            var deletedItems = searchSourceDeleted.OrderBy(pair => pair.Value.Value).Select(pair => new ResultItem(pair)).ToList();

            if (showAllItems)
            {
                var result = searchSource.OrderBy(pair => pair.Value.Value).Select(pair => new ResultItem(pair)).ToList();
                if (!result.Any())
                {
                    TryAddAlwaysShowItemOrShowDeleted(searchResult, AlwaysShow, deletedItems);
                    return searchResult;
                }

                searchResult.Add(_allItemsHeader); //заголовок-разграничитель 
                searchResult.AddRange(result);

                TryAddAlwaysShowItemOrShowDeleted(searchResult, AlwaysShow, deletedItems);

                return searchResult;
            }

            KeyValuePair<int?, ValueContainer>[] startsWithElements = { };
            KeyValuePair<int?, ValueContainer>[] containsElements = { };

            var searchWordsArray = searchSubstring.Split(wordSplitters).Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
            startsWithElements = searchSource.Where(x => x.Value.Value.StartsWith(searchSubstring, StringComparison.InvariantCultureIgnoreCase)).ToArray();
            var tooFewResults = startsWithElements.Length < countToOutputValues;
            if (tooFewResults)
                containsElements = searchSource.Where(x => ContainsSearch(x.Value.Value.ToLowerInvariant().Split(WordSplitters).Where(y => !string.IsNullOrEmpty(y)), searchWordsArray)).Except(startsWithElements).ToArray();

            //элементы, начинающиеся на поисковую подстроку. Предполагается, что такие элементы нужно показать первыми
            KeyValuePair<int?, ValueContainer>[] strongSearchResult = startsWithElements;
            if (strongSearchResult.Length < countToOutputValues)
                strongSearchResult = strongSearchResult.Concat(containsElements).ToArray();

            if (strongSearchResult.Any())
            {
                //элемент, играющий роль заголовка-разграничителя
                searchResult.Add(_strongHeader);

                //результаты строгого соответствия
                searchResult.AddRange(showAllStrong
                    ? strongSearchResult.Select(pair => new ResultItem(pair))
                    : strongSearchResult.Take(countToOutputValues).Select(pair => new ResultItem(pair)));

                //если будут показаны не все найденные элементы, то добавляем кнопку "Показать все"
                if (strongSearchResult.Length > countToOutputValues && !showAllStrong)
                    searchResult.Add(_showAllButton);
            }

            //элементы, удовлетворяющие условию нечеткого поиска 
            var fuzzySearchResult =
                searchSource.Where(pair => FuzzySearch(pair.Value.Value, searchSubstring))
                            .Select(pair => new { Pair = pair, LevenshteinDistance = CalcLevenshteinDistance(pair.Value.Value.ToLowerInvariant(), searchSubstring.ToLowerInvariant()) })
                            .OrderBy(arg => arg.LevenshteinDistance)
                            .Select(arg => arg.Pair)
                            .Where(fsPair => strongSearchResult.All(ssPair => ssPair.Key != fsPair.Key))
                            .Take(countToOutputValues)
                            .Select(pair => new ResultItem(pair))
                            .ToArray();

            if (fuzzySearchResult.Any())
            {
                //добавим элемент, играющий роль заголовка-разграничителя
                searchResult.Add(_fuzzyHeader);

                //добавим в поисковую выдачу результаты нечеткого поиска
                searchResult.AddRange(fuzzySearchResult);
            }

            // ищем совпадения в удаленных элементах, если включено их отображение
            var showDeletedItems = false;
            Application.Current.Dispatcher.Invoke(new Action(() => { showDeletedItems = ShowDeletedItems; }));
            if (showDeletedItems)
            {
                KeyValuePair<int?, ValueContainer>[] containsElementsFromDeleted = { };

                var searchWordsArrayFromDeleted = searchSubstring.Split(wordSplitters).Distinct().Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var startsWithElementsFromDeleted = searchSourceDeleted
                    .Where(x => x.Value.Value.StartsWith(searchSubstring, StringComparison.InvariantCultureIgnoreCase))
                    .ToArray();
                tooFewResults = startsWithElementsFromDeleted.Length < countToOutputValues;
                if (tooFewResults)
                    containsElementsFromDeleted = searchSourceDeleted
                        .Where(x => ContainsSearch(x.Value.Value.ToLowerInvariant().Split(WordSplitters).Where(y => !string.IsNullOrEmpty(y)), searchWordsArrayFromDeleted))
                        .Except(startsWithElementsFromDeleted).ToArray();

                var strongSearchResultFromDeleted = startsWithElementsFromDeleted;
                if (strongSearchResultFromDeleted.Length < countToOutputValues)
                    strongSearchResultFromDeleted = strongSearchResultFromDeleted.Concat(containsElementsFromDeleted).ToArray();

                if (strongSearchResultFromDeleted.Any())
                {
                    deletedItems = strongSearchResultFromDeleted.Take(countToOutputValues)
                            .Select(pair => new ResultItem(pair))
                            .ToList();
                }
                else
                {
                    deletedItems = new List<ResultItem>();
                }
            }

            TryAddAlwaysShowItemOrShowDeleted(searchResult, AlwaysShow, deletedItems);

            return searchResult;
        }

        private void TryAddAlwaysShowItemOrShowDeleted(List<ResultItem> searchResult, ResultItem alwaysShowItem, List<ResultItem> deletedItems)
        {
            var showDeletedItems = false;
            Application.Current.Dispatcher.Invoke(new Action(() => { showDeletedItems = ShowDeletedItems; }));
            if (showDeletedItems && deletedItems.Count > 0)
            {
                searchResult.Add(_renamedItemsHeader);
                searchResult.AddRange(deletedItems);
            }
            else if (alwaysShowItem != null)
            {
                searchResult.Add(_renamedItemsHeader); //заголовок-разграничитель 
                searchResult.Add(alwaysShowItem);
            }
        }

        private bool FuzzySearch(string inputString, string substring)
        {
            if (string.IsNullOrEmpty(inputString) || string.IsNullOrEmpty(substring))
                return false;

            double totalScore = 0;
            var dictionaryWords = substring.Split(WordSplitters);
            var inputWords = inputString.Split(WordSplitters);
            foreach (var inputWord in inputWords)
            {
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                double maxScore = 0;
                foreach (var dictionaryWord in dictionaryWords)
                {
                    var distance = CalcLevenshteinDistance(inputWord.ToLower(), dictionaryWord.ToLower());
                    var length = Math.Max(inputWord.Length, dictionaryWord.Length);
                    var score = 1.0 - (double)distance / length;
                    if (maxScore < score)
                        maxScore = score;
                }
                totalScore += maxScore;
            }
            return totalScore > DefaultFuzziness;
        }

        private int CalcLevenshteinDistance(string src, string dest)
        {
            var d = new int[src.Length + 1, dest.Length + 1];
            int i, j, cost;
            char[] srcChars = src.ToCharArray();
            char[] destChars = dest.ToCharArray();

            for (i = 0; i <= srcChars.Length; i++) d[i, 0] = i;
            for (j = 0; j <= destChars.Length; j++) d[0, j] = j;
            for (i = 1; i <= srcChars.Length; i++)
            {
                _cancellationTokenSource.Token.ThrowIfCancellationRequested();

                for (j = 1; j <= destChars.Length; j++)
                {
                    cost = srcChars[i - 1] == destChars[j - 1] ? 0 : 1;

                    d[i, j] = Math.Min(d[i - 1, j] + 1, // Deletion
                        Math.Min(d[i, j - 1] + 1, // Insertion
                            d[i - 1, j - 1] + cost)); // Substitution

                    if ((i > 1) && (j > 1) && (srcChars[i - 1] == destChars[j - 2]) && (srcChars[i - 2] == destChars[j - 1]))
                    {
                        d[i, j] = Math.Min(d[i, j], d[i - 2, j - 2] + cost);
                    }
                }
            }

            return d[srcChars.Length, destChars.Length];
        }

        private bool GetValidValue(int? selectedKey, string textBoxText, ValueContainer selectedValue)
        {
            var f1 = selectedKey == null && !string.IsNullOrWhiteSpace(textBoxText);
            var f2 = selectedValue != null && String.CompareOrdinal(selectedValue.Value, textBoxText) != 0;
            return !(f1 || f2);
        }

        private void OpenPopupIfClose()
        {
            UpdateFilters();
            if (!PopupPanel.IsOpen)
            {
                PopupPanel.IsOpen = true;
                Search();
            }
        }

        private void UpdateFilters()
        {
            OnPropertyChanged("Filters");
        }

        private void ClosePopup()
        {
            PopupPanel.IsOpen = false;
        }

        private void SetSelectedItem(ResultItem item)
        {
            if (item != null)
                SelectedItem = item.KeyValuePair;
            else
                SelectedItem = null;
            ClosePopup();
            UpdateGroupValidation(this);
            Keyboard.Focus(InputTextBox);
        }

        private void SetSelectedItem(int? key)
        {
            if (key != null)
            {
                //PredefinedKey is not contains in InternalItemsSource
                if (InternalItemsSource != null && key != PredefinedKey)
                    SelectedItem = InternalItemsSource.FirstOrDefault(pair => pair.Key == key);
                else
                    _setSelectedKeyRequest = key;
                IsValid = GetValidValue(SelectedKey, InputTextBox.Text, SelectedValue);
                UpdateGroupValidation(this);
                return;
            }

            SelectedItem = null;
            SelectedValue = null;
            IsValid = GetValidValue(SelectedKey, InputTextBox.Text, SelectedValue);
            UpdateGroupValidation(this);
        }

        private void SetSelectedItem(KeyValuePair<int?, ValueContainer>? item)
        {
            if (item != null)
            {
                var keyValuePair = item.Value;
                if (keyValuePair.Key == null || keyValuePair.Value == null) return;

                SelectedKey = keyValuePair.Key;
                SelectedValue = keyValuePair.Value;

                //If item is IsPredefinedItem - Do not need to filter the parent data and child data
                if (!IsPredefinedItem(item))
                {
                    ParentItems = GetParents(keyValuePair);
                    ChildItems = GetChilds(keyValuePair);
                }

                InputTextBox.Text = keyValuePair.Value.ToString();
                InputTextBox.SelectionStart = InputTextBox.Text.Length;
                if (!string.IsNullOrEmpty(InputTextBox.Text))
                    NoData = false;
                return;
            }

            SelectedKey = null;
            SelectedValue = null;
            InputTextBox.Text = string.Empty;

            ChildItems = GetChilds(ParentItemsSource);
            ParentItems = null;
        }

        private void SetStayOpenPopup()
        {
            PopupPanel.StaysOpen = IsMouseOver;
        }

        private void FuzzySearchCombobox_OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            AlwaysShow = null;
        }

        private ResultItem _allItemsHeader;

        //for debug
        private readonly string _fuzzySearchComboboxCreatedAt;
        private ResultItem _fuzzyHeader;
        private ResultItem _renamedItemsHeader;
        private ResultItem _strongHeader;

        private ResultItem _showAllButton;
        private void ShowAllButton_OnClick(object sender, RoutedEventArgs e)
        {
            Search(true);
            Keyboard.Focus(InputTextBox);
        }

        //запускает поиск
        private Timer _bounceProtection = new Timer();
        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private bool _isSearches;
        private bool _noData;
        private Task _searchTask;
        private ResultItem _selection;
        private int? _setSelectedKeyRequest;
        private readonly SynchronizationContext _synchronizationContext;

        private bool Checked { get { return (bool)GetValue(CheckedProperty); } set { SetValue(CheckedProperty, value); } }

        private Dictionary<int?, ValueContainer> InternalItemsSource
        {
            get { return (Dictionary<int?, ValueContainer>)GetValue(InternalItemsSourceProperty); }
            set
            {
                SetValue(InternalItemsSourceProperty, value);
                OnPropertyChanged("InternalItemsSource");
            }
        }

        internal string NameForDebug
        {
            get
            {
                var nameForDebug = string.Format("{0}-{1}-{2}", GroupName ?? "UntitledGroup", Name ?? "Untitled", _fuzzySearchComboboxCreatedAt);
                return nameForDebug;
            }
        }

        private bool SelectionIsHeader { get { return _selection != null && (_selection.ItemType == ItemType.Header || _selection.ItemType == ItemType.Button); } }

        private List<DependencyObject> VisualTreeParents { get; set; }

        public class ResultItem
        {
            public ItemType ItemType { get; set; }

            public ResultItem(KeyValuePair<int?, ValueContainer> keyValuePair)
            {
                KeyValuePair = keyValuePair;
                ItemType = ItemType.Common;
            }

            public ResultItem(ResultType resultType, string resultTypeName)
            {
                KeyValuePair = new KeyValuePair<int?, ValueContainer>(-Math.Abs(resultTypeName.GetHashCode()) - 1, new ValueContainer(null, resultTypeName));
                ItemType = resultType == ResultType.ShowAll ? ItemType.Button : ItemType.Header;
            }

            public override string ToString()
            {
                return ValueContainer.ToString();
            }

            public KeyValuePair<int?, ValueContainer> KeyValuePair;

            private ValueContainer ValueContainer { get { return KeyValuePair.Value; } }

            public int? Key
            {
                get { return KeyValuePair.Key; }
            }
        }
    }
}