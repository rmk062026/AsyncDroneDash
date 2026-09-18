using AsyncDroneDash.App.Models;

namespace AsyncDroneDash.App.Services;

public class TaskRaceService
{
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

        TaskCompletionSource alphaCompletion = new TaskCompletionSource();
        TaskCompletionSource bravoCompletion = new TaskCompletionSource();
        TaskCompletionSource charlieCompletion = new TaskCompletionSource();
        TaskCompletionSource deltaCompletion = new TaskCompletionSource();

        Task alphaTask = Task.Run(() =>
        {
            FlyDrone(alpha);
            alphaCompletion.SetResult();
        });

        Task bravoTask = Task.Run(() =>
        {
            FlyDrone(bravo);
            bravoCompletion.SetResult();
        });

        Task charlieTask = Task.Run(() =>
        {
            FlyDrone(charlie);
            charlieCompletion.SetResult();
        });

        Task deltaTask = Task.Run(() =>
        {
            FlyDrone(delta);
            deltaCompletion.SetResult();
        });
        Console.WriteLine($"alphaTask status: {alphaTask.Status}");
        Console.WriteLine($"alphaCompletion.Task status: {alphaCompletion.Task.Status}");

        Console.WriteLine($"bravoTask status: {bravoTask.Status}");
        Console.WriteLine($"bravoCompletion.Task status: {bravoCompletion.Task.Status}");

        Console.WriteLine($"charlieTask status: {charlieTask.Status}");
        Console.WriteLine($"charlieCompletion.Task status: {charlieCompletion.Task.Status}");

        Console.WriteLine($"deltaTask status: {deltaTask.Status}");
        Console.WriteLine($"deltaCompletion.Task status: {deltaCompletion.Task.Status}");

        await Task.WhenAll(
            alphaCompletion.Task,
            bravoCompletion.Task,
            charlieCompletion.Task,
            deltaCompletion.Task
        );
        Console.WriteLine("Alle droner er ferdige!");
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