using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;

namespace NewEquipmentManagement.ConsoleApp.ManufaturerModule;

public class Manufacturer : BaseEntity<Manufacturer>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public EquipmentRepo Equipments { get; set; }

    public Manufacturer(string name, string email, string phoneNumber)
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
        Equipments = new EquipmentRepo();
    }
    
    public int GetEquipmentsNumber()
    {
        return Equipments.Count();
    }
}
