using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.ManufaturerModule;
using NewEquipmentManagement.ConsoleApp.Shared;

namespace NewEquipmentManagement.ConsoleApp.EquipmentModule;
public class EquipmentRepoMemory : BaseRepoMemory<Equipment>, IEquipmentRepo
{
    public void AddWithoutID(Equipment equipment)
    {
        List.Add(equipment);
    }
    public override void Edit(int option, object value, Equipment equipment)
    {
        switch (option)
        {
            case 1:
                    equipment.Name = (string)value;
                break;
            case 2:
                    equipment.Price = (decimal)value;
                break;
            case 3:
                    equipment.Manufacturer = (Manufacturer)value;
                break;
            case 4:
                    equipment.ManufacturingDate = (DateTime)value;
                break;
        }
    }

    public override void ShowAll()
    {
        const int idWidth = 4;
        const int nameWidth = 15;
        const int snWidth = 7;
        const int priceWidth = 12;
        const int dateWidth = 10;
        int[] widths = { idWidth, nameWidth, nameWidth, snWidth, priceWidth, dateWidth };
        int fullWidth = widths.Sum() + widths.Length * 3 - 5;


        Console.Clear();
        Utils.Header("All Equipments", fullWidth);
        Console.WriteLine(
            $"{{0, -{idWidth}}} │ {{1, -{nameWidth}}} │ {{2, -{snWidth}}} │ {{3, -{nameWidth}}} │ {{4, -{priceWidth}}} │ {{5, -{dateWidth}}}",
            "ID", "Name", "S/N", "Manufacturer", "Price", "Built on");
        Console.WriteLine(
            "{0}─┼─{1}─┼─{2}─┼─{3}─┼─{4}─┼─{5}",
            new string('─', idWidth), new string('─', nameWidth), new string('─', snWidth), new string('─', nameWidth), new string('─', priceWidth), new string('─', dateWidth));
        foreach (Equipment equipment in List)
        {
            Console.WriteLine(
                $"{{0, -{idWidth}}} │ {{1, -{nameWidth}}} │ {{2, -{snWidth}}} │ {{3, -{nameWidth}}} │ {{4, -{priceWidth}}} │ {{5, -{dateWidth}}}",
                equipment.Id, equipment.Name, equipment.GetSerialNumber(), equipment.Manufacturer.Name, $"R${equipment.Price:F2}", equipment.ManufacturingDate.ToString("dd/MM/yyyy"));
        }
    }
}
