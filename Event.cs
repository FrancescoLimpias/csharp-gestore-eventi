using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Event
    {

        /* *******************
         * EVENT's PROPERTIES
         */
        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                //check if Title is null or empty
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException($"The given Title is empty! \"{value}\"");
                _title = value.Trim();
            }
        }

        private DateTime _date;
        public DateTime Date
        {
            get
            {
                return _date;
            }
            set
            {
                //check if Date has passed
                if (DateTime.Now > value)
                    throw new ArgumentException($"The given Date has passed! \"{value}\"");
                _date = value;
            }
        }

        private int _capacity;
        public int Capacity
        {
            get
            {
                return _capacity;
            }
            private set
            {
                //check if Capacity is positive
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"The given Capacity is 0 or negative! \"{value}\"");
                _capacity = value;
            }
        }

        public int BookedSeats { get; private set; }

        public int AvailableSeats
        {
            get
            {
                if (Capacity == 0)
                    return 0;

                return Capacity - BookedSeats;
            }
        }

        //EVENT's CONSTRUCTOR
        internal Event(string title, DateTime date, int capacity)
        {
            Title = title;
            Date = date;
            Capacity = capacity;
            BookedSeats = 0;
        }

        /* *******************
         * EVENT's METHODS
         */
        public void BookSeats(int requestedSeats)
        {
            int availableSeats = AvailableSeats;

            //event already ended
            if (DateTime.Now > Date)
                throw new Exception("This Event has already passed!");
            //check if requirements are met
            if (availableSeats < requestedSeats)
                throw new Exception($"The seats availability({availableSeats}) is lower than the requested number of seats({requestedSeats})! Excess: {requestedSeats - availableSeats}");
            //save booked seats
            BookedSeats += requestedSeats;
        }

        public void CancelBookedSeats(int canceledSeats)
        {
            //event already ended
            if (DateTime.Now > Date)
                throw new Exception("This Event has already passed!");
            //seats cancelation overflow
            if (canceledSeats > BookedSeats)
                throw new Exception($"Trying to cancel more seats({canceledSeats}) that booked({BookedSeats})! Excess: {canceledSeats - BookedSeats}");
            //cancel seats
            BookedSeats -= canceledSeats;
        }

        public override string ToString()
        {
            //return $"{Date.ToString("dd/MM/yyyy")} - {Title}";
            return $"[{DateTimeToString()}] {Title}";
        }

        public string StatusToString()
        {
            return 
                $"Booked seats: {BookedSeats}\r\n"
                + $"Available seats: {AvailableSeats}";
        }
        public string DateTimeToString()
        {
            return Date.ToString();
        }
    }
}
