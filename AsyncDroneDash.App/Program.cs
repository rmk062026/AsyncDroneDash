using AsyncDroneDash.App.Services;

ThreadRaceService threadRaceService = new ThreadRaceService();
TaskRaceService taskRaceService = new TaskRaceService();
AsyncRaceService asyncRaceService = new AsyncRaceService();

// threadRaceService.Run();
// await taskRaceService.Run();
await asyncRaceService.Run();