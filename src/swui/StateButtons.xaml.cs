using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using MvvmNext.Command;

namespace SWUI
{
    /// <summary>
    /// Interaction logic for StateButtons.xaml
    /// </summary>
    public partial class StateButtons : Border
    {
        public static readonly DependencyProperty BaseColorProperty =
        DependencyProperty.Register(
            "BaseColor",
            typeof(Color),
            typeof(StateButtons),
            new PropertyMetadata(Color.White));

        public Color BaseColor
        {
            get { return (Color)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }


        private Window _parentWindow;
        public StateButtons()
        {
            InitializeComponent();
            MinimizeButton.Command = new RelayCommand<object>((o) => Click_Minimize()) ;
            MaximizeButton.Command = new RelayCommand<object>((o) => Click_Maximize());
            CloseButton.Command = new RelayCommand<object>((o) => Click_Close());
        }

        private void Click_Minimize()
        {
            if (_parentWindow != null)
            {
                _parentWindow.WindowState = WindowState.Minimized;
            }
        }
            

        private void Click_Maximize()
        {
            if (_parentWindow != null)
            {
                switch (_parentWindow.WindowState)
                {
                    case WindowState.Normal:
                        _parentWindow.WindowState = WindowState.Maximized;
                        MaximizeButton.Source = "/SWUI.Controls;component/svg/restore.svg";
                        break;
                    case WindowState.Minimized:
                        break;
                    case WindowState.Maximized:
                        _parentWindow.WindowState = WindowState.Normal;
                        MaximizeButton.Source = "/SWUI.Controls;component/svg/square.svg";
                        break;
                    default:
                        break;
                }
            }
        }

        private void Click_Close()
        {
            _parentWindow?.Close();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _parentWindow = Window.GetWindow(this);
        }
    }
}
