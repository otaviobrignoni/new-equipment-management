using NewEquipmentManagement.ConsoleApp.CallModule;
using NewEquipmentManagement.ConsoleApp.EquipmentModule;
using NewEquipmentManagement.ConsoleApp.ManufaturerModule;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public class DataContext
{
    public List<Manufacturer> Manufacturers { get; set; }
    public List<Equipment> Equipments { get; set; }
    public List<Call> Calls { get; set; }

    private string savePath = "C:\\temp";
    private string arquiveName = "saveData.json";

    public DataContext() 
    {
        Manufacturers = new List<Manufacturer>();
        Equipments = new List<Equipment>();
        Calls = new List<Call>();
    }

    public DataContext(bool loadData) : this()
    {
        if (loadData) LoadData();
    }

    public void SaveData()
    {
        string fullPath = Path.Combine(savePath, arquiveName);

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.WriteIndented = true;
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        string json = JsonSerializer.Serialize(this, jsonOptions);

        if (!Directory.Exists(savePath)) Directory.CreateDirectory(savePath);

        File.WriteAllText(fullPath, json);
    }

    private void LoadData()
    {
        string fullPath = Path.Combine(savePath, arquiveName);

        if (!File.Exists(fullPath)) return;

        string json = File.ReadAllText(fullPath);

        if (string.IsNullOrWhiteSpace(json)) return;

        JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
        jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

        DataContext savedContext = JsonSerializer.Deserialize<DataContext>(json, jsonOptions)!;

        if (savedContext == null) return;

        Manufacturers = savedContext.Manufacturers;
        Equipments = savedContext.Equipments;
        Calls = savedContext.Calls;
    }
}
