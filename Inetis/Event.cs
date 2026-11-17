namespace Inetis;

abstract internal class Event
{
    protected abstract int Distance { get; }
    protected abstract int ActualSpeed { get; }
    private readonly int maxSpeed;
    internal double AdditionalTravelTime { get; }

    protected Event(int maxSpeed)
    {
        this.maxSpeed = maxSpeed;
        AdditionalTravelTime = CalculateAdditionalTime();
    }

    private double CalculateAdditionalTime()
    {
        return (double)Distance / ActualSpeed - (double)Distance / maxSpeed;
    }
}

internal class DepartureOrTerminusStationEvent(int maxSpeed) : Event(maxSpeed)
{
    protected override int Distance => 5;
    protected override int ActualSpeed => 50;
}

internal class StationEvent(int maxSpeed) : Event(maxSpeed)
{
    protected override int Distance => 10;
    protected override int ActualSpeed => 50;
}

internal class PowerBreakEvent(int maxSpeed) : Event(maxSpeed)
{
    protected override int Distance => 10;
    protected override int ActualSpeed => 5;
}

internal class NaturalIncidentEvent(int maxSpeed) : Event(maxSpeed)
{
    protected override int Distance => 5;
    protected override int ActualSpeed => 10;
}
