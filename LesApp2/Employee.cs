using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// точних даних по званням не знаю, да й це засекречена інформація
// тому опишу дані по науковим званням

namespace LesApp2
{
    /// <summary>
    /// Співробітник
    /// </summary>
    class Employee
    {
        /// <summary>
        /// Наукове звання, http://media.miu.by/files/store/items/uses/xxii/mim_uses_xxii_10007.pdf
        /// </summary>
        public enum Science
        {
            /// <summary>
            /// Звичайний працівник
            /// </summary>
            Usual,
            /// <summary>
            /// Магістр
            /// </summary>
            Master,
            /// <summary>
            /// Кандидат наук
            /// </summary>
            PhD,
            /// <summary>
            /// Доктор наук
            /// </summary>
            GrandPhD
        }

        private Science degree;
        private byte experience;

        /// <summary>
        /// Ім'я
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// Прізвище
        /// </summary>
        public string SecondName { get; }
        /// <summary>
        /// Наукове звання
        /// </summary>
        public Science Degree
        {
            get { return degree; }
            set
            {
                degree = value;
                Bonus = ConvertExpToBonus(experience) + ConvertSciToBonus(degree);
            }
        }
        /// <summary>
        /// Стаж співробітника в роках
        /// </summary>
        public byte Experience
        {
            get { return experience; }
            set
            {
                experience = value;
                Bonus = ConvertExpToBonus(experience) + ConvertSciToBonus(degree);
            }
        }
        /// <summary>
        /// результуюча доплата
        /// </summary>
        public double Bonus { get; private set; }
        /// <summary>
        /// Оклад співробітника, ммінімальна ЗП за 2019
        /// https://www.pravda.com.ua/news/2019/01/1/7202760/
        /// </summary>
        public double BaseSalary { get; } = 4173;

        /// <summary>
        /// Ініціалізація базової інформації про співробітника
        /// </summary>
        /// <param name="sname">Прізвище</param>
        /// <param name="fname">Ім'я</param>
        public Employee(string sname, string fname)
        {
            SecondName = sname;
            FirstName = fname;
        }

        /// <summary>
        /// Розрахунок ЗП в залежнсоті від звання, досвіду та налогу
        /// </summary>
        /// <returns></returns>
        public double Salary()
        {
            return (1 + Bonus) * BaseSalary - CalcTax();
        }
        /// <summary>
        /// Розрахунок налогу в 20%
        /// </summary>
        /// <returns></returns>
        public double CalcTax()
        {
            return 0.2 * (1 + Bonus) * BaseSalary;
        }
        /// <summary>
        /// Відображення інформації про співробітника
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine("\nДані по співробітнику:");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tПрізвище: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(SecondName);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tІм'я: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(FirstName);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tНаукове звання: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Degree);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tСтаж: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Experience);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"\tПодаток: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(CalcTax());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"\tЗаробітня платня: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Salary());
            Console.ResetColor();
            Console.WriteLine();
        } 

        /// <summary>
        /// Доплата за наукове звання
        /// доплачується лише коли працюєш по спеціальності
        /// </summary>
        /// <param name="sci">наукове звання</param>
        /// <returns></returns>
        private double ConvertSciToBonus(Science sci)
        {
            // доплата за звання
            double bonus = default;

            switch (sci)
            {
                case Science.Usual:
                    bonus = 0.0;
                    break;
                case Science.Master:    // зазвичай + за червоний диплом магістра
                    bonus = 5.0 / 100;
                    break;
                case Science.PhD:       // + 15% зверху за кандидата наук
                    bonus = (5.0 + 15.0) / 100;
                    break;
                case Science.GrandPhD:  // + 40% зверху до всього за доктора наук
                    bonus = (5.0 + 15.0 + 40.0) / 100;
                    break;
            }

            return bonus;
        }
        /// <summary>
        /// Доплата за вислугу років на одному підприємстві
        /// https://zakon.rada.gov.ua/laws/show/1049-93-п
        /// </summary>
        /// <param name="exp">Стаж в роках</param>
        /// <returns></returns>
        private double ConvertExpToBonus(byte exp)
        {
            // доплата за досвід
            double bonus = default;

            // розрахунок
            if (exp < 3)
            {
                bonus = 0.0;
            }
            else if (3 <= exp && exp < 5)
            {
                bonus = 10.0 / 100;
            }
            else if (5 <= exp && exp < 10)
            {
                bonus = 15.0 / 100;
            }
            else if (10 <= exp && exp < 15)
            {
                bonus = 20.0 / 100;
            }
            else if (15 <= exp && exp < 20)
            {
                bonus = 25.0 / 100;
            }
            else if (20 <= exp && exp < 25)
            {
                bonus = 30.0 / 100;
            }
            else if (exp >= 25)
            {
                bonus = 40.0 / 100;
            }

            return bonus;
        }

    }
}
