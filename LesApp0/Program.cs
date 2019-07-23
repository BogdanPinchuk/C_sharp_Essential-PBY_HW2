using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp0
{
    class Program
    {
        static void Main()
        {
            // підключення Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення анкети/профілю
            User myProfile = new User()
            {
                Login = "Pinchar",
                FirstName = "Bogdan",
                SecondName = "Pinchuk",
                Age = 27
            };

            User myFriend = new User("Vlad_OK", "Vlad", "Kycherencko", 26);

            // виведення даних на екран
            myProfile.ShowInfo();
            myFriend.ShowInfo();

            // delay
            Console.ReadKey(true);
        }
    }
}
