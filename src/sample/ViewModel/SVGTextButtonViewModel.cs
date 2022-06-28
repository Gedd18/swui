using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SWUI.Sample.ViewModel
{
    public class SVGTextButtonViewModel : ObservableObject
    {
        public RelayCommand SmileCommand { get; private set; }

        private bool isToLeftChecked;

        public bool IsToLeftChecked
        {
            get => isToLeftChecked;
            set
            {
                _ = SetProperty(ref isToLeftChecked, value);
                if (value) SetIconPosition(Dock.Left);
            }
        }

        private bool isToRightChecked;

        public bool IsToRightChecked
        {
            get => isToRightChecked;
            set
            {
                _ = SetProperty(ref isToRightChecked, value);
                if (value) SetIconPosition(Dock.Right);
            }
        }

        private bool isToTopChecked;

        public bool IsToTopChecked
        {
            get => isToTopChecked;
            set
            {
                _ = SetProperty(ref isToTopChecked, value);
                if (value) SetIconPosition(Dock.Top);
            }
        }

        private bool isToBottomChecked;

        public bool IsToBottomChecked
        {
            get => isToBottomChecked;
            set
            {
                _ = SetProperty(ref isToBottomChecked, value);
                if (value) SetIconPosition(Dock.Bottom);
            }
        }


        //[ObservableProperty]
        private Dock position;

        public Dock Position
        {
            get => position;
            set
            {
                _ = SetProperty(ref position, value);
            }
        }

        public SVGTextButtonViewModel()
        {
            SmileCommand = new RelayCommand(Smile);
            IsToBottomChecked = true;
        }

        private void SetIconPosition(Dock position)
        {
            Position = position;
        }

        private void Smile()
        {
            MessageBox.Show("Smile !");
        }
    }
}
