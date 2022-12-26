using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ToDoAppMVVM.Core.Helpers
{
    public class RelayCommand : ICommand
    {
        private Action action; // przechowuje funkcje, która nic nie przyjmuje ani nie zwraca
        public event EventHandler? CanExecuteChanged;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action();
        }
    }
}
