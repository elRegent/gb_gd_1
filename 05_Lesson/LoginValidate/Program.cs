using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
// Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет строка от 2 до 10 символов,
//  содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
// а) без использования регулярных выражений;
// б) ** с использованием регулярных выражений.
namespace LoginValidate
{
    class Program
    {
        static bool CheckWithoutRegExp(string login)
        {
            if (login.Length > 10 || login.Length < 2) return false;

            // первым идет число - сразу выход
            if (char.IsNumber(login[0])) return false;

            string lowerText = login.ToLower();
            for (int i = 0; i < login.Length; i++)
            {
                // убеждаемся что ничего кроме букв и цифр тут нет
                if (!char.IsLetter(login[i]) && !char.IsNumber(login[i])) return false;

                // проверка на латиницу 
                if (char.IsLetter(login[i])) {
                    bool isLatin = lowerText[i] >= 'a' && lowerText[i] <= 'z';
                    if (!isLatin) return false;
                }

            }
            return true;
        }
        static bool CheckWithRegExp(string login)
        {
            Regex loginReg = new Regex(@"^[a-zA-Z][a-zA-Z0-9]{1,9}$");
            return loginReg.IsMatch(login);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите логин:");
            string login = Console.ReadLine();

            if (!CheckWithRegExp(login))
            {
                Console.WriteLine("Ваш логин не прошел проверку регуляркой");
            }

            if (!CheckWithoutRegExp(login)) 
            {
                Console.WriteLine("Ваш логин не прошел обычную проверку");
            }

            Console.ReadKey();
        }
    }
}
