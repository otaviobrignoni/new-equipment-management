using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;

namespace NewEquipmentManagement.ConsoleApp.CallModule;
public class Call : BaseEntity<Call>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public Equipment Equipment { get; set; }
    public DateTime OpeningDate { get; set; }

    public Call()
    {
    }

    public Call(string title, string description, Equipment equipment)
    {
        Title = title;
        Description = description;
        Equipment = equipment;
        OpeningDate = DateTime.Now;
    }

    public string ElapsedTime()
    {
        TimeSpan elapsedTime = DateTime.Now - OpeningDate;

        if (elapsedTime.TotalSeconds < 12)
            return "Just now";
        else if (elapsedTime.TotalSeconds < 60)
            return $"{(int)elapsedTime.TotalSeconds} second(s) ago";
        if (elapsedTime.TotalMinutes < 60)
            return $"{(int)elapsedTime.TotalMinutes} minute(s) ago";
        if (elapsedTime.TotalHours < 24)
            return $"{(int)elapsedTime.TotalHours} hour(s) ago";
        if (elapsedTime.TotalDays < 30)
            return $"{(int)elapsedTime.TotalDays} day(s) ago";
        if (elapsedTime.TotalDays < 365)
            return $"{(int)(elapsedTime.TotalDays / 30)} month(s) ago";

        return $"{(int)(elapsedTime.TotalDays / 365)} year(s) ago";
    }
}
