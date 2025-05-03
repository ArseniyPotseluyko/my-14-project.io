using System;

// Объявление делегата
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
    static void Main()
    {
        try
        {
            // Ввод стороны
            Console.Write("Введите длину стороны треугольника: ");
            double side = Convert.ToDouble(Console.ReadLine());

            // Создание экземпляра делегата и вызов методов
            TriangleDelegate triangleDelegate;

            triangleDelegate = Triangle.GetPerimeter;
            Console.WriteLine($"Периметр: {triangleDelegate(side):F2}");

            triangleDelegate = Triangle.GetArea;
            Console.WriteLine($"Площадь: {triangleDelegate(side):F2}");

            triangleDelegate = Triangle.GetSide;
            Console.WriteLine($"Сторона: {triangleDelegate(side):F2}");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка ввода! Введите число.");
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
}
