
namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public abstract class BaseRepoDisk<T> where T : BaseEntity<T>
{
    protected List<T> List = new List<T>();

    protected DataContext Context { get; set; }

    protected BaseRepoDisk(DataContext context)
    {
        Context = context;
        List = GetList();
    }

    protected abstract List<T> GetList();
    

    public void Add(T entity)
    {
        entity.Id = GetNextAvailableId();
        List.Add(entity);
        Context.SaveData();
    }

    public void Remove(T entity)
    {
        List.Remove(entity);
        Context.SaveData();
    }

    public abstract void Edit(int option, object value, T entity);

    public abstract void ShowAll();

    public bool TryFind(int id, out T? entity)
    {
        entity = List.FirstOrDefault(targetEntity => targetEntity.Id == id);
        if (entity == null)
            return false;
        return true;
    }

    public int GetNextAvailableId()
    {
        int id = 1;
        List<int> usedIds = List.Select(baseEntity => baseEntity.Id).OrderBy(id => id).ToList();
        foreach (int usedId in usedIds)
        {
            if (usedId != id)
                break;
            id++;
        }
        return id;
    }

    public int Count()
    {
        return List.Count;
    }
}
