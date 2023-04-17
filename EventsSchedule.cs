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
        public List<Event> Events
        {
            get
            {
                return new List<Event>(_events);
            }
            private set
            {
                _events = value;
            }
        }
        public int NumberOfEvents => _events.Count;

        //EVENTsSCHEDULE's CONSTRUCTOR
        internal EventsSchedule(string title)
        {
            Title = title;
            Events = new List<Event>();
        }

        /* *******************
         * EVENTsSCHEDULE's METHODS
         */
        public void Add(Event e)
        {
            _events.Add(e);
        }
        public List<Event> GetEventsByDate(DateTime date)
        {
            return Events.FindAll(e => e
                    ./*event date property*/Date
                    ./*date value inside datetime object*/Date 
                    == date.Date);
        }
        public static string EventsToString(List<Event> events)
        {
            return string.Join("\r\n", events.Select(e => e.ToString()));
        }
        public void ClearEvents()
        {
            _events.Clear();
        }
        public override string ToString()
        {
            return $"{Title}:\r\n"
                + EventsToString(_events);
        }
    }
}
