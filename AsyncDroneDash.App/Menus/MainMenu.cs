namespace AsyncDroneDash.App.Menus;

public class MainMenu
{
    public void Show()
    {
        Console.WriteLine("""

            **** Async Drone Dash ***

            1. Thread + Join
            2. Task + TaskCompletionSource
            3. Async / await
            0. Avslutt
        """);
        Console.WriteLine("Velg: ");
    }
}