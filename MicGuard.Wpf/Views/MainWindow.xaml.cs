using MicGuard.Wpf.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MicGuard.Wpf.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thumb? _sliderThumb;

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            _sliderThumb = FindVisualChild<Thumb>(VolumeSlider);
            if (_sliderThumb != null)
                VolumeSliderPopup.PlacementTarget = _sliderThumb;
        }

        private void VolumeSlider_PreviewMouseDown(object? sender, MouseButtonEventArgs e)
        {
            VolumeSliderPopup.IsOpen = true;
            UpdatePopupPosition();
        }

        private void VolumeSlider_PreviewMouseUp(object? sender, MouseButtonEventArgs e)
        {
            VolumeSliderPopup.IsOpen = false;
        }

        private void VolumeSlider_ValueChanged(object? sender, RoutedPropertyChangedEventArgs<double> e)
        {
            VolumeSliderPopupText.Text = VolumeSlider.Value.ToString("0");
            UpdatePopupPosition();
        }

        private void UpdatePopupPosition()
        {
            if (_sliderThumb == null || !VolumeSliderPopup.IsOpen)
                return;

            double center = (_sliderThumb.ActualWidth - VolumeSliderPopupBorder.ActualWidth) / 2;
            VolumeSliderPopup.HorizontalOffset = center + 0.1;
            VolumeSliderPopup.HorizontalOffset = center;
        }

        private static T? FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                if (child is T typed)
                    return typed;

                var result = FindVisualChild<T>(child);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}