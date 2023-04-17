using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class Conference : Event
    {
        /* *******************
         * CONFERENCE's PROPERTIES
         */
        public string Speaker { get; private set; }

        public double Price { get; private set; }

        //CONFERNCE's CONSTRUCTOR
        internal Conference(string title, DateTime date, int capacity, string speaker, double price) : base(title, date, capacity)
        {
            Speaker = speaker;
            Price = price;
        }

        /* *******************
         * CONFERENCE's METHODS
         */
        public string PriceToString()
        {
            return Price.ToString("0.00");
        }
        public override string ToString()
        {
            return $"[{DateTimeToString()}] {Title}, by {Speaker} for {PriceToString()} Euros";
        }

    }
}
