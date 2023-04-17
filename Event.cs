using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Event
    {

        //EVENT's PROPERTIES
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int Capacity { get; }
        public int Booked { get; }

        //EVENT's CONSTRUCTOR
        internal Event()
        {

        }

        //EVENT's METHODS
        //...
    }
}
