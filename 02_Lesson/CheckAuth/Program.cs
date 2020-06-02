using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// Реализовать метод проверки логина и пароля. На вход метода подается логин и пароль.
// На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains).
// Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
// С помощью цикла do while ограничить ввод пароля тремя попытками.


namespace CheckAuth
{
    class Program {

        static string savedPassword = "GeekBrains";
        static string savedLogin = "root";
        static bool CheckPassword(string login, string password)
        {
            return (login == savedLogin && savedPassword == password);
        }

        static void ExecuteSmth()
        {
            Console.WriteLine("Вы получили доступ куда-то");
        }

        static void Main(string[] args)
        {
            int i = 0;

            bool accessGranted = false;

            while (i < 3)
            {
                if (i > 0)
                {
                    Console.WriteLine($"Осталось попыток: {3 - i}");
                }
                Console.WriteLine("Введите логин");
                string login = Console.ReadLine();


                Console.WriteLine("Введите пароль");
                string password = Console.ReadLine();

                if (CheckPassword(login, password))
                {
                    accessGranted = true;
                    break;
                }

                i++;
            }

            if (accessGranted)
            {
                ExecuteSmth();
            } 
            else
            {
                Console.WriteLine("Доступ запрещен");
            }

            Console.ReadKey();
        }
    }
}
