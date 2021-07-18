using System;
using System.Windows.Input;

namespace MvvMCW.Service.Command
{
    public class RelayCommand:ICommand
    {
        public RelayCommand(Action<object> exec, Func<object, bool> canExec)
        {
            this.exec = exec;
            this.canExec = canExec;
        }

        private Action<object> exec;
        private Func<object, bool> canExec;

        
        
        public bool CanExecute(object parameter)
        {
            return this.canExec(parameter);
        }

        public void Execute(object parameter)
        {
            this.exec(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}