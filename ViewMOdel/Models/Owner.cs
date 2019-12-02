using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ViewMOdel.Models
{
    public class Owner : INotifyPropertyChanged
    {
        private string fName;
        private string lName;
        private string phoneNumber;
        private string emailAdress;

        public string FName
        {
            get => fName;
            set
            {
                fName = value;
                OnPropertyChanged("FName");
            }
        }
        public string LName
        {
            get => lName;
            set
            {
                lName = value;
                OnPropertyChanged("LName");
            }
        }
        public string PhoneNumber
        {
            get => phoneNumber;
            set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsDigit(value[i])) { return; }
                }
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }
        public string EmailAdress
        {
            get => emailAdress;
            set
            {
                if (value.Contains("@")) emailAdress = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
