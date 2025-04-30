using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.ManufaturerModule;
using NewEquipmentManagement.ConsoleApp.Shared;

namespace NewEquipmentManagement.ConsoleApp.EquipmentModule;
public class EquipmentUI : BaseUI<Equipment>, IUserInterface<Equipment>
{
    private ManufacturerUI MnfUI;
    public EquipmentUI(ManufacturerUI UI, IEquipmentRepo equipmentRepo) : base(equipmentRepo, "Manage Equipments")
    {
        MnfUI = UI;
    }

    public override void Show()
    {
        bool backOptionSelected = false;       
        Equipment equipment;
        while (!backOptionSelected)
        {
            Console.Clear();
            Utils.Header(Title);
            Console.WriteLine();
            Console.WriteLine("1 - Add equipment");
            Console.WriteLine("2 - Edit equipment");
            Console.WriteLine("3 - Remove equipment");
            Console.WriteLine("4 - Show all equipments");
            Console.WriteLine("5 - Go Back");
            switch (Utils.GetValidOption(1, 5))
            {
                case 1:
                    if (MnfUI.Repository.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no listed manufacturers.\nPlease list one before adding an equipment.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        equipment = NewEntity();
                        Manufacturer manufacturer = equipment.Manufacturer;
                        //if (manufacturer.Equipments == null)                       
                        //    manufacturer.Equipments = new List<Equipment>();
                        manufacturer.Equipments.Add(equipment);
                        Repository.Add(equipment);
                        
                    }
                    break;
                case 2:
                    if (Repository.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no equipments in the inventory.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        while (!Repository.TryFind(GetValidId(), out equipment!))
                        {
                            Console.Clear();
                            Console.WriteLine("No valid equipment with that ID, try again.");
                            Utils.AnyKeyPrompt();
                        }
                        EditMenu(equipment);
                    }
                    break;
                case 3:
                    if (Repository.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no equipments in the inventory.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        while (!Repository.TryFind(GetValidId(), out equipment!))
                        {
                            Console.Clear();
                            Console.WriteLine("No valid equipment with that ID, try again.");
                            Utils.AnyKeyPrompt();
                        }
                        Repository.Remove(equipment);
                    }
                    break;
                case 4:
                    Repository.ShowAll();
                    Utils.AnyKeyPrompt();
                    break;
                case 5:
                    backOptionSelected = true;
                    break;
            }
        }
    }
    public override Equipment NewEntity()
    {
        return new Equipment(GetValidName(), GetValidPrice(), GetValidManufacturer(), GetValidDate());
    }

    public override void EditMenu(Equipment equipment)
    {
        string title = $"Edit Equipment ID {equipment.Id}";
        bool backOptionSelected = false;

        while (!backOptionSelected)
        {
            Console.Clear();
            Utils.Header(title);
            Console.WriteLine();
            Console.WriteLine("1 - Edit Name");
            Console.WriteLine("2 - Edit Price");
            Console.WriteLine("3 - Change Manufacturer");
            Console.WriteLine("4 - Edit Manufacturing Date");
            Console.WriteLine("5 - Go Back");
            switch (Utils.GetValidOption(1, 5))
            {
                case 1:
                    Repository.Edit(1, GetValidName(), equipment);
                    break;
                case 2:
                    Repository.Edit(2, GetValidPrice(), equipment);
                    break;
                case 3:
                    Manufacturer manufacturer = equipment.Manufacturer;
                    manufacturer.Equipments.Remove(equipment);
                    Manufacturer newManufacturer = GetValidManufacturer();
                    Repository.Edit(3, newManufacturer, equipment);
                    break;
                case 4:
                    Repository.Edit(4, GetValidDate(), equipment);
                    break;
                case 5:
                    backOptionSelected = true;
                    break;
            }
        }
    }

    public string GetValidName()
    {
        Console.Clear();
        Console.Write("Enter a name for the equipment -> ");
        string newName = Console.ReadLine()!.Trim();
        while (string.IsNullOrEmpty(newName) || newName.Length < 6)
        {
            Console.Write("Invalid name, try again -> ");
            newName = Console.ReadLine()!.Trim();
        }
        return newName;
    }

    public decimal GetValidPrice()
    {
        Console.Clear();
        Console.Write("Enter a price for the equipment -> ");
        decimal newPrice;
        while (!decimal.TryParse(Console.ReadLine(), out newPrice) || newPrice < 0)
            Console.Write("Invalid price, try again -> ");
        return newPrice;
    }

    public Manufacturer GetValidManufacturer()
    {
        Manufacturer? manufacturer;
        while (!MnfUI.Repository.TryFind(MnfUI.GetValidId(), out manufacturer))
        {
            Console.Clear();
            Console.WriteLine("No valid manufacturer with that ID, try again.");
            Utils.AnyKeyPrompt();
        }
        return manufacturer!;
    }

    public DateTime GetValidDate()
    {
        Console.Clear();
        Console.Write("Enter a date (dd/mm/yyyy) -> ");
        DateTime newDate;
        while (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out newDate))
            Console.Write("Invalid date, try again -> ");
        return newDate;
    }

}
