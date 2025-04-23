namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public abstract class BaseInterface<T> where T : BaseEntity<T>
{
    public string Title { get; set; }

    public abstract void Show();

    public abstract T NewEntity();

    public abstract void EditEntityMenu(T entity);

    public int GetValidId()
    {
        int id;
        Console.Clear();
        Console.Write("Enter an ID -> ");
        while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
            Console.Write("Invalid ID, try again -> ");
        return id;
    }
}
