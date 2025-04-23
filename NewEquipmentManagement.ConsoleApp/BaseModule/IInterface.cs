namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public interface IInterface<T> where T : BaseEntity<T>
{
    void Show();
    T NewEntity();
    void EditEntityMenu(T entity);
    int GetValidId();
}
