namespace NewEquipmentManagement.ConsoleApp.Shared;

public class Utils
{
    const int MenuWidth = 38;

    public static void AnyKeyPrompt()
    {
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public static int GetValidOption(int min, int max)
    {
        int option;
        Console.WriteLine();
        Console.Write("Enter an option -> ");
        while (!int.TryParse(Console.ReadLine(), out option) || option < min || option > max)
            Console.Write("Invalid option, try again -> ");
        return option;
    }

    public static void Header(string title)
    {
        int padding = (MenuWidth - title.Length) / 2;
        Console.WriteLine("┌" + new string('─', MenuWidth) + "┐");
        Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(MenuWidth) + "│");
        Console.WriteLine("└" + new string('─', MenuWidth) + "┘");
    }
    public static void Header(string title, int customWidth)
    {
        int padding = (customWidth - title.Length) / 2;
        Console.WriteLine("┌" + new string('─', customWidth) + "┐");
        Console.WriteLine("│" + title.PadLeft(padding + title.Length).PadRight(customWidth) + "│");
        Console.WriteLine("└" + new string('─', customWidth) + "┘");
    }
}
