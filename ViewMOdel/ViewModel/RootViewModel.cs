using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewMOdel.ViewModel.Base;

namespace ViewMOdel.ViewModel
{
    class RootViewModel : BaseViewModel
    {
        public int shtuka;

        public RootViewModel()
        {
            // ставим 1-ую изначально
            AddVM(new GoVM("GoViewModel", this));
            AddVM(new BackVM("BackViewModel", this));
        }
        public object CurrentVM
        {
            get
            {
                if (currentVM == null)
                {
                    // ставим 1-ую изначально
                    currentVM = viewModels[0];
                    CurrentVM = currentVM;
                }

                if (currentVM == this)
                {
                    // закрываем если шо
                    System.Windows.Application.Current.Shutdown();
                }

                return currentVM;
            }
            set
            {
                currentVM = value;
                OnPropertyChanged("CurrentVM");
            }
        }
    }
}
