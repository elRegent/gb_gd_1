using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел

namespace FindPositiveOddNums
{
    class Program
    {
        static bool CheckForOddPositive(int a)
        {
            return (a > 0 && a % 2 == 1);
        }
        static void Main(string[] args)
        {
            string oddPositive = "";
            while (true)
            {
                Console.WriteLine("Введите число");
                int num = int.Parse(Console.ReadLine());

                if (num == 0)
                {
                    break;
                }

                if (CheckForOddPositive(num))
                {
                    oddPositive += (oddPositive == "" ? "" : " ") + Convert.ToString(num);
                }
            }

            Console.WriteLine($"Список положительных нчетных чисел {oddPositive}");

            Console.ReadKey();
        }
    }
}
