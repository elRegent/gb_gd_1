using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;

// Переделать программу Пример использования коллекций для решения следующих задач:
// а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
// б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся(*частотный массив);
// в) отсортировать список по возрасту студента;
// г) * отсортировать список по курсу и возрасту студента;


namespace StudentsList
{

    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int course, int age, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
    class Program
    {
        static int SortAge(Student st1, Student st2)
        {

            return st1.age.CompareTo(st2.age);
        }

        static int SortCourseAge(Student st1, Student st2)
        {
            if (st1.course != st2.course)
            {
                return st1.course.CompareTo(st2.course);
            }
            return st1.age.CompareTo(st2.age);
        }
        static void Main(string[] args)
        {
            List<Student> list = new List<Student>();
            StreamReader sr = new StreamReader("../../students_6.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');

                    list.Add(new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[6]), int.Parse(s[5]), int.Parse(s[7]), s[8]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            Console.WriteLine("Всего студентов:" + list.Count);

            list.Sort(new Comparison<Student>(SortAge));

            int courses5_6 = 0;
            int[] chastArr = new int[6] { 0, 0, 0, 0, 0, 0 };
            Console.WriteLine("======================");
            Console.WriteLine("Отсортированный по возрасту список студентов:");
            foreach (var v in list)
            {
                Console.WriteLine($"{v.firstName}, Возраст {v.age}, Курс {v.course}");
                if (v.course == 5 || v.course == 6)
                {
                    courses5_6++;
                }
                if (v.age >= 18 && v.age <= 20) {
                    chastArr[v.course - 1]++;
                }
            }

            Console.WriteLine("======================");
            Console.WriteLine($"Студентов 5 6го курсов: {courses5_6}");

            Console.WriteLine("======================");
            Console.WriteLine("Массив частотный студжентов от 18 до 20 лет по курсам");
            for (int i = 0; i < chastArr.Length; i++)
            {
                Console.WriteLine($"{chastArr[i]}");
            }

            Console.WriteLine("======================");
            list.Sort(new Comparison<Student>(SortCourseAge));
            Console.WriteLine("Отсортированный по курсу и возрасту список студентов:");
            foreach (var v in list)
            {
                Console.WriteLine($"{v.firstName}, Возраст {v.age}, Курс {v.course}");
            }
            Console.ReadKey();
        }
    }
}
