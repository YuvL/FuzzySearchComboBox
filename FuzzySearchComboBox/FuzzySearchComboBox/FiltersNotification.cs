using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

// ReSharper disable once CheckNamespace

namespace Controls.FuzzySearchComboBox
{
    /// <summary>
    /// Interaction logic for FiltersNotification.xaml
    /// </summary>
    public partial class FiltersNotification : UserControl, INotifyPropertyChanged
    {
        public string Text { get { return (string) GetValue(TextProperty); } set { SetValue(TextProperty, value); } }

        public bool TextEmpty
        {
            get { return (bool) GetValue(TextEmptyProperty); }
            set
            {
                SetValue(TextEmptyProperty, value);
                OnPropertyChanged("TextEmpty");
            }
        }

        public static readonly DependencyProperty TextEmptyProperty =
            DependencyProperty.Register("TextEmpty", typeof (bool), typeof (FiltersNotification), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof (string), typeof (FiltersNotification), new PropertyMetadata(default(string), PropertyChangedCallback));

        public FiltersNotification()
        {
            InitializeComponent();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            ((FiltersNotification) dependencyObject).Visibility = string.IsNullOrEmpty(dependencyPropertyChangedEventArgs.NewValue as string) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
}