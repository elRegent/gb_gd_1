using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// *Создать класс с методами, которые могут пригодиться в вашей учебе (Print, Pause)

// Галеев Руслан gamedev

namespace LessonSystemHelpers
{
    public class Shortener
    {
        public static void WaitKeyPressed()
        {
            Console.ReadKey();
        }

        public static void Print(string text)
        {
            Console.WriteLine(text);
        }
    }
}
