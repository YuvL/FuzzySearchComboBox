using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Controls.Spinner
{
    /// <summary>
    /// Interaction logic for Block.xaml
    /// </summary>
    public partial class Block : UserControl, INotifyPropertyChanged
    {
        private const double DefaultScale = 1;
        private const double DefaultBlockSize = 150;
        public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register("Scale", typeof (double), typeof (Block), new PropertyMetadata(DefaultScale));
        private double _size;

        public Block()
        {
            InitializeComponent();

            SetScaleIfSizeIsNotNaN();
            Loaded += (sender, args) => SetScaleIfSizeIsNotNaN();
            SizeChanged += (sender, args) => SetScaleIfSizeIsNotNaN();
        }

        public double Scale { get { return (double) GetValue(ScaleProperty); } set { SetValue(ScaleProperty, value); } }
        public double Size
        {
            get { return _size; }
            set
            {
                _size = value;
                OnPropertyChanged("Size");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };
        private bool IsNan(double width, double height)
        {
            return double.IsNaN(width) || double.IsNaN(height);
        }
        private void SetScaleIfSizeIsNotNaN()
        {
            if (!IsNan(ActualWidth, ActualHeight))
                Size = Math.Min(ActualWidth, ActualHeight);
            else if (!IsNan(Width, Height))
                Size = Math.Min(Width, Height);
            Scale = Size/DefaultBlockSize;
        }
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}