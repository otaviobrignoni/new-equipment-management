using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.ManufaturerModule;

namespace NewEquipmentManagement.ConsoleApp.EquipmentModule;
public class Equipment : BaseEntity<Equipment>
{
    public string Name;
    public decimal Price;
    public Manufacturer Manufacturer;
    public DateTime ManufacturingDate;

    public Equipment(string name, decimal price, Manufacturer manufacturer, DateTime manufacturingDate)
    {
        Name = name;
        Price = price;
        Manufacturer = manufacturer;
        ManufacturingDate = manufacturingDate;
    }

    public string GetSerialNumber()
    {
        return Name.Substring(0, 3).ToUpper() + Id;
    }
}
