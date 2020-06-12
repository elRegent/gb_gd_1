using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Задание 1
// Дан целочисленный  массив из 20 элементов.
// Элементы массива  могут принимать  целые значения  от –10 000 до 10 000 включительно.
// Заполнить случайными числами.Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых только одно число делится на 3. 
// В данной задаче под парой подразумевается два подряд идущих элемента массива.Например, для массива из пяти элементов: 6; 2; 9; –3; 6 ответ — 2. 

namespace PairsOneDelim
{
    class RandArray
    {
        int[] arr;
        int len;

        
        public RandArray (int len, int min, int max)
        {
            this.arr = new int[len];
            this.len = len;

            Random rnd = new Random();
            for (int i = 0; i < len; i++)
            {
                this.arr[i] = rnd.Next(min, max);
            }
        }
        public RandArray() : this(20, -10000, 10000) 
        {
        }

        public int DelimPairs(int delim)
        {
            int result = 0;
            // проверяем текущий и следующий, поэтому len-1
            for (int i = 0; i < len - 1; i++)
            {
                byte count = 0;
                if (this.arr[i] % delim == 0)
                {
                    count++;
                }
                if (this.arr[i+1] % delim == 0)
                {
                    count++;
                }

                if (count == 1)
                {
                    result++;
                }
            }

            return result;
        }

        public void PrintArray()
        {
            string row = "";
            for (int i = 0; i < len; i++)
            {
                row = row + (i > 0 ? " " : "") + this.arr[i];
            }

            Console.WriteLine(row);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RandArray randArray = new RandArray();

            randArray.PrintArray();

            Console.WriteLine($"Ответ по задаче (кол-во пар): {randArray.DelimPairs(3)}");

            Console.ReadKey();
        }
    }
}
