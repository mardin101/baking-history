namespace BakingHistory.Models;

public class BakingEntry
{
    public int Id { get; set; }
    public string TypeOfBake { get; set; } = string.Empty;
    public double WaterTemperature { get; set; }
    public double FlourTemperature { get; set; }
    public double RoomTemperature { get; set; }
    public double DoughTemperature { get; set; }
    public DateTime EndTimeOfKneading { get; set; }
    public TimeSpan BulkFermentTime { get; set; }
    public DateTime TimeOfShaping { get; set; }
    public DateTime TimeOfBaking { get; set; }
    public string Comment { get; set; } = string.Empty;
}
