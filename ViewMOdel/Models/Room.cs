using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace ViewMOdel.Models
{
    public class Room : INotifyPropertyChanged
    {
        public readonly string roomType;
        protected readonly double price;
        private bool available;
        private Owner owner;
        protected DateTime enterDate;
        private DateTime leaveDate;
        protected readonly int numberOfRooms;
        protected readonly int numberOfVisitors;

        public Room(string name, double price, int numberOfRooms, int numberOfVisitos, bool available, string roomType)
        {
            this.Name = name;
            this.price = price;
            this.numberOfRooms = numberOfRooms;
            this.numberOfVisitors = numberOfVisitors;
            this.available = available;
            this.roomType = roomType;
        }
        public string Name { get; set; }

        public bool Available { get => available; set => available = value; }
        public Owner Owner { get => owner; set => owner = value; }
        public DateTime LeavingDate
        {
            get => leaveDate; set
            {
                leaveDate = value;
                OnPropertyChanged("LeavingDate");
            }
        }
        public DateTime EntrenceDate
        {
            get => enterDate;
            set
            {
                enterDate = value;
                OnPropertyChanged("EntrenceDate");
            }
        }
        public string RoomType
        {
            get => roomType;
        }
        public int NumberOfRooms
        {
            get => numberOfRooms;
        }
        public int NumberOfVisitors 
        {
            get => numberOfVisitors;
        }

        public double Price
        {
            get => price;
        }
        // изменение данных ////////////
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        /////////////////////
    } 
}
    
