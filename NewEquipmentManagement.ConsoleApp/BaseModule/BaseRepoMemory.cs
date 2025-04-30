namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public abstract class BaseRepoMemory<T> where T : BaseEntity<T>
{
    public List<T> List = new List<T>();

    public void Add(T entity)
    {
        entity.Id = GetNextAvailableId();
        List.Add(entity);
    }

    public void Remove(T entity)
    {
        List.Remove(entity);
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
