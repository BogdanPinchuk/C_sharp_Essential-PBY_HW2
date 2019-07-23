using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp3
{
    class Program
    {
        static void Main()
        {
            // підключення Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // створення закупки
            Invoice todayBuy = new Invoice(100, "ATB", "Брусилівські ковбаси")
            {
                Article = "Копчена грудинка",
                Price = 140,    // за кг
                Quantity = 100  //кг
            };

            // виведення даних
            todayBuy.ShowInfo();

            // delay
            Console.ReadKey(true);
        }
    }
}
