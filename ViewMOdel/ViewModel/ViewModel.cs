using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using ViewMOdel.ViewModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ViewMOdel.Commands;

namespace ViewMOdel.ViewModel
{
    class ViewModel : INotifyPropertyChanged
    {
        public string Name
        {
            get;
            set;
        }
        private RelayCommand command;
        public object GoTo
        {
            get
            {
                return command ??
                    (command = new RelayCommand(obj =>
                    {
                        string neededToOpen = obj as string;
                        Root.GoToWindow(neededToOpen);
                    }));
            }
        }
        public ViewModel(string name, RootViewModel root)
        {
            Name = name;
            Root = root;
        }
        public RootViewModel Root { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
