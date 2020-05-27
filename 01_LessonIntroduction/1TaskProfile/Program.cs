using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LessonSystemHelpers;

//Написать программу «Анкета». Последовательно задаются вопросы(имя, фамилия, возраст, рост, вес). В результате вся информация выводится в одну строчку:
//а) используя склеивание;
//б) используя форматированный вывод;
//в) используя вывод со знаком $.

//Галеев Руслан gamedev

namespace TaskProfile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите свое имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите свою фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Сколько вам лет?");
            byte age = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Ваш рост?"); 
            byte height = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Ваш вес?");
            short weight = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Ваша aнкета, способ 1");
            Console.WriteLine("Имя: " + name + " Фамилия: " + surname + " Возраст: " + age + " Рост: " + height + " Вес: " + weight);

            Console.WriteLine("Ваша анкета, способ 2");
            Console.WriteLine(String.Format("Имя: {0} Фамилия: {1} Возраст: {2} Рост: {3} Вес: {4}", name, surname, age, height, weight));

            Console.WriteLine("Ваша анкета, способ 3");
            Console.WriteLine($"Имя: {name} Фамилия: {surname} Возраст: {age} Рост: {height} Вес: {weight}");

            Shortener.WaitKeyPressed();
        }
    }
}
