using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Resources;

namespace SWUI
{
    /// <summary>
    /// Logique d'interaction pour SVGButton.xaml
    /// </summary>
    public partial class SVGButton : CommandPanel
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


        private Color? _baseColor;

        /// <summary>
        /// Drawing color when the mouse is over
        /// </summary>
        public Color? BaseColor
        {
            get => _baseColor;
            set { img.OverrideColor = value; _baseColor = value; Update(); }
        }

        public Color? OverColor
        {
            get;
            set;
        }

        public Color? OverBackgroundColor
        { 
            get; 
            set; 
        }

        public SVGButton()
        {
            InitializeComponent();
            MouseEnter += SVGButton_MouseEnter;
            MouseLeave += SVGButton_MouseLeave;
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
                Background = new SolidColorBrush(OverBackgroundColor.GetValueOrDefault());
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
