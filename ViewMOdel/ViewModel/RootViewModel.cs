using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewMOdel.ViewModel.Base;
using ViewMOdel.Models;
using System.Collections.ObjectModel;

namespace ViewMOdel.ViewModel
{
    class RootViewModel : BaseViewModel
    {
        private ObservableCollection<Room> rooms;
        private Room selectedRoom;

        public Room SelectedRoom
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                OnPropertyChanged("SelectedRoom");
            }
        }
        
        public ObservableCollection<Room> Rooms
        {
            get => rooms;
            set
            {
                rooms = value;
                OnPropertyChanged("Rooms");
            }
        }
        public RootViewModel()
        {
            rooms = new ObservableCollection<Room>
            {
                new Room("110",100,1,2,true,"Economy"),
                new Room("417",200,2,1,true,"Lux")
            };
            // ставим 1-ую изначально
            AddVM(new GoVM("GoViewModel", this));
            AddVM(new BackVM("BackViewModel", this));
            AddVM(new BookVM("BookViewModel",this));
            AddVM(new ChoosingRoomVM("ChoosingRoomViewModel", this));
            AddVM(new FinalRegistrationStepVM("FinalRegistrationStepViewModel", this));
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
