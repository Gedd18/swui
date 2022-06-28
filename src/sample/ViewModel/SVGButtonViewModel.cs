using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows;

namespace SWUI.Sample.ViewModel
{
    public class SVGButtonViewModel : ObservableObject
    {
        public RelayCommand SmileCommand { get; private set; }

        public SVGButtonViewModel()
        {
            SmileCommand = new RelayCommand(Smile);
        }

        private void Smile()
        {
            MessageBox.Show("Smile !");
        }
    }
}
