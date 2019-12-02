using ViewMOdel.Models;
using System.Collections.ObjectModel;
using ViewMOdel.Commands;
using System.Windows.Data;  

namespace ViewMOdel.ViewModel
{
    class ChoosingRoomVM : ViewModel
    {
        private Room selectedRoom;
        private ObservableCollection<Room> listOfRooms;
        private RelayCommand economyTypeButtonCommand;

        public RelayCommand EconomyTypeButtonCommand
        {
            get
            {
                return economyTypeButtonCommand ?? (economyTypeButtonCommand = new RelayCommand(
                    obj =>
                    {
                        ObservableCollection<Room> list = new ObservableCollection<Room>();
                        for (int i = 0; i < Root.Rooms.Count; i++)
                        {
                            if (Root.Rooms[i].roomType == "Economy") list.Add(Root.Rooms[i]);
                        }
                        ListOfRooms = list;
                    }
                    ));
            }
        }
        public ObservableCollection<Room> ListOfRooms
        {
            get => listOfRooms;
            set
            {
                listOfRooms = value;
                OnPropertyChanged("ListOfRooms");
            }
        }
        public Room SelectedRoom
        {
            get => selectedRoom;
            set
            {
                selectedRoom = value;
                Root.SelectedRoom = selectedRoom;
                OnPropertyChanged("SelectedRoom");
            }
        }
        public ChoosingRoomVM(string name, RootViewModel root) : base(name, root)
        {
            
        }
    }
}
