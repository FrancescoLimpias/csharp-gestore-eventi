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
                    throw new ArgumentException($"The given Date is passed! \"{value}\"");
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
            set
            {
                //check if Capacity is positive
                if (value < 0)
                    throw new ArgumentOutOfRangeException($"The given Capacity is 0 or negative! \"{value}\"");
                _capacity = value;
            }
        }

        public int Booked { get; }

        //EVENT's CONSTRUCTOR
        internal Event(string title, DateTime date, int capacity)
        {
            Title = title;
            Date = date;
            Capacity = capacity;
            Booked = 0;
        }

        //EVENT's METHODS
        //...
    }
}
