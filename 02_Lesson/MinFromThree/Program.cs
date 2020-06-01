using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Написать метод, возвращающий минимальное из трёх чисел.

namespace MinFromThree
{
    class Program
    {
        static int FindMin(int a, int b, int c)
        {
            return (a < b && a < c) ? a : (b < c ? b : c);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число");
            int a = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите первое число");
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите первое число");
            int c = int.Parse(Console.ReadLine());

            Console.WriteLine($"Минимум равен {FindMin(a, b, c)}");

            Console.ReadKey();
        }
    }
}
