using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp2
{
    class Program
    {
        static void Main()
        {
            // підключення Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // Створення співробітника
            Employee someone = new Employee("Pinchuk", "Bogdan")
            {
                Degree = Employee.Science.Master,
                Experience = 3
            };

            // до отримання кандидатської
            Console.WriteLine("\nДо отримання кандидатської:\n");
            someone.ShowInfo();

            // після отримання кандидатської
            someone.Degree = Employee.Science.PhD;
            Console.WriteLine("\nПісля отримання кандидатської:\n");
            someone.ShowInfo();

            // delay
            Console.ReadKey(true);
        }
    }
}
