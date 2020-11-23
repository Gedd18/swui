using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWUI
{
    /// <summary>
    /// Interaction logic for DropBorder.xaml
    /// </summary>
    public partial class DropBorder : Border
    {
        private Window _parentWindow;

        public DropBorder()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = Window.GetWindow(this);
        }

        private void Border_MouseMove(object sender, MouseEventArgs e)
        {
            if (_parentWindow != null && e.LeftButton == MouseButtonState.Pressed) _parentWindow.DragMove();
        }
    }
}
