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
        }
    }
}