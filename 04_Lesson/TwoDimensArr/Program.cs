using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// Задание 5
// *а) Реализовать библиотеку с классом для работы с двумерным массивом.
// Реализовать конструктор, заполняющий массив случайными числами. 
// Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного,
//    свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива,
//    метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out).
// ** б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
// ** в) Обработать возможные исключительные ситуации при работе с файлами.
namespace TwoDimensArr
{
    class TwoDimensRandArray
    {
        int[,] arr;
        int rows;
        int cols;

        // вынес в отдельный метод чтобы не дублировать код при выхове из разных конструкторов (обычный и при обработке исключений из файла)
        private void setupRandArray(int rows, int cols, int min, int max)
        {
            this.arr = new int[rows, cols];
            this.rows = rows;
            this.cols = cols;
            Random rnd = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    this.arr[i, j] = rnd.Next(min, max);
                }
            }
        }

        public TwoDimensRandArray(int rows, int cols, int min, int max)
        {
            this.setupRandArray(rows, cols, min, max);
        }

        // дефолтный конструктор
        public TwoDimensRandArray() : this(4, 5, 1, 1000)
        {

        }

        // из файла
        public TwoDimensRandArray(string filename)
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                this.rows = int.Parse(sr.ReadLine());
                this.cols = int.Parse(sr.ReadLine());
                this.arr = new int[this.rows, this.cols];

                for (int i = 0; i < this.rows; i++)
                {
                    string row = sr.ReadLine();
                    // Console.WriteLine($"Считал {row}");

                    string[] rowSplitted = row.Split(' ');

                    for (int j = 0; j < this.cols; j++)
                    {
                        this.arr[i, j] = int.Parse(rowSplitted[j]);
                    }
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Ошибка считывания файла - файл не найден. Создаем дефолтно");
                this.setupRandArray(4, 5, 1, 1000);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Не все элементы являются числами. Создаем дефолтно");
                this.setupRandArray(4, 5, 1, 1000);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Неверное число элементов для массива. Создаем дефолтно");
                this.setupRandArray(4, 5, 1, 1000);
            }
        }

        private void PrintRow(int rowNum)
        {
            string row = "";
            for (int i = 0; i < this.cols; i++)
            {
                row = row + (i > 0 ? " " : "") + this.arr[rowNum, i];
            }

            Console.WriteLine(row);
        }

        public void PrintArray()
        {
            for (int i = 0; i < this.rows; i++)
            {
                PrintRow(i);
            }
        }

        private int FindMaxInRow(int rowNum)
        {
            int max = this.arr[rowNum, 0];
            for (int i = 1; i < this.cols; i++)
            {
                if (max < this.arr[rowNum, i])
                {
                    max = this.arr[rowNum, i];
                }
            }

            return max;
        }
        private int FindMax()
        {
            int max = FindMaxInRow(0);

            for (int i = 1; i < this.rows; i++) 
            {
                int maxInRow = FindMaxInRow(i);
                if (max < maxInRow)
                {
                    max = maxInRow;
                }
            }

            return max;
        }

        private int FindMinInRow(int rowNum)
        {
            int min = this.arr[rowNum, 0];
            for (int i = 1; i < this.cols; i++)
            {
                if (min > this.arr[rowNum, i])
                {
                    min = this.arr[rowNum, i];
                }
            }

            return min;
        }
        private int FindMin()
        {
            int min = FindMinInRow(0);

            for (int i = 1; i < this.rows; i++)
            {
                int minInRow = FindMinInRow(i);
                if (min > minInRow)
                {
                    min = minInRow;
                }
            }

            return min;
        }

        public int Max
        {
            get {
                return this.FindMax();
            }
        }

        public int Min
        {
            get
            {
                return this.FindMin();
            }
        }

        public void FindMaxNum(out int row, out int col)
        {
            int maxVal = this.arr[0, 0];
            row = 0;
            col = 0;

            for (int i = 0; i < this.rows; i++)
            {
                int startJ = (i == 0) ? 1 : 0; // 0 0 - уже стартовый максимум, не надо его перепроверять
                for (int j = startJ; j < this.cols; j++)
                {
                    if (this.arr[i, j] > maxVal)
                    {
                        maxVal = this.arr[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }

        public void FindMinNum(out int row, out int col)
        {
            int minVal = this.arr[0, 0];
            row = 0;
            col = 0;

            for (int i = 0; i < this.rows; i++)
            {
                int startJ = (i == 0) ? 1 : 0; // 0 0 - уже стартовый  минимум, не надо его перепроверять
                for (int j = startJ; j < this.cols; j++)
                {
                    if (this.arr[i, j] < minVal)
                    {
                        minVal = this.arr[i, j];
                        row = i;
                        col = j;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TwoDimensRandArray twoDimensRandArray = new TwoDimensRandArray();

            twoDimensRandArray.PrintArray();

            Console.WriteLine($"Минимум {twoDimensRandArray.Min}");
            Console.WriteLine($"Максимум {twoDimensRandArray.Max}");

            int rowMin, colMin, rowMax, colMax;
            twoDimensRandArray.FindMinNum(out rowMin, out colMin);
            twoDimensRandArray.FindMaxNum(out rowMax, out colMax);
            Console.WriteLine($"Номер минимума {rowMin} - {colMin}");
            Console.WriteLine($"Номер максимума {rowMax} - {colMax}");

            // Из файла
            TwoDimensRandArray twoDimensRandArray2 = new TwoDimensRandArray("../../hw.txt");
            twoDimensRandArray2.PrintArray();
            Console.ReadKey();
        }
    }
}
