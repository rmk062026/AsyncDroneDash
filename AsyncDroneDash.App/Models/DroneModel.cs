namespace AsyncDroneDash.App.Models;

public class DroneModel
{
    public string Name { get; set; } = "";
    public int MaxCheckpoints { get; set; }
    public int DelayMs { get; set; }
}