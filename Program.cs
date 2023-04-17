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
            DateTime date = UConsole.AskStringToCast((input) => DateTime.Parse(input + ":00"));

            //Ask for its capacity
            Console.Write("Please, insert a Capacity: ");
            int capacity = UConsole.AskStringToCast((input) => Convert.ToInt32(input));



            //Event e = new Event("Evento Prova", new DateTime(2023, 10, 4, 9, 13, 10), 100);
            //Console.WriteLine(e.ToString());
        }
    }
}