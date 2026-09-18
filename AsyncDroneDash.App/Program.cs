using AsyncDroneDash.App.Services;

ThreadRaceService threadRaceService = new ThreadRaceService();
TaskRaceService taskRaceService = new TaskRaceService();

// threadRaceService.Run();
await taskRaceService.Run();