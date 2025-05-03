using System;

class Notifier
{
    // Определение делегата и события
    public delegate void NotifyEventHandler(string message);
    public event NotifyEventHandler NotifyEvent;

    // Метод для вызова события
    public void TriggerEvent(string message)
    {
        NotifyEvent?.Invoke(message);
    }
}

// Первый класс-наблюдатель
class ObserverA
{
    public void ReactionOne(string message)
    {
        Console.WriteLine($"ObserverA (Реакция 1): {message}");
    }

    public void ReactionTwo(string message)
    {
        Console.WriteLine($"ObserverA (Реакция 2): {message}");
    }
}

// Второй класс-наблюдатель
class ObserverB
{
    public void Reaction(string message)
    {
        Console.WriteLine($"ObserverB (Реакция): {message}");
    }
}

class Program
{
    static void Main()
    {
        // Создание экземпляров
        Notifier notifier = new Notifier();
        ObserverA observerA = new ObserverA();
        ObserverB observerB = new ObserverB();

        // Подписка на событие (два обработчика от ObserverA и один от ObserverB)
        notifier.NotifyEvent += observerA.ReactionOne;
        notifier.NotifyEvent += observerA.ReactionTwo;
        notifier.NotifyEvent += observerB.Reaction;

        // Вызов события
        Console.WriteLine("\n🔹 Вызываем событие:");
        notifier.TriggerEvent("Событие произошло!");

        // Удаление одного обработчика
        notifier.NotifyEvent -= observerA.ReactionTwo;

        // Вызов события после удаления обработчика
        Console.WriteLine("\n🔹 Вызываем событие после удаления одного обработчика:");
        notifier.TriggerEvent("Событие произошло снова!");
    }
}
