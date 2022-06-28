using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using SWUI.Sample.ViewModel;

namespace SWUI.Sample
{
    public class SampleViewModel : ObservableObject
    {

        public RelayCommand<Type> ChangeControlsPanelCommand { get; private set; }

        public Dictionary<string, Type> ControlsItemList { get => _controlsItemDic; }

        Dictionary<string, Type> _controlsItemDic;

        public ObservableObject CurrentViewModel { get; private set; }

        public SampleViewModel() 
        {
            _controlsItemDic = new Dictionary<string, Type> {
                { "CommandPanel", typeof(CommandPanelViewModel)},
                { "DropBorder", typeof(DropBorderViewModel)},
                { "WindowStateButtons", typeof(WindowStateButtonsViewModel)},
                { "SVGButton", typeof (SVGButtonViewModel)},
                { "SVGTextButton", typeof (SVGTextButtonViewModel) }
            };

            ChangeControlsPanelCommand = new RelayCommand<Type>(ChangeControlPanel);

            CurrentViewModel = new HomeViewModel();
        }

        private void ChangeControlPanel(Type obj)
        {
            CurrentViewModel = Activator.CreateInstance(obj) as ObservableObject;
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
