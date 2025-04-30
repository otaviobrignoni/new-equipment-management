using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.CallModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;
using NewEquipmentManagement.ConsoleApp.ManufaturerModule;

namespace NewEquipmentManagement.ConsoleApp.Shared;
public class MainMenu
{
    public static DataContext Context = new DataContext(true);

    public static ManufacturerRepoDisk manufacturerRepo = new ManufacturerRepoDisk(Context);
    public static EquipmentRepoDisk equipmentRepo = new EquipmentRepoDisk(Context);
    public static CallRepoDisk callRepo = new CallRepoDisk(Context);

    public static ManufacturerUI manufacturerUI = new ManufacturerUI(manufacturerRepo);
    public static EquipmentUI equipmentUI = new EquipmentUI(manufacturerUI, equipmentRepo);
    public static CallUI callUI = new CallUI(equipmentUI, callRepo);

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
                    callUI.Show();
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
