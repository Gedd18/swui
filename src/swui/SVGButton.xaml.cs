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
                img.UriSource = new Uri("pack://application:,,," + img.Source); 
            }
        }


        private Color? _baseColor;

        /// <summary>
        /// Color used to draw the SVG
        /// </summary>
        public Color? BaseColor
        {
            get => _baseColor;
            set { 
                img.OverrideColor = value; 
                _baseColor = value; 
            }
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
        }

        private void SVGButton_MouseEnter(object sender, MouseEventArgs e)
        {
            if (OverColor != null) img.OverrideColor = OverColor;
            if (OverBackgroundColor != null)
                Background = OverBackgroundColor;
        }
    }
}
