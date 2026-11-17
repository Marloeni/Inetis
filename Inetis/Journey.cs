namespace Inetis;

public class Journey
{
    private List<Event> events;
    private readonly int maxSpeed;
    private readonly int totalDistance;

    public Journey(int maxSpeed, int totalDistance, string rawEvents)
    {
        this.maxSpeed = maxSpeed;
        this.totalDistance = totalDistance;
        events = ParseRawEvents(rawEvents);
    }

    private List<Event> ParseRawEvents(string rawEvents)
    {
        const char StationSymbol = 'T';
        const char PowerBreakSymbol = 'P';
        const char NaturalIncidentSymbol = 'N';

        List<Event> parsedEvents = new List<Event>();

        if (rawEvents.StartsWith(StationSymbol))
        {
            parsedEvents.Add(new DepartureOrTerminusStationEvent(maxSpeed));
            rawEvents = rawEvents[1..];
        }

        if (rawEvents.EndsWith(StationSymbol))
        {
            parsedEvents.Add(new DepartureOrTerminusStationEvent(maxSpeed));
            rawEvents = rawEvents[..^1];
        }

        foreach (char rawEvent in rawEvents)
        {
            if (rawEvent == StationSymbol) parsedEvents.Add(new StationEvent(maxSpeed));
            if (rawEvent == PowerBreakSymbol) parsedEvents.Add(new PowerBreakEvent(maxSpeed));
            if (rawEvent == NaturalIncidentSymbol) parsedEvents.Add(new NaturalIncidentEvent(maxSpeed));
        }

        return parsedEvents;
    }

    public int CalculateTotalTravelTime()
    {
        double baseTravelTime = (double)totalDistance / maxSpeed;
        double totalEventsTravelTime = events.Select(x => x.AdditionalTravelTime).Sum();

        return (int)Math.Round((baseTravelTime + totalEventsTravelTime) * 3600);
    }
}
