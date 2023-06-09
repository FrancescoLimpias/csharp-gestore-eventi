﻿namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Greet the user
            Console.WriteLine();
            Console.WriteLine("\tWelcome to EventsHandler!");
            Console.WriteLine();

            //Create an EventsSchedule
            Console.WriteLine("EVENTS SCHEDULE");

            //Ask for its title
            Console.Write("Please, insert a Title: ");
            string scheduleTitle = UConsole.AskString();

            //Ask for the number of hosted events
            Console.Write("Please, insert a Number of Events: ");
            int scheduleNumberOfEvents = UConsole.AskInt();

            //Instantiate EventsSchedule
            EventsSchedule ES = new EventsSchedule(scheduleTitle);

            //Loop until the desired amount of events it's reached
            while (ES.NumberOfEvents < scheduleNumberOfEvents)
            {
                Console.WriteLine();

                Event newEvent;
                try
                {
                    //Insert an event
                    Console.WriteLine("EVENT");
                    newEvent = AskToCreateEvent();
                    Console.WriteLine($"Event created: {newEvent.ToString()}");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERR - {e.Message}");
                    continue;
                }

                //Finally add the event to the schedule
                ES.Add(newEvent);
            }

            /* ***********
             * ADDING CONFERNCES
             */
            while (ES.NumberOfEvents < scheduleNumberOfEvents + 1)
            {
                Console.WriteLine();

                Conference newConference;
                try
                {
                    //Insert an event
                    Console.WriteLine("CONFERENCE");
                    newConference = AskToCreateConference();
                    Console.WriteLine($"Conference created: {newConference.ToString()}");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERR - {e.Message}");
                    continue;
                }

                //Finally add the event to the schedule
                ES.Add(newConference);
            }



            /* ***********
             * PRINTING
             */
            //details
            Console.WriteLine();
            Console.WriteLine("OVERVIEW");
            Console.WriteLine($"Number of events: {ES.NumberOfEvents}");
            Console.WriteLine(ES.ToString());
            Console.WriteLine();

            //date select
            Console.WriteLine("DATE SELECTED EVENTS");
            Console.Write("Please, insert a Date of Events to print (dd/MM/yyyy): ");
            DateTime dateToSelect = UConsole.AskStringToCast((input) => DateTime.Parse(input + " 12:00:00"));
            Console.WriteLine(EventsSchedule.EventsToString(ES.GetEventsByDate(dateToSelect)));

            //empty
            Console.WriteLine();
            ES.ClearEvents();
            Console.WriteLine("Cleared Events");

            //goodbye
            Console.WriteLine();
            Console.WriteLine("Bye");

        }

        internal static Conference AskToCreateConference()
        {
            //Get main event parameters
            Event? baseConferenceEvent = null;
            while (baseConferenceEvent == null)
            {
                try
                {
                    baseConferenceEvent = AskToCreateEvent();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"ERR - {e.Message}");
                }
            }

            //ASk for its speaker
            Console.Write("Please, insert the Speaker: ");
            string conferenceSpeaker = UConsole.AskString();

            //Ask for the price
            Console.Write("Please, insert the Price: ");
            double conferencePrice = UConsole.AskStringToCast((price) => Convert.ToDouble(price));

            //Instantiate Conference
            return new Conference(baseConferenceEvent.Title, baseConferenceEvent.Date, baseConferenceEvent.Capacity, conferenceSpeaker, conferencePrice);

        }

        internal static Event AskToCreateEvent()
        {

            //ASk for its title
            Console.Write("Please, insert a Title: ");
            string eventName = UConsole.AskString();

            //Ask for its date
            Console.Write("Please, insert a Date (dd/MM/yyyy hh:mm): ");
            DateTime eventDate = UConsole.AskStringToCast((input) => DateTime.Parse(input + ":00"));

            //Ask for its capacity
            Console.Write("Please, insert a Capacity: ");
            int eventCapacity = UConsole.AskInt();

            //Instantiate Event
            Event newEvent = new Event(eventName, eventDate, eventCapacity);

            /* THIS WAS FOR MILESTONE 2
            //Ask for booked seats
            Console.Write("Please, insert booked seats: ");
            newEvent.BookSeats(UConsole.AskInt());


            bool cancel;
            do
            {

                //Print Availability Status
                Console.WriteLine();
                Console.WriteLine(newEvent.StatusToString());

                //Ask if wanting to cancel some reservations
                Console.WriteLine();
                Console.Write("Do you want to cancel some bookings? (Yes/No) ");
                cancel = UConsole.AskStringToCast((input) =>
                {
                    input = input.ToUpper();
                    if (!input.Equals("YES") && !input.Equals("NO"))
                        throw new FormatException($"String cannot be parsed! \"{input}\"");

                    return input.Equals("YES");
                });

                //How many seats to cancel?
                if (cancel)
                {
                    Console.Write("How many seats would you like to cancel? ");
                    newEvent.CancelBookedSeats(UConsole.AskInt());
                }

            } while (cancel);
            */

            return newEvent;
        }


    }
}