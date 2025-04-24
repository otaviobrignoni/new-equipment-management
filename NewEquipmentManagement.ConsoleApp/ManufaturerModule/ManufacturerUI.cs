using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.Shared;
using System.Text.RegularExpressions;

namespace NewEquipmentManagement.ConsoleApp.ManufaturerModule;
public class ManufacturerUI : BaseUI<Manufacturer>, IUserInterface<Manufacturer>
{
    public ManufacturerUI()
    {
        Repository = new ManufacturerRepo();
        Title = "Manage Manufacturers";
    }

    public override void Show()
    {
        bool backOptionSelected = false;
        Manufacturer manufacturer;
        while (!backOptionSelected)
        {
            Console.Clear();
            Utils.Header(Title);
            Console.WriteLine();
            Console.WriteLine("1 - List Manufacturer");
            Console.WriteLine("2 - Edit Manufacturer");
            Console.WriteLine("3 - Unlist Manufacturer");
            Console.WriteLine("4 - Show listed manufacturers");
            Console.WriteLine("5 - Go Back");
            switch (Utils.GetValidOption(1, 5))
            {
                case 1:
                    Repository.Add(NewEntity());
                    break;
                case 2:
                    if (Repository.List.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no listed manufacturers.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        while (!Repository.TryFind(GetValidId(), out manufacturer!))
                        {
                            Console.Clear();
                            Console.WriteLine("No valid manufacturer with that ID, try again.");
                            Utils.AnyKeyPrompt();
                        }
                        EditMenu(manufacturer);
                    }
                    break;
                case 3:
                    if (Repository.List.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no listed manufacturers.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        while (!Repository.TryFind(GetValidId(), out manufacturer!))
                        {
                            Console.Clear();
                            Console.WriteLine("No valid manufacturer with that ID, try again.");
                            Utils.AnyKeyPrompt();
                        }
                        Repository.Remove(manufacturer);
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

    public override Manufacturer NewEntity()
    {
        return new Manufacturer(GetValidName(), GetValidEmail(), GetValidPhoneNumber());
    }

    public override void EditMenu(Manufacturer manufacturer)
    {
        string title = $"Edit Manufacturer ID {manufacturer.Id}";
        bool backOptionSelected = false;

        while (!backOptionSelected)
        {
            Console.Clear();
            Utils.Header(title);
            Console.WriteLine();
            Console.WriteLine("1 - Edit Name");
            Console.WriteLine("2 - Edit Email");
            Console.WriteLine("3 - Edit Phone Number");
            Console.WriteLine("4 - Go Back");
            switch (Utils.GetValidOption(1, 4))
            {
                case 1:
                    Repository.Edit(1, GetValidName(), manufacturer);
                    break;
                case 2:
                    Repository.Edit(2, GetValidEmail(), manufacturer);
                    break;
                case 3:
                    Repository.Edit(3, GetValidPhoneNumber(), manufacturer);
                    break;
                case 4:
                    backOptionSelected = true;
                    break;
            }
        }
    }

    public string GetValidName()
    {
        Console.Clear();
        Console.Write("Enter a name for the manufacturer -> ");
        string newName = Console.ReadLine()!.Trim();
        while (string.IsNullOrEmpty(newName))
        {
            Console.Write("Invalid name, try again -> ");
            newName = Console.ReadLine()!.Trim();
        }
        return newName;
    }

    public string GetValidEmail()
    {
        Console.Clear();
        Console.Write("Enter an email for the manufacturer -> ");
        string newName = Console.ReadLine()!.Trim();
        while (string.IsNullOrEmpty(newName) || !Regex.IsMatch(newName, @"^[\w\.-]+@[\w\.-]+(\.\w{2,})?$"))
        {
            Console.Write("Invalid email, try again -> ");
            newName = Console.ReadLine()!.Trim();
        }
        return newName;
    }

    public string GetValidPhoneNumber()
    {
        Console.Clear();
        Console.Write("Enter a phone number for the manufacturer -> ");
        string newPhoneNumber = Console.ReadLine()!.Trim();
        while (string.IsNullOrEmpty(newPhoneNumber) || !Regex.IsMatch(newPhoneNumber, @"^\(?\d{2}\)?\s?(9?\d{4})[-\s]?\d{4}$"))
        {
            Console.Write("Invalid phone number, try again -> ");
            newPhoneNumber = Console.ReadLine()!.Trim();
        }
        return newPhoneNumber;
    }
}
