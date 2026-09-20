using AsyncDroneDash.App.Models;

namespace AsyncDroneDash.App.Services;

public class AsyncRaceService
{
    public async Task FlyDroneAsync(DroneModel drone)
    {
        Console.WriteLine($"{drone.Name} starter...");

        for (int i = 0; i <= drone.MaxCheckpoints; i++)
        {
            await Task.Delay(drone.DelayMs);
            if (drone.Name == "Alpha" && i == 3)
            {
                throw new Exception("Simulert feil: Alpha fikk en feil ved checkpoint 3!");
            }

            Console.WriteLine($"{drone.Name} har kommet til checkpoint {i} og den brukte {drone.DelayMs} ms.");
        }
        Console.WriteLine($"{drone.Name} er ferdig");
    }

    public async Task Run()
    {
        DroneModel alpha = new DroneModel
        {
            Name = "Alpha",
            MaxCheckpoints = 5,
            DelayMs = 500
        };

        DroneModel bravo = new DroneModel
        {
            Name = "Bravo",
            MaxCheckpoints = 5,
            DelayMs = 200
        };

        DroneModel charlie = new DroneModel
        {
            Name = "Charlie",
            MaxCheckpoints = 5,
            DelayMs = 700
        };

        DroneModel delta = new DroneModel
        {
            Name = "Delta",
            MaxCheckpoints = 5,
            DelayMs = 400
        };

        Task alphaTask = FlyDroneAsync(alpha);
        Task bravoTask = FlyDroneAsync(bravo);
        Task charlieTask = FlyDroneAsync(charlie);
        Task deltaTask = FlyDroneAsync(delta);

        try
        {
            await Task.WhenAll(
                alphaTask,
                bravoTask,
                charlieTask,
                deltaTask
        );
            Console.WriteLine("Alle droner er fardige! (AsyncRace)");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En drone feilet: {ex.Message}");
        }
    }
}