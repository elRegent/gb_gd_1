using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonSystemHelpers;

//а) Написать программу, которая подсчитывает расстояние между точками с координатами x1, y1 и x2,y2 по формуле r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2).Вывести результат, используя спецификатор формата .2f(с двумя знаками после запятой);
//б) * Выполнить предыдущее задание, оформив вычисления расстояния между точками в виде метода

// Галеев Руслан gamedev
namespace TaskDistance
{
    class Program
    {
        static double Distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }
        static void Main(string[] args)
        {
            Shortener.Print("Введите x1");
            double x1 = Convert.ToDouble(Console.ReadLine());

            Shortener.Print("Введите y1");
            double y1 = Convert.ToDouble(Console.ReadLine());

            Shortener.Print("Введите x2");
            double x2 = Convert.ToDouble(Console.ReadLine());

            Shortener.Print("Введите y2");
            double y2 = Convert.ToDouble(Console.ReadLine());

            // задание а)
            double resultA = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            // задание б)
            double resultB = Distance(x1, y1, x2, y2);

            Console.WriteLine(String.Format("Расстояние, задание а) {0:F2}", resultA));
            Console.WriteLine(String.Format("Расстояние, задание б) {0:F2}", resultB));
            
            Shortener.WaitKeyPressed();
        }
    }
}
