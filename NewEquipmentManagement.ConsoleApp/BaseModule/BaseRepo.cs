namespace NewEquipmentManagement.ConsoleApp.BaseModule;

internal abstract class BaseRepo
{
    public List<BaseEntity> Repository = new List<BaseEntity>();

    public void AddEntity(BaseEntity entity)
    {
        entity.Id = GetNextAvailableId();
        Repository.Add(entity);
    }

    public abstract void EditEntity();

    public void RemoveEntity(BaseEntity entity)
    {
        Repository.Remove(entity);
    }

    public bool TryFindEntity(int id, out BaseEntity? entity)
    {
        entity = Repository.FirstOrDefault(targetEntity => targetEntity.Id == id);
        if (entity == null)
            return false;
        return true;
    }

    public abstract void ShowAllEntities();

    public int GetNextAvailableId()
    {
        int id = 1;
        List<int> usedIds = Repository.Select(baseEntity => baseEntity.Id).OrderBy(id => id).ToList();
        foreach (int usedId in usedIds)
        {
            if (usedId != id)
                break;
            id++;
        }
        return id;
    }
}
