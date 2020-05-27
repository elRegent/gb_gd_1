using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonSystemHelpers;

// Ввести вес и рост человека.Рассчитать и вывести индекс массы тела(ИМТ) по формуле I=m/(h* h); где m — масса тела в килограммах, h — рост в метрах.

// Галеев Руслан gamedev

namespace TaskIMT
{
    class Program
    {
        static double IMT(double weight, double height)
        {
            var a = Convert.ToDouble(weight) / Convert.ToDouble(height * height);
            return a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите вес(в кг):");
            double weight = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите рост (в метрах):");
            double height = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Индекс массы тела: {IMT(weight, height)}");

            Shortener.WaitKeyPressed();
        }
    }
}
