using NewEquipmentManagement.ConsoleApp.BaseModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;

namespace NewEquipmentManagement.ConsoleApp.ManufaturerModule;

public class Manufacturer : BaseEntity<Manufacturer>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public List<Equipment> Equipments { get; set; }
    public Manufacturer() 
    {
        Equipments = new List<Equipment>();
    }
    
    public Manufacturer(string name, string email, string phoneNumber) : this()
    {
        Name = name;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public int GetEquipmentsNumber()
    {
        if (Equipments == null) return 0;
        return Equipments.Count();
    }
}
