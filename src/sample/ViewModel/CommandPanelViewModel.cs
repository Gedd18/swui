using MvvmNext;
using MvvmNext.CommandWpf;
using System;
using System.Windows;

namespace SWUI.Sample.ViewModel
{
    public class CommandPanelViewModel : ViewModelBase
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
