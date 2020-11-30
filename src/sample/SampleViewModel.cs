﻿using MvvmNext;
using MvvmNext.Command;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using SWUI.Sample.ViewModel;

namespace SWUI.Sample
{
    public class SampleViewModel : ViewModelBase
    {

        public RelayCommand<Type> ChangeControlsPanelCommand { get; private set; }

        public Dictionary<string, Type> ControlsItemList { get => _controlsItemDic; }

        Dictionary<string, Type> _controlsItemDic;

        public ViewModelBase CurrentViewModel { get; private set; }

        public SampleViewModel() 
        {
            _controlsItemDic = new Dictionary<string, Type> {
                { "CommandPanel", typeof(CommandPanelViewModel)},
                { "DropBorder", typeof(DropBorderViewModel)},
                { "WindowStateButtons", typeof(WindowStateButtonsViewModel)},
                { "SVGButton", typeof (SVGButtonViewModel)}
            };

            ChangeControlsPanelCommand = new RelayCommand<Type>(ChangeControlPanel);

            CurrentViewModel = new HomeViewModel();
        }

        private void ChangeControlPanel(Type obj)
        {
            CurrentViewModel = Activator.CreateInstance(obj) as ViewModelBase;
            RaisePropertyChanged(() => CurrentViewModel);
        }
    }
}