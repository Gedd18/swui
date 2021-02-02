using MvvmNext;
using MvvmNext.CommandWpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SWUI.Sample.ViewModel
{
    public class SVGTextButtonViewModel : ViewModelBase
    {
        public RelayCommand SmileCommand { get; private set; }

        public RelayCommand SetIconPositionLeft { get; private set; }

        public RelayCommand SetIconPositionRight { get; private set; }

        public RelayCommand SetIconPositionTop { get; private set; }

        public RelayCommand SetIconPositionBottom { get; private set; }

        public Dock Position { get; private set; }

        public SVGTextButtonViewModel()
        {
            SmileCommand = new RelayCommand(Smile);
            SetIconPositionLeft = new RelayCommand(() => SetIconPosition(Dock.Left));
            SetIconPositionRight = new RelayCommand(() => SetIconPosition(Dock.Right));
            SetIconPositionTop = new RelayCommand(() => SetIconPosition(Dock.Top));
            SetIconPositionBottom = new RelayCommand(() => SetIconPosition(Dock.Bottom));
            SetIconPosition(Dock.Bottom);
        }

        private void SetIconPosition(Dock position)
        {
            Position = position;
            RaisePropertyChanged(() => Position);
        }

        private void Smile()
        {
            MessageBox.Show("Smile !");
        }
    }
}
