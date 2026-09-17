using AsyncDroneDash.App.Models;

namespace AsyncDroneDash.App.Services;

public class TaskRaceService
{
    public void run()
    {
        DroneModel alpha = new DroneModel
        {
            Name = "Alpha",
            MaxCheckpoints = 5,
            DelayMs = 500
        };
        Task alphaTask = Task.Run(() => FlyDrone(alpha));
    }

    public void FlyDrone(DroneModel drone)
    {
        Console.WriteLine($"{drone.Name} starter...");

        for (int i = 0; i <= drone.MaxCheckpoints; i++)
        {
            Thread.Sleep(drone.DelayMs);
            Console.WriteLine($"{drone.Name} har nå kommet til checkpoint {i} og den brukte {drone.DelayMs} ms.");
        }
        Console.WriteLine($"{drone.Name} er ferdig!");
    }
}