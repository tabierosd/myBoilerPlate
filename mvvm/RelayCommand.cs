
    public class RelayCommand : ICommand
    {

        Predicate<object> CanExecuteFunc = null;
        Action<object> ExecuteAction = null;

        public RelayCommand(Predicate<object> canExecute = null, Action<object> action = null)
        {
            this.CanExecuteFunc = canExecute;
            this.ExecuteAction = action;
        }
        
        public bool CanExecute(object parameter)
        {
            if(this.CanExecuteFunc == null)
            {
                return true;
            }
            return this.CanExecuteFunc(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)
        {
            if(this.ExecuteAction == null)
            {
                return;
            }

            this.ExecuteAction(parameter);
        }
    }