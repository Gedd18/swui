using System;
using System.IO;
using System.Windows;
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
            get => img.Source;
            set
            {
                img.Source = value;
                Uri _uri = new Uri("pack://application:,,," + img.Source);
                StreamResourceInfo sri = Application.GetResourceStream(_uri);

                using (Stream s = sri.Stream)
                {
                    img.SetImage(s);
                }
            }
        }

        public string Text { get; set; }


        private Color? _baseColor;

        /// <summary>
        /// Color used to draw the SVG
        /// </summary>
        public Color? BaseColor
        {
            get => _baseColor;
            set { img.OverrideColor = value; _baseColor = value; Update(); }
        }

        /// <summary>
        /// Drawing color when the mouse is over
        /// </summary>
        public Color? OverColor
        {
            get;
            set;
        }

        public Brush OverBackgroundColor
        {
            get;
            set;
        }

        public SVGTextButton()
        {
            InitializeComponent();
            MouseEnter += SVGButton_MouseEnter;
            MouseLeave += SVGButton_MouseLeave;
            Text = "...";
        }

        private void SVGButton_MouseLeave(object sender, MouseEventArgs e)
        {
            img.OverrideColor = _baseColor;
            Background = Brushes.Transparent;
            Update();
        }

        private void SVGButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (OverColor != null) img.OverrideColor = OverColor;
            if (OverBackgroundColor != null)
                Background = OverBackgroundColor;
            Update();
        }

        private void Update()
        {
            if (img.Source == null) return;
            Uri _uri = new Uri("pack://application:,,," + img.Source);
            StreamResourceInfo sri = Application.GetResourceStream(_uri);

            using (Stream s = sri.Stream)
            {
                img.SetImage(s);
            }
        }

        private void CommandPanel_Loaded(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
