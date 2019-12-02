using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows.Input;

namespace ViewMOdel.Commands
{
        class RelayCommand : ICommand
        {
            //магия комманд. Знаю для чего и как работают, но не совсем понимаю все равно :slight_smile: 
            //_execute - действие которое выполнит команда, которое я ей передам
            //_canExecute - условие, действия, если оно F, то действие не будет выполнятся

            private Action<object> _execute;
            private Func<object, bool> _canExecute;

            public event EventHandler CanExecuteChanged
            {
                add { CommandManager.RequerySuggested += value; }
                remove { CommandManager.RequerySuggested -= value; }
            }

            public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
            {
                this._execute = execute;
                this._canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return this._canExecute == null || this._canExecute(parameter);
            }

            public void Execute(object parameter)
            {
                this._execute(parameter);
            }
        }
    }

