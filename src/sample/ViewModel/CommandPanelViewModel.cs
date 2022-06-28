using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Windows;

namespace SWUI.Sample.ViewModel
{
    public class CommandPanelViewModel : ObservableObject
    {
        public RelayCommand ShowMessageCommand { get; private set; }

        public string Message { get; set; }

        public CommandPanelViewModel ()
        {
            Message = "Hello world !";
            ShowMessageCommand  = new RelayCommand(ShowMessage);
        }

        private void ShowMessage()
        {
            MessageBox.Show( Message, "Message");
        }
    }
}
