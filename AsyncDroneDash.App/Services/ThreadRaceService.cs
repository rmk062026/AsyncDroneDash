using System.IO.Compression;
using AsyncDroneDash.App.Models;

namespace AsyncDroneDash.App.Services;

public class ThreadRaceService
{
    public void Run()
    {
        DroneModel alpha = new DroneModel()
        {
            Name = "Alpha",
            MaxCheckpoints = 5,
            DelayMs = 500
        };

        DroneModel bravo = new DroneModel()
        {
            Name = "Bravo",
            MaxCheckpoints = 5,
            DelayMs = 800
        };

        DroneModel charlie = new DroneModel()
        {
            Name = "Charlie",
            MaxCheckpoints = 5,
            DelayMs = 1200
        };

        DroneModel delta = new DroneModel()
        {
            Name = "Delta",
            MaxCheckpoints = 5,
            DelayMs = 700
        };


        Thread alphaThread = new Thread(() => FlyDrone(alpha));
        Thread bravoThread = new Thread(() => FlyDrone(bravo));
        Thread charlieThread = new Thread(() => FlyDrone(charlie));
        Thread deltaThread = new Thread(() => FlyDrone(delta));
        alphaThread.Start();
        bravoThread.Start();
        charlieThread.Start();
        deltaThread.Start();
        // alphaThread.Join();
        // bravoThread.Join();
        // charlieThread.Join();
        // deltaThread.Join();
        // FlyDrone(alpha);
        // FlyDrone(bravo);
        // FlyDrone(charlie);
        // FlyDrone(delta);

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