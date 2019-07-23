using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    class Program
    {
        static void Main()
        {
            // підключення Unicode
            Console.OutputEncoding = Encoding.Unicode;

            // курс валют станом на 05.07.2019
            // 1 usd = 25.736 grn
            // 1 eur = 28.925 grn
            // 1 rub = 0.349 grn

            // Створення курсу валют
            Converter converter = new Converter(25.736, 28.925, 0.349);

            // внесення суми користувача
            double customer = 17120;

            // виведення даних
            converter.GRN = customer;
            converter.ShowConvertToOtherCur(Converter.Currency.usd);
            converter.ShowConvertToOtherCur(Converter.Currency.eur);
            converter.ShowConvertToOtherCur(Converter.Currency.rub);

            // ціна Tesla Model X https://cardiagram.com.ua/gde-kupit-tesla-v-ukraine-6030.html
            converter.USD = 200000;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЦіна Tesla Model X:");
            Console.ResetColor();
            converter.ShowBackConvertCur(Converter.Currency.usd);

            // ціна квартири в Блолгарії https://politeka.net/ua/news/559444-de-najdeshevshe-zhitlo-v-yevropi-5-populyarnih-krayin/
            converter.EUR = 40000;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЦіна квартири в Блолгарії:");
            Console.ResetColor();
            converter.ShowBackConvertCur(Converter.Currency.eur);

            // ціна iPhone Xs https://www.apple.com/ru/shop/buy-iphone/iphone-xs
            converter.RUB = 98634;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nЦіна iPhone Xs:");
            Console.ResetColor();
            converter.ShowBackConvertCur(Converter.Currency.rub);

            // delay
            Console.ReadKey(true);
        }
    }
}
