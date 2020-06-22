using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//* Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой.
// Например:
// badc являются перестановкой abcd.
namespace Replacement
{
    class Program
    {
        static bool CheckStrsForReplacement(string str1, string str2)
        {
            if (str1.Length != str2.Length) return false;
            
            Dictionary<char, int> letters = new Dictionary<char, int>();
            for(int i = 0; i < str1.Length; i++)
            {
                if (!letters.ContainsKey(str1[i]))
                {
                    letters.Add(str1[i], 0);
                }

                if (!letters.ContainsKey(str2[i]))
                {
                    letters.Add(str2[i], 0);
                }
                letters[str1[i]]++;
                letters[str2[i]]--;
            }

            foreach (int val in letters.Values)
            {
                if (val != 0) return false;
            }
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку");
            string str1 = Console.ReadLine();
            Console.WriteLine("Введите вторую строку");
            string str2 = Console.ReadLine();

            Console.WriteLine($"Строки {(CheckStrsForReplacement(str1, str2) ? "" : "не ")}являются перестановкой");

            Console.ReadLine();
        }
    }
}
