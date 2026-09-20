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

        Task alphaTask = RunDroneTask(alpha);
        Task bravoTask = RunDroneTask(bravo);
        Task charlieTask = RunDroneTask(charlie);
        Task deltaTask = RunDroneTask(delta);


        Console.WriteLine($"alphaTask status: {alphaTask.Status}");
        Console.WriteLine($"bravoTask status: {bravoTask.Status}");
        Console.WriteLine($"charlieTask status: {charlieTask.Status}");
        Console.WriteLine($"deltaTask status: {deltaTask.Status}");

        try
        {
            await Task.WhenAll(
                alphaTask,
                bravoTask,
                charlieTask,
                deltaTask
            );
            Console.WriteLine("Alle droner er ferdige!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"En drone feilet: {ex.Message}");
        }
    }

    public Task RunDroneTask(DroneModel drone)
    {
        TaskCompletionSource completion = new TaskCompletionSource();

        Task.Run(() =>
        {
            try
            {
                FlyDrone(drone);
                completion.SetResult();
            }
            catch (Exception ex)
            {
                completion.SetException(ex);
            }
        });
        return completion.Task;
    }

    public void FlyDrone(DroneModel drone)
    {
        Console.WriteLine($"{drone.Name} starter...");

        for (int i = 0; i <= drone.MaxCheckpoints; i++)
        {
            Thread.Sleep(drone.DelayMs);
            if (drone.Name == "Alpha" && i == 3)
            {
                throw new Exception("Alpha fikk en feil ved checkpoint 3!");
            }
            Console.WriteLine($"{drone.Name} har nå kommet til checkpoint {i} og den brukte {drone.DelayMs} ms.");
        }
        Console.WriteLine($"{drone.Name} er ferdig!");
    }
}