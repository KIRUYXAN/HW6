/*Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double
(double, double). Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).*/

public delegate double Fun(double x, double a);

class Program
{
    public void Table(Fun F, double x, double a)
    {
        Console.WriteLine(" ---- X ---------- A ---------- Y -----");
        Console.WriteLine($"| {x,10:0.000} | {a,10:0.000} | {F(x, a),10:0.000} |");
        Console.WriteLine(" --------------------------------------");
    }
    public double MyFunc1(double x, double a) => a * (x * x);
    public double MyFunc2(double x, double a) => a * Math.Sin(x);

    void Main()
    {
        Console.WriteLine("Таблица функции MyFunc1:");
        Table(MyFunc1, 2, 5);
        Console.WriteLine("Таблица функции MyFunc2:");
        Table(MyFunc2, 2, 5);
    }
}