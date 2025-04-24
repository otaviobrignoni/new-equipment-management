using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;
using NewEquipmentManagement.ConsoleApp.Shared;

namespace NewEquipmentManagement.ConsoleApp.CallModule;
public class CallUI : BaseUI<Call>, IUserInterface<Call>
{
    private EquipmentUI EquipUI;

    public CallUI(EquipmentUI UI)
    {
        Repository = new CallRepo();
        EquipUI = UI;
        Title = "Manage Calls";
    }

    public override void Show()
    {
        bool backOptionSelected = false;
        Call call;
        while (!backOptionSelected)
        {
            Console.Clear();
            Utils.Header(Title);
            Console.WriteLine();
            Console.WriteLine("1 - Open call");
            Console.WriteLine("2 - Edit call");
            Console.WriteLine("3 - Delete call");
            Console.WriteLine("4 - Show open calls");
            Console.WriteLine("5 - Go Back");
            switch (Utils.GetValidOption(1, 5))
            {
                case 1:
                    if (EquipUI.Repository.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no equipments in the inventory.\nPlease add one before opening a maintenance call.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                       Repository.Add(NewEntity());
                    break;
                case 2:
                    if (Repository.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no open calls.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        while (!Repository.TryFind(GetValidId(), out call!))
                        {
                            Console.Clear();
                            Console.WriteLine("No valid equipment with that ID, try again.");
                            Utils.AnyKeyPrompt();
                        }
                        EditMenu(call);
                    }
                    break;
                case 3:
                    if (Repository.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no open calls.");
                        Utils.AnyKeyPrompt();
                    }
                    else
                    {
                        while (!Repository.TryFind(GetValidId(), out call!))
                        {
                            Console.Clear();
                            Console.WriteLine("No valid equipment with that ID, try again.");
                            Utils.AnyKeyPrompt();
                        }
                        Repository.Remove(call);
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

    public override Call NewEntity()
    {
        return new Call(GetValidTitle(), GetValidDescription(), GetValidEquipment());
    }

    public override void EditMenu(Call call)
    {
        bool backOptionSelected = false;

        while (!backOptionSelected)
        {
            Console.Clear();
            Utils.Header($"Edit Call ID {call.Id}");
            Console.WriteLine();
            Console.WriteLine("1 - Edit Title");
            Console.WriteLine("2 - Edit Description");
            Console.WriteLine("3 - Change Equipment");
            Console.WriteLine("4 - Go Back");
            switch (Utils.GetValidOption(1, 4))
            {
                case 1:
                    Repository.Edit(1, GetValidTitle(), call);
                    break;
                case 2:
                    Repository.Edit(2, GetValidDescription(), call);
                    break;
                case 3:
                    Repository.Edit(3, GetValidEquipment(), call);
                    break;
                case 4:
                    backOptionSelected = true;
                    break;
            }
        }
    }
    public string GetValidTitle()
    {
        Console.Clear();
        Console.Write("Enter a title for the call -> ");
        string newTitle = Console.ReadLine()!.Trim();
        while (string.IsNullOrEmpty(newTitle))
        {
            Console.Write("Invalid title, try again -> ");
            newTitle = Console.ReadLine()!.Trim();
        }
        return newTitle;
    }

    public string GetValidDescription()
    {
        Console.Clear();
        Console.Write("Enter a description for the call -> ");
        string newDescription = Console.ReadLine()!.Trim();
        while (string.IsNullOrEmpty(newDescription))
        {
            Console.Write("Invalid description, try again -> ");
            newDescription = Console.ReadLine()!.Trim();
        }
        return newDescription;
    }

    public Equipment GetValidEquipment()
    {
        Equipment? equipment;
        while (!EquipUI.Repository.TryFind(EquipUI.GetValidId(), out equipment))
        {
            Console.Clear();
            Console.WriteLine("No valid equipment with that ID, try again.");
            Utils.AnyKeyPrompt();
        }
        return equipment!;
    }
}
