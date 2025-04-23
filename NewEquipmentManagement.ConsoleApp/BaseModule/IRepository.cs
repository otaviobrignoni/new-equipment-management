namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public interface IRepository<T> where T : BaseEntity<T>
{
    void Add(T entity);
    void Remove(T entity);
    void Edit(int option, object value, T entity);
    void ShowAll();
    bool TryFind(int id, out T? entity);
    int GetNextAvailableId();
}