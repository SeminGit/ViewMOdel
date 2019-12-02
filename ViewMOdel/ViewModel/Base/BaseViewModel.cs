using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewMOdel.ViewModel.Base
{
    class BaseViewModel : INotifyPropertyChanged
    {
        protected object currentVM;
        protected List<ViewModel> viewModels;

        public BaseViewModel()
        {
            viewModels = new List<ViewModel>();
        }

        public void GoToWindow(string NeededViewModel)
        {
            object returnedVM = SearchVM(NeededViewModel);
            if (returnedVM == null)
                currentVM = this;
            else
                currentVM = returnedVM;
            OnPropertyChanged("CurrentVM");
        }
        private ViewModel SearchVM(string name)
        {
            for (int i = 0; i < viewModels.Count; i++)
            {
                if (viewModels[i].Name == name)
                    return viewModels[i];
            }
            return null;
        }
        public void AddVM(ViewModel newVM)
        {
            if (viewModels == null)
                viewModels = new List<ViewModel>();
            viewModels.Add(newVM);
        }
        // изменяет когда найдёт
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
