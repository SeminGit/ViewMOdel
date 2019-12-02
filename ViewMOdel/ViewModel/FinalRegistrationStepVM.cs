using System;
using ViewMOdel.Commands;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewMOdel.ViewModel
{
    class FinalRegistrationStepVM : ViewModel
    {
        private double finalPrice;
        private int numberOfDays;
        private DateTime entrenceDate;
        private DateTime leavingDate;
        private RelayCommand bookCommand;
        private RelayCommand cancelCommand;


        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand(
                    obj =>
                    {
                        
                        Root.GoToWindow("BookViewModel");
                    }
                    ));
            }
        }
        public RelayCommand BookCommand
        {
            get
            {
                return bookCommand ?? (bookCommand = new RelayCommand(
                    obj =>
                    {
                        Root.SelectedRoom.EntrenceDate = EntrenceDate;
                        Root.SelectedRoom.LeavingDate = LeavingDate;
                        Root.SelectedRoom.Available = false;
                        Root.GoToWindow("GoViewModel");
                    }
                    ));
            }
        }
        public double FinalPrice
        {
            get => finalPrice;
            set
            {
                finalPrice = Root.SelectedRoom.Price * NumberOfDays;
                OnPropertyChanged("FinalPrice");
            }
        }
        public int NumberOfDays
        {
            get => numberOfDays;
            set
            {
                numberOfDays = value;
                FinalPrice = Root.SelectedRoom.Price * numberOfDays;

                LeavingDate = EntrenceDate.AddDays(numberOfDays);
                
                OnPropertyChanged("NumberOfDays");

            }
        }
        public DateTime EntrenceDate
        {
            get
            {
                return entrenceDate;
            }
                set
            {
                entrenceDate = value;
                OnPropertyChanged("EntrenceDate");
            }
        }
        public DateTime LeavingDate
        {
            get 
            {
                return leavingDate;
            }
            set
            {
                leavingDate = value;
                OnPropertyChanged("LeavingDate");
            }
        }
        public FinalRegistrationStepVM(string name, RootViewModel root) : base(name, root)
        {
        }
    }
}
