namespace GestoreEventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Greet the user
            Console.WriteLine();
            Console.WriteLine("Welcome to EventsHandler!");
            Console.WriteLine();

            //Ask to insert an event
            Console.WriteLine("Create an Event");

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
            Console.WriteLine();
            Console.WriteLine($"Event created: {newEvent.ToString()}");

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

        }
    }
}