using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;
using NewEquipmentManagement.ConsoleApp.Shared;

namespace NewEquipmentManagement.ConsoleApp.CallModule;

public class CallRepoDisk : BaseRepoDisk<Call>, ICallRepo
{

    public CallRepoDisk(DataContext context) : base(context)
    {
    }

    protected override List<Call> GetList()
    {
        return Context.Calls;
    }


    public override void Edit(int option, object value, Call call)
    {
        switch (option)
        {
            case 1:
                call.Title = (string)value;
                break;
            case 2:
                call.Description = (string)value;
                break;
            case 3:
                call.Equipment = (Equipment)value;
                break;
        }
        Context.SaveData();
    }

    public override void ShowAll()
    {
        const int idWidth = 4;
        const int titleWidth = 12;
        const int descWidth = 20;
        const int dateWidth = 12;
        const int timeWidth = 14;
        int[] widths = { idWidth, idWidth, titleWidth, descWidth, dateWidth, timeWidth };
        int fullWidth = widths.Sum() + widths.Length * 3 - 5;

        Console.Clear();
        Utils.Header("All Calls", fullWidth);
        Console.WriteLine(
        $"{{0, -{idWidth}}} │ {{1, -{idWidth}}} │ {{2, -{titleWidth}}} │ {{3, -{descWidth}}} │ {{4, -{dateWidth}}} │ {{5, -{timeWidth}}}",
        "C.ID", "E.ID", "Title", "Description", "Opening Date", "Time Open");
        Console.WriteLine(
        "{0}─┼─{1}─┼─{2}─┼─{3}─┼─{4}─┼─{5}",
        new string('─', idWidth), new string('─', idWidth), new string('─', titleWidth), new string('─', descWidth), new string('─', dateWidth), new string('─', timeWidth));
        foreach (Call call in List)
        {
            Console.WriteLine(
                 $"{{0, -{idWidth}}} │ {{1, -{idWidth}}} │ {{2, -{titleWidth}}} │ {{3, -{descWidth}}} │ {{4, -{dateWidth}}} │ {{5, -{timeWidth}}}",
                call.Id, call.Equipment.Id, call.Title, call.Description, call.OpeningDate.ToString("dd/MM/yyyy"), call.ElapsedTime());
        }
    }
}
