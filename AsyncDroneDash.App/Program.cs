using AsyncDroneDash.App.Menus;
using AsyncDroneDash.App.Services;


MainMenu mainMenu = new MainMenu();
ThreadRaceService threadRaceService = new ThreadRaceService();
TaskRaceService taskRaceService = new TaskRaceService();
AsyncRaceService asyncRaceService = new AsyncRaceService();

bool programRunning = true;
while (programRunning)
{
    mainMenu.Show();

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            threadRaceService.Run();
            break;

        case "2":
            await taskRaceService.Run();
            break;

        case "3":
            await asyncRaceService.Run();
            break;

        case "0":
            programRunning = false;
            break;

        default:
            Console.WriteLine("Ugyldig valg...");
            break;
    }
}

// threadRaceService.Run();
// await taskRaceService.Run();
// await asyncRaceService.Run();