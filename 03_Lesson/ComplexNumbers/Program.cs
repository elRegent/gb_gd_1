using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Задание 1 а)
// а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
// (б и в (complex через классы) сделаны в отдельном проекте)
namespace ComplexNumbers
{
    struct Complex
    {
        public double im;
        public double re;
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public Complex Minus(Complex x)
        {
            // меняем знаки, потом складываем
            Complex y;
            y.im = -1 * x.im;
            y.re = -1 * x.re;

            return this.Plus(y);
        }
        public string ToString()
        {
            return re + " + " + (im < 0 ? "(" : "") + im + (im < 0 ? ")" : "") + "i";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Complex complex1;
            complex1.re = 1;
            complex1.im = 1;

            Complex complex2;
            complex2.re = 2;
            complex2.im = 2;

            Complex result = complex1.Plus(complex2);
            Console.WriteLine(result.ToString());

            result = complex1.Multi(complex2);
            Console.WriteLine(result.ToString());

            result = complex1.Minus(complex2);
            Console.WriteLine(result.ToString());

            Console.ReadKey();
        }

    }
}
