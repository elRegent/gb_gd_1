using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса.
// * Добавить свойства типа int для доступа к числителю и знаменателю;
// * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
//** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");

namespace Fractions
{
    class Fraction
    {
        int num = 1; //числитель
        int den = 1; //знаменатель

        public Fraction()
        {
        }

        static void CheckForZeroDen(int den)
        {
            if (den == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
        }

        public Fraction(int num, int den)
        {
            Fraction.CheckForZeroDen(den);
            this.num = num;
            this.den = den;
        }
        // без setter'ов
        public int Num
        {
            get { return num; }
            set
            {
                num = value;
            }
        }

        public int Den
        {
            get { return den; }
            set
            {
                Fraction.CheckForZeroDen(value);
                den = value;
            }
        }

        public double DecimalView
        {
            get { return Convert.ToDouble(num) / Convert.ToDouble(den); }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числитель");
            int num = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите знаменатель");
            int den = Convert.ToInt32(Console.ReadLine());

            Fraction fraction = new Fraction(num, den);

            Console.WriteLine($"Десятичное представление {fraction.DecimalView}");

            Console.WriteLine($"Присваиваем знаменателю 10");

            fraction.Den = 10;
            Console.WriteLine($"Десятичное представление {fraction.DecimalView}");

            Console.WriteLine($"Присваиваем знаменателю 0, увидим ли ошибку?");
            fraction.Den = 0;

            Console.ReadKey();
        }
    }
}
