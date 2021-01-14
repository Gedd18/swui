using MvvmNext;
using MvvmNext.CommandWpf;
using System.Windows;

namespace SWUI.Sample.ViewModel
{
    public class SVGTextButtonViewModel : ViewModelBase
    {
        public RelayCommand SmileCommand { get; private set; }

        public SVGTextButtonViewModel()
        {
            SmileCommand = new RelayCommand(Smile);
        }

        private void Smile()
        {
            MessageBox.Show("Smile !");
        }
    }
}
