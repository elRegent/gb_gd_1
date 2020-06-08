using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

// а)  С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке).
// Требуется подсчитать сумму всех нечётных положительных чисел.
// Сами числа и сумму вывести на экран, используя tryParse.

namespace SumTryParse
{


    class Program
    {
        static int GetIntFromConsoleInput()
        {
            int x = 0;
            string s;
            bool success = false;

            while (!success)
            {
                s = Console.ReadLine();
                success = int.TryParse(s, out x);
                Console.WriteLine(success ? "Распознано число " + x : "Ошибка ввода");
            }
            return x;
        }
        static int SumOddPositive(int a, int sum)
        {
            if (a % 2 == 1 && a > 0)
            {
                return sum + a;
            }

            return sum;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Вводите числа, после ввода каждого числа нажимайте Enter. Введите 0 чтобы завершить ввод");

            int sum = 0;

            while(true)
            {
                int num = GetIntFromConsoleInput();

                if (num == 0) break;

                sum = SumOddPositive(num, sum);
            }

            Console.WriteLine($"Сумма нечетных положительных чисел {sum}");

            Console.ReadKey();
        }
    }
}
