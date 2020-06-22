using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

// Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
// Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

namespace TableWithDelegate
{
    class Program
    {
        public delegate double Fun(double a, double x);

        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(a, x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }

        public static double aSinX(double a, double x)
        {
            return x * Math.Sin(x);
        }
        public static double aSquareX(double a, double x)
        {
            return a * x * x;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции a*x^2:");
            Table(aSquareX, 10, -2, 2);
            Console.WriteLine("Таблица функции a*sin(x):");
            Table(aSinX, 20, 5, 10);

            Console.ReadKey();
        }
    }
}
