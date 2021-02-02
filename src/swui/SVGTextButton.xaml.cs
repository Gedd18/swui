using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;

namespace SWUI
{
    /// <summary>
    /// Logique d'interaction pour SVGTextButton.xaml
    /// </summary>
    public partial class SVGTextButton : CommandPanel
    {
        /// <summary>
        /// SVG source file
        /// </summary>
        public string Source
        {
            get => icon.Source;
            set
            {
                icon.Source = value;
                Uri _uri = new Uri("pack://application:,,," + icon.Source);
                StreamResourceInfo sri = Application.GetResourceStream(_uri);

                using Stream s = sri.Stream;
                icon.SetImage(s);
            }
        }

        /// <summary>
        /// Content text for the control
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// private field for base color property
        /// </summary>
        private Color? _baseColor;

        /// <summary>
        /// Color used to draw the SVG
        /// </summary>
        public Color? BaseColor
        {
            get => _baseColor;
            set { icon.OverrideColor = value; _baseColor = value; Update(); }
        }

        /// <summary>
        /// Drawing color when the mouse is over
        /// </summary>
        public Color? OverColor
        {
            get;
            set;
        }

        /// <summary>
        /// Background drawing color when the mouse is over
        /// </summary>
        public Brush OverBackgroundColor
        {
            get;
            set;
        }

        public Dock IconPosition
        {
            get { return (Dock)GetValue(IconPositionProperty); }
            set { SetValue(IconPositionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconPosition.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPositionProperty =
            DependencyProperty.Register("IconPosition", typeof(Dock), typeof(SVGTextButton), new PropertyMetadata(Dock.Left, IconPositionChanged));

        private static void IconPositionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            SVGTextButton stb = d as SVGTextButton;
            Dock pos = (Dock)e.NewValue;
            switch (pos)
            {
                case Dock.Left:
                    DockPanel.SetDock(stb.icon, Dock.Left);
                    DockPanel.SetDock(stb.text, Dock.Right);
                    break;
                case Dock.Top:
                    DockPanel.SetDock(stb.icon, Dock.Top);
                    DockPanel.SetDock(stb.text, Dock.Bottom);
                    break;
                case Dock.Right:
                    DockPanel.SetDock(stb.icon, Dock.Right);
                    DockPanel.SetDock(stb.text, Dock.Left);
                    break;
                case Dock.Bottom:
                    DockPanel.SetDock(stb.icon, Dock.Bottom);
                    DockPanel.SetDock(stb.text, Dock.Top);
                    break;
            }  
        }


        public SVGTextButton()
        {
            InitializeComponent();
            MouseEnter += SVGButton_MouseEnter;
            MouseLeave += SVGButton_MouseLeave;
            IconPosition = Dock.Bottom;
            Text = "...";
        }

        private void SVGButton_MouseLeave(object sender, MouseEventArgs e)
        {
            icon.OverrideColor = _baseColor;
            Background = Brushes.Transparent;
            Update();
        }

        private void SVGButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (OverColor != null) icon.OverrideColor = OverColor;
            if (OverBackgroundColor != null)
                Background = OverBackgroundColor;
            Update();
        }

        private void Update()
        {
            if (icon.Source == null) return;
            Uri _uri = new Uri("pack://application:,,," + icon.Source);
            StreamResourceInfo sri = Application.GetResourceStream(_uri);

            using Stream s = sri.Stream;
            icon.SetImage(s);
        }

        private void CommandPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
