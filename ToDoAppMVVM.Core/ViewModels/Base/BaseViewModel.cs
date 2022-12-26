using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoAppMVVM.Core.ViewModels.Base
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        //klasa stworzona by wszystkie view modele dziedzicyły po niej, w niej implementujemy interface INotifyPropertyChanged
        //aby można było zmieniać przez binding wartości kontrolek w GUI

        public event PropertyChangedEventHandler PropertyChanged = (sender, eventArgs) => { };

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
