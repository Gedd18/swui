using MvvmNext;
using MvvmNext.CommandWpf;
using System.Windows;

namespace SWUI.Sample.ViewModel
{
    public class SVGButtonViewModel : ViewModelBase
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
