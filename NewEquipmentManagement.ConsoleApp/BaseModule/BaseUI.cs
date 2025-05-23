﻿namespace NewEquipmentManagement.ConsoleApp.BaseModule;

public abstract class BaseUI<T> where T : BaseEntity<T>
{
    public BaseRepo<T> Repository {  get; set; }

    public string Title { get; set; }

    public abstract void Show();

    public abstract T NewEntity();

    public abstract void EditMenu(T entity);

    public int GetValidId()
    {
        int id;
        Console.Clear();
        Repository.ShowAll();
        Console.WriteLine();
        Console.Write("Enter an ID -> ");
        while (!int.TryParse(Console.ReadLine(), out id) || id < 1)
        {
            Repository.ShowAll();
            Console.WriteLine();
            Console.Write("Invalid ID, try again -> ");
        }
        return id;
    }
}
