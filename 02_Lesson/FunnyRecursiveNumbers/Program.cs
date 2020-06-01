using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// a) Разработать рекурсивный метод, который выводит на экран числа от a до b(a<b).
// б) * Разработать рекурсивный метод, который считает сумму чисел от a до b.
namespace FunnyRecursiveNumbers
{
    class Program
    {
        static void printNumbers(int from, int to)
        {
            if (from > to)
            {
                return;
            }

            Console.Write($"{from} ");
            printNumbers(from + 1, to);
        }

        static int sumNumbers(int from, int to, int sum = 0)
        {
            if (from > to)
            {
                return sum;
            }

            int sumWithNew = from + sum;

            return sumNumbers(from + 1, to, sumWithNew);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите программу a или b (латинскими)");
            string selectedProgram = Console.ReadLine();

            Console.WriteLine("Введите число с которого начинаем");
            int from = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите число на котором заканчиваем");
            int to = int.Parse(Console.ReadLine());


            if (selectedProgram == "a")
            {
                Console.WriteLine("Результат работы программы a");
                printNumbers(from, to);
            }
            else if (selectedProgram == "b")
            {
                int result = sumNumbers(from, to);
                Console.WriteLine("Результат работы программы b");
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Программа еще не написана");
            }

            Console.ReadKey();
        }
    }
}
