using System;

// Определение делегата
delegate double TriangleDelegate(double side);

class Triangle
{
    // Метод для расчёта периметра
    public static double GetPerimeter(double side)
    {
        if (side <= 0) throw new ArgumentException("Сторона треугольника должна быть больше нуля!");
        return 3 * side;
    }

    // Метод для расчёта площади
    public static double GetArea(double side)
    {
        if (side <= 0) throw new ArgumentException("Сторона треугольника должна быть больше нуля!");
        return (Math.Sqrt(3) / 4) * Math.Pow(side, 2);
    }

    // Метод для вывода стороны треугольника
    public static double GetSide(double side)
    {
        if (side <= 0) throw new ArgumentException("Сторона треугольника должна быть больше нуля!");
        return side;
    }
}

class Program
{
    // Метод, принимающий делегат и строковое сообщение
    public static void ExecuteOperationWithMessage(TriangleDelegate operation, double side, string message)
    {
        try
        {
            Console.WriteLine(message);
            double result = operation(side);
            Console.WriteLine($"Результат операции: {result:F2}\n");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
        }
    }

    static void Main()
    {
        try
        {
            Console.Write("Введите длину стороны треугольника: ");
            double side = Convert.ToDouble(Console.ReadLine());

            // Вызов методов через `ExecuteOperationWithMessage()`
            ExecuteOperationWithMessage(Triangle.GetPerimeter, side, "Вычисляем периметр треугольника...");
            ExecuteOperationWithMessage(Triangle.GetArea, side, "Вычисляем площадь треугольника...");
            ExecuteOperationWithMessage(Triangle.GetSide, side, "Выводим сторону треугольника...");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода! Введите число.");
        }
    }
}
