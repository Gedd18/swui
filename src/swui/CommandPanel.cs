using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWUI
{
    public class CommandPanel : Border
    {
        
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register(
                "Command",
                typeof(ICommand),
                typeof(CommandPanel),
                new PropertyMetadata(null));

        public static readonly DependencyProperty ParameterProperty =
            DependencyProperty.Register(
                "Parameter",
                typeof(object),
                typeof(CommandPanel),
                new PropertyMetadata(null));


        public object Parameter
        {
            get { return (object)GetValue(ParameterProperty); }
            set { SetValue(ParameterProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public CommandPanel()
        { 
            this.MouseUp += ActionControl_MouseUp;
        }

        private void ActionControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Command?.Execute(Parameter);
        }
    }
}
