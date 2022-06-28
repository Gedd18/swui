using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Toolkit.Mvvm.Input;

namespace SWUI
{
    /// <summary>
    /// Interaction logic for StateButtons.xaml
    /// </summary>
    public partial class StateButtons : Border
    {
        public static readonly DependencyProperty OverColorProperty =
        DependencyProperty.Register(
            "OverColor",
            typeof(System.Windows.Media.Color?),
            typeof(StateButtons),
            new PropertyMetadata(System.Windows.Media.Colors.White, OverColorChanged));

        public static readonly DependencyProperty BaseColorProperty =
        DependencyProperty.Register(
            "BaseColor",
            typeof(System.Windows.Media.Color?),
            typeof(StateButtons),
            new PropertyMetadata(System.Windows.Media.Colors.White, BaseColorChanged));


        private static void OverColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateButtons sb = d as StateButtons;
            sb.MinimizeButton.OverColor = e.NewValue as System.Windows.Media.Color?;
            sb.MaximizeButton.OverColor = e.NewValue as System.Windows.Media.Color?;
            sb.CloseButton.OverColor = e.NewValue as System.Windows.Media.Color?;
        }
        private static void BaseColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            StateButtons sb = d as StateButtons;
            sb.MinimizeButton.BaseColor = e.NewValue as System.Windows.Media.Color?;
            sb.MaximizeButton.BaseColor = e.NewValue as System.Windows.Media.Color?;
            sb.CloseButton.BaseColor = e.NewValue as System.Windows.Media.Color?;
        }

        public System.Windows.Media.Color? OverColor
        {
            get { return (System.Windows.Media.Color?)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }

        public System.Windows.Media.Color? BaseColor
        {
            get { return (System.Windows.Media.Color?)GetValue(BaseColorProperty); }
            set { SetValue(BaseColorProperty, value); }
        }


        private Window _parentWindow;
        public StateButtons()
        {
            InitializeComponent();
            MinimizeButton.Command = new RelayCommand<object>((o) => Click_Minimize());
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
                        break;
                    case WindowState.Minimized:
                        break;
                    case WindowState.Maximized:
                        _parentWindow.WindowState = WindowState.Normal;
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
            if (_parentWindow != null)
            {
                _parentWindow.StateChanged += _parentWindow_StateChanged;
                _parentWindow_StateChanged(null, null);
            }
        }

        private void _parentWindow_StateChanged(object sender, EventArgs e)
        {
            switch (_parentWindow.WindowState)
            {
                case WindowState.Normal:
                    MaximizeButton.Source = "/SWUI;component/svg/square.svg";
                    break;
                case WindowState.Minimized:
                    break;
                case WindowState.Maximized:
                    MaximizeButton.Source = "/SWUI;component/svg/restore.svg";
                    break;
                default:
                    break;
            }
        }
    }
}
