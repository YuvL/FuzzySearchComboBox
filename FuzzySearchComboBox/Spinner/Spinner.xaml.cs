using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Controls.Spinner
{
    /// <summary>
    /// Interaction logic for Spinner.xaml
    /// </summary>
    public partial class Spinner : UserControl
    {
        private const double DefaultCountOfBlocks = 12;
        private const double DefaultRotatePeriod = 1;
        private const double magicRotateDuration = 25;
        public static readonly DependencyProperty CountOfBlocksProperty = DependencyProperty.Register("CountOfBlocks", typeof (double), typeof (Spinner), new PropertyMetadata(DefaultCountOfBlocks, SomeSpinnerParameterChangedCallback));
        public static readonly DependencyProperty RotateTypeProperty = DependencyProperty.Register("Animation", typeof (RotateAnimationType), typeof (Spinner), new PropertyMetadata(RotateAnimationType.Opacity, SomeSpinnerParameterChangedCallback));
        public static readonly DependencyProperty RotatePeriodProperty = DependencyProperty.Register("RotateDuration", typeof (double), typeof (Spinner), new PropertyMetadata(DefaultRotatePeriod, SomeSpinnerParameterChangedCallback));
        public static readonly DependencyProperty IsActiveProperty = DependencyProperty.Register("IsActive", typeof (bool), typeof (Spinner), new PropertyMetadata(true, IsStartedChangedCallback));
        public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof (double), typeof (Spinner), new PropertyMetadata(default(double)));

        private readonly Point RenderTransformOriginValue = new Point(0.5, 0.5);
        private readonly RepeatBehavior repeatForever = new RepeatBehavior(int.MaxValue);

        public Spinner()
        {
            Size = GetActualSize();
            Loaded += (sender, args) => Size = GetActualSize();
            SizeChanged += (sender, args) => Size = GetActualSize();

            InitializeComponent();
            //Start();
        }

        public RotateAnimationType Animation { get { return (RotateAnimationType) GetValue(RotateTypeProperty); } set { SetValue(RotateTypeProperty, value); } }
        public double CountOfBlocks { get { return (double) GetValue(CountOfBlocksProperty); } set { SetValue(CountOfBlocksProperty, value); } }
        public bool IsActive { get { return (bool) GetValue(IsActiveProperty); } set { SetValue(IsActiveProperty, value); } }
        public double RotateDuration { get { return (double) GetValue(RotatePeriodProperty); } set { SetValue(RotatePeriodProperty, value); } }
        public double Size { get { return (double) GetValue(SizeProperty); } set { SetValue(SizeProperty, value); } }

        private double GetActualSize()
        {
            double size;
            if (!double.IsNaN(ActualWidth) || !double.IsNaN(ActualHeight))
                size = Math.Min(ActualWidth, ActualHeight);
            else
                size = Math.Min(Width, Height);
            return size;
        }

        private static void IsStartedChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Spinner) d).Visibility = ((bool) e.NewValue) ? Visibility.Visible : Visibility.Hidden;
        }

        private static void SomeSpinnerParameterChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Spinner) d).Restart();
        }

        private void Restart()
        {
            Grid.Children.Clear();
            Start();
        }

        private void Start()
        {
            var blockRotateAngleStep = 360.0/CountOfBlocks;
            var delayForOneBlock = RotateDuration/CountOfBlocks;

            for (double i = 0; i < CountOfBlocks; i++)
            {
                Block block = CreateBlock(opacity: i/CountOfBlocks, rotateAngle: i*blockRotateAngleStep);
                Grid.Children.Add(block);

                switch (Animation)
                {
                    case RotateAnimationType.Opacity:
                        OpacityAnimation(block, delayForOneBlock, i);
                        break;
                    case RotateAnimationType.Rotate:
                        RotateAnimation(RotateDuration);
                        break;
                    case RotateAnimationType.Lazy:
                        RotateAnimation(RotateDuration, new ElasticEase {EasingMode = EasingMode.EaseInOut});
                        break;
                    case RotateAnimationType.Magic:
                        OpacityAnimation(block, delayForOneBlock, i);
                        RotateAnimation(magicRotateDuration, new ElasticEase {EasingMode = EasingMode.EaseInOut});
                        break;
                }
            }
        }

        private void OpacityAnimation(Block block, double delayForOneBlock, double i)
        {
            var opacityAnimation1 = new DoubleAnimation {From = block.Opacity, To = 0, By =1.0/12.0, Duration = new Duration(TimeSpan.FromSeconds(delayForOneBlock*i))};
            var opacityAnimation2 = new DoubleAnimation { From = 1, To = 0, By =1.0/12.0, RepeatBehavior = repeatForever, Duration = new Duration(TimeSpan.FromSeconds(RotateDuration)) };

            opacityAnimation1.Completed += (sender, args) => block.BeginAnimation(OpacityProperty, opacityAnimation2);
            block.BeginAnimation(OpacityProperty, opacityAnimation1);
        }

        private void RotateAnimation(double rotateDuration, IEasingFunction easingFunction = null)
        {
            var rotateAnimation = new DoubleAnimation {From = 0, To = 360, RepeatBehavior = repeatForever, Duration = new Duration(TimeSpan.FromSeconds(rotateDuration)), EasingFunction = easingFunction};
            var gridTransform = (TransformGroup) Grid.RenderTransform;
            var rotateTransform = gridTransform.Children.FirstOrDefault(x => x is RotateTransform) as RotateTransform;
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }

        private Block CreateBlock(double rotateAngle, double opacity)
        {
            var transformGroup = new TransformGroup();
            transformGroup.Children.Add(new RotateTransform(rotateAngle));
            return new Block {RenderTransformOrigin = RenderTransformOriginValue, RenderTransform = transformGroup, Opacity = opacity};
        }
    }

    public enum RotateAnimationType
    {
        Opacity,
        Rotate,
        Lazy,
        Magic
    }
}