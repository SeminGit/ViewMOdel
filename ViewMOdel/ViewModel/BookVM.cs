using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   
using ViewMOdel.Models;
using System.Windows.Input;
using ViewMOdel.Commands;
using System.ComponentModel;
using System.Runtime.CompilerServices;



namespace ViewMOdel.ViewModel
{
    class BookVM : ViewModel
    {
        private DateTime entrenceDate;
        private DateTime leavingDate;
        private RelayCommand finishBooking;
        private RelayCommand backCommand;

        private Owner owner = new Owner();
        public string FirstName
        {
            get 
            {
                if (!(owner.FName == null)) return owner.FName;
                else return "";
            }
            set
            {
                owner.FName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string LastName
        {
            get
            {
                if (owner != null && owner.LName != null)
                    return owner.LName;
                else return "";
            }
            set
            {
                owner.LName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string PhoneNumber
        {
            get
            {
                if (owner != null && owner.PhoneNumber != null)
                    return owner.PhoneNumber;
                else return "";
            }
            set
            {
                owner.PhoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public Owner Owner
        {
            get => owner;   
            set
            {
                owner = value;
                OnPropertyChanged("Owner");
            }
        }
        public RelayCommand FinishBookingCommand
        {
            get
            {
                return finishBooking ?? (finishBooking = new RelayCommand(
                    obj =>
                    {
                        Root.SelectedRoom.Owner = owner;
                        Root.GoToWindow("FinalRegistrationStepViewModel");
                    }
                    ));
            }
        }
        public RelayCommand BackCommand
        {
            get
            {
                return backCommand ?? (backCommand = new RelayCommand(
                    obj =>
                    {
                        /*
                        Root.SelectedRoom.Owner.FName = "";
                        Root.SelectedRoom.Owner.LName = "";
                        Root.SelectedRoom.Owner.PhoneNumber = "";
                        Root.SelectedRoom.Owner.EmailAdress = "";
                        */
                        //if(owner.FName != "" || owner.LName != "" || owner.PhoneNumber != "" || owner.EmailAdress != "")
                        Root.SelectedRoom.Owner = new Owner();
                        Root.GoToWindow("ChoosingRoomViewModel");
                    }
                    ));
            }
        }

        public BookVM(string name, RootViewModel root) : base(name, root)
        {
        }
    }
}
