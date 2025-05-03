using System;

class MyInfo
{
    private string name;  // Поле имени

    // Событие, которое вызывается при изменении имени
    public event EventHandler<string> NameChanged;

    // Свойство для управления именем
    public string Name
    {
        get => name;
        set
        {
            if (name != value)  // Проверка, изменилось ли имя
            {
                name = value;
                OnNameChanged(name);  // Вызов события
            }
        }
    }

    // Метод для генерации события
    protected virtual void OnNameChanged(string newName)
    {
        NameChanged?.Invoke(this, newName);
    }
}

class Program
{
    static void Main()
    {
        MyInfo myInfo = new MyInfo();

        // Подписка на событие NameChanged
        myInfo.NameChanged += (sender, newName) =>
        {
            Console.WriteLine($"Оповещение: Имя изменено на \"{newName}\"");
        };

        // Тест изменения имени
        Console.Write("Введите новое имя: ");
        myInfo.Name = Console.ReadLine();
    }
}
