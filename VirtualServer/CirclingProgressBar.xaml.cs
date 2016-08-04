using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace VirtualServer
{
    /// <summary>
    /// Логика взаимодействия для CirclingProgressBar.xaml
    /// </summary>
    public partial class CirclingProgressBar : UserControl
    {
        public CirclingProgressBar()
        {
            InitializeComponent();
            Timeline.DesiredFrameRateProperty.OverrideMetadata(
                  typeof(Timeline),
                    new FrameworkPropertyMetadata { DefaultValue = 20 });
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void UserControl_IsVisibleChanged_1(object sender, DependencyPropertyChangedEventArgs e)
        {

        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Canvas_Unloaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
