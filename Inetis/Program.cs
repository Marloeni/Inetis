using Inetis;

internal class Program
{
    private const int MaxSpeed = 200;

    static void Main(string[] args)
    {
        bool endApp = false;

        while (!endApp)
        {
            string? distanceInput = "";
            string? eventsInput = "";

            Console.Write("Type the distance in Km: ");
            distanceInput = Console.ReadLine();

            int cleanDistance = 0;
            while (!int.TryParse(distanceInput, out cleanDistance))
            {
                Console.Write("Invalid input, type a number: ");
                distanceInput = Console.ReadLine();
            }

            Console.Write("Type the events: ");
            eventsInput = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(eventsInput))
            {
                Console.Write("Invalid input, type the events: ");
                eventsInput = Console.ReadLine();
            }

            var journey = new Journey(MaxSpeed, cleanDistance, eventsInput);
            Console.WriteLine($"The journey will take: {journey.CalculateTotalTravelTime()} seconds");

            Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
            if (Console.ReadLine() == "n") endApp = true;
        }

        return;
    }
}