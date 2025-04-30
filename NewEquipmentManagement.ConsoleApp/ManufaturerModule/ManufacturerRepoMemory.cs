using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.Shared;

namespace NewEquipmentManagement.ConsoleApp.ManufaturerModule;
public class ManufacturerRepoMemory : BaseRepoMemory<Manufacturer>, IManufacturerRepo
{
    public override void Edit(int option, object value, Manufacturer manufacturer)
    {
        switch (option)
        {
            case 1:
                manufacturer.Name = (string)value;
                break;
            case 2:
                manufacturer.Email = (string)value;
                break;
            case 3:
                manufacturer.PhoneNumber = (string)value;
                break;
        }
    }

    public override void ShowAll()
    {
        const int idWidth = 4;
        const int nameWidth = 15;
        const int emailWidth = 18;
        const int phoneWidth = 13;
        const int countWidth = 16;
        int[] widths = { idWidth, nameWidth, emailWidth, phoneWidth, countWidth };
        int fullWidth = widths.Sum() + widths.Length * 3 - 5;

        Console.Clear();
        Utils.Header("All Manufacturers", fullWidth);
        Console.WriteLine(
            $"{{0, -{idWidth}}} │ {{1, -{nameWidth}}} │ {{2, -{emailWidth}}} │ {{3, -{phoneWidth}}} │ {{4, -{countWidth}}}",
            "ID", "Name", "Email", "Phone Number", "N° of Equipments");
        Console.WriteLine(
            "{0}─┼─{1}─┼─{2}─┼─{3}─┼─{4}",
            new string('─', idWidth), new string('─', nameWidth), new string('─', emailWidth), new string('─', phoneWidth), new string('─', countWidth));
        foreach (Manufacturer manufacturer in List)
        {
            Console.WriteLine(
                $"{{0, -{idWidth}}} │ {{1, -{nameWidth}}} │ {{2, -{emailWidth}}} │ {{3, -{phoneWidth}}} │ {{4, -{countWidth}}}",
                manufacturer.Id, manufacturer.Name, manufacturer.Email, manufacturer.PhoneNumber, manufacturer.GetEquipmentsNumber());
        }
    }
}
