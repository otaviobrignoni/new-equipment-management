namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public interface IUserInterface<T> where T : BaseEntity<T>
{
    void Show();
    T NewEntity();
    void EditEntityMenu(T entity);
    int GetValidId();
}
