using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    /// <summary>
    /// Інформація про коритувача
    /// </summary>
    class User
    {
        /// <summary>
        /// Логін
        /// </summary>
        public string Login { get; set; }
        /// <summary>
        /// Ім'я
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Прізвище
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// Вік
        /// </summary>
        public byte Age { get; set; }
        /// <summary>
        /// Дата створення анкети користувача
        /// </summary>
        public DateTime DateCreate { get; private set; }

        // звичайно можна було використати ще поле із модифікатором readonly
        // але була поради краще використовувати властивості, а поля ховати

        /// <summary>
        /// Створення екземпляра пустої анкети але з даною створення
        /// </summary>
        public User()
        {
            // ініціалізація лише раз
            DateCreate = DateTime.Now;
        }

        /// <summary>
        /// Перегрузка конструктора, з можливістю зразу ввести параметри користувача
        /// </summary>
        /// <param name="login">Логін</param>
        /// <param name="fmane">Ім'я</param>
        /// <param name="sname">Прізвище</param>
        /// <param name="age">Вік</param>
        public User(string login, string fmane, string sname, byte age)
            : this()
        {
            Login = login;
            FirstName = fmane;
            SecondName = sname;
            Age = age;
        }

        /// <summary>
        /// Виведення інформації про користувача
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"\nCustomer:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tLogin: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Login);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tFirst Name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(FirstName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tSecond Name: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SecondName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tAge: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Age);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tDate create of profile: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(DateCreate);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
