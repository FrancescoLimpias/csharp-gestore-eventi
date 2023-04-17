using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestoreEventi
{
    internal class EventsSchedule
    {
        /* *******************
         * EVENTsSCHEDULE's PROPERTIES
         */
        public string Title { get; set; }

        private List<Event> _events;
        public List<Event> Events {
            get
            {
                return new List<Event>(_events);
            }
            private set
            {
                _events = value;
            }
        }

        //EVENTsSCHEDULE's CONSTRUCTOR
        internal EventsSchedule(string title) {
            Title = title;
            Events = new List<Event>();
        }
    }
}
