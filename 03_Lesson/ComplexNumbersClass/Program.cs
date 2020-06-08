using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса.
// в) Добавить диалог с использованием switch демонстрирующий работу класса.

namespace ComplexNumbersClass
{
    class Complex
    {
        double im;
        double re;

        public Complex()
        {
            im = 0;
            re = 0;
        }

        public Complex(double im, double re)
        {
            this.im = im;
            this.re = re;
        }
        public Complex Plus(Complex x)
        {
            Complex y = new Complex();
            y.im = x.im + im;
            y.re = x.re + re;
            return y;
        }

        public Complex Multi(Complex x)
        {
            Complex y = new Complex();
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;

            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y = new Complex();
            y.im = -1 * x.im;
            y.re = -1 * x.re;

            return this.Plus(y);
        }

        public double Im
        {
            get { return im; }
            set
            {
                if (value >= 0) im = value;
            }
        }
        public string ToString()
        {
            return re + " + " + (im < 0 ? "(" : "") + im + (im < 0 ? ")" : "") + "i";
        }

        public static bool CheckAvailableOperations(string input)
        {
            return (input == "*" || input == "+" || input == "-");
        } 
    }

    class Program
    {
        
        static void Main(string[] args)
        {
            Complex x1 = new Complex(1, 1);
            Complex x2 = new Complex(2, 2);

            Console.WriteLine($"Первое число: {x1.ToString()}");
            Console.WriteLine($"Первое число: {x2.ToString()}");

            string oper = "";

            while (!Complex.CheckAvailableOperations(oper))
            {
                Console.WriteLine("Какую операцию выполнить? введите + - или *");
                oper = Console.ReadLine();
            }

            Complex result;

            switch (oper)
            {
                case "*":
                    result = x1.Multi(x2);
                    Console.WriteLine(result.ToString());
                    break;
                case "+":
                    result = x1.Plus(x2);
                    Console.WriteLine(result.ToString());
                    break;
                case "-":
                    result = x1.Minus(x2);
                    Console.WriteLine(result.ToString());
                    break;
                default:
                    break;
            }

            Console.ReadKey();
        }
    }
}
