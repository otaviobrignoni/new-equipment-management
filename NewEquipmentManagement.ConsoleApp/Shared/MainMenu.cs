using NewEquipmentManagement.ConsoleApp.EquipmentModule;
using NewEquipmentManagement.ConsoleApp.ManufaturerModule;

namespace NewEquipmentManagement.ConsoleApp.Shared;
public class MainMenu
{

    public static ManufacturerUI manufacturerUI = new ManufacturerUI();
    public static EquipmentUI equipmentUI = new EquipmentUI(manufacturerUI);

    public static void Show()
    {
        string title = "Management";
        bool leaveOptionSelected = false;
        while (!leaveOptionSelected)
        {
            Console.Clear();
            Utils.Header(title);
            Console.WriteLine();
            Console.WriteLine("1 - Manage Manufacturers");
            Console.WriteLine("2 - Manage Equipments");
            Console.WriteLine("3 - Manage Calls");
            Console.WriteLine("4 - Leave");
            switch (Utils.GetValidOption(1, 4))
            {
                case 1:
                    manufacturerUI.Show();
                    break;
                case 2:
                    equipmentUI.Show();
                    break;
                case 3:
                    //CallInterface.Show();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("See you next time!");
                    Thread.Sleep(634);
                    leaveOptionSelected = true;
                    break;
            }
        }
    }
}
