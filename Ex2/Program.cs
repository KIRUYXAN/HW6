/*Модифицировать программу нахождения минимума функции так,
чтобы можно было передавать функцию в виде делегата.
а) Сделать меню с различными функциями и представить пользователю выбор,
для какой функции и на каком отрезке находить минимум. Использовать массив (или список) делегатов,
в котором хранятся различные функции.
б) Переделать функцию Load, чтобы она возвращала массив считанных значений.
Пусть она возвращает минимум через параметр (с использованием модификатора out).*/

delegate double Fun(double x);

class Program
{
    double Function(double x) => x * x - 50 * x + 10;

    void SaveFunc(Fun F, string fileName, double a, double b, double h)
    {
        using FileStream fs = new(fileName, FileMode.Create, FileAccess.Write);
        using BinaryWriter bw = new(fs);
        double x = a;
        while (x <= b)
        {
            bw.Write(F(x));
            x += h;
        }
    }
    double Load(string fileName)
    {
        using FileStream fs = new(fileName, FileMode.Open, FileAccess.Read);
        using BinaryReader bw = new(fs);
        double min = double.MaxValue;
        double d;
        for (int i = 0; i < fs.Length / sizeof(double); i++)
        {
            d = bw.ReadDouble();
            if (d < min) min = d;
        }
        return min;
    }
    void Main()
    {
        SaveFunc(Function, "data.bin", -100, 100, 0.5);
        Console.WriteLine(Load("data.bin"));
        Console.ReadKey();
    }
}