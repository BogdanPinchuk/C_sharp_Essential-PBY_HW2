using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LesApp1
{
    /// <summary>
    /// Конвертація валют
    /// </summary>
    class Converter
    {
        /// <summary>
        /// Перелік валют, які підтримуються даною версією програми,
        /// щоб скористатися більшою кількістю валют придбайте повну версію програми =)
        /// </summary>
        public enum Currency
        {
            /// <summary>
            /// долар
            /// </summary>
            usd,
            /// <summary>
            /// євро
            /// </summary>
            eur,
            /// <summary>
            /// рублі
            /// </summary>
            rub
        }

        /// <summary>
        /// долар
        /// </summary>
        internal readonly double usd;
        /// <summary>
        /// євро
        /// </summary>
        internal readonly double eur;
        /// <summary>
        /// рубль
        /// </summary>
        internal readonly double rub;

        /// <summary>
        /// Українська гривня
        /// </summary>
        public double GRN { get; set; }
        /// <summary>
        /// Долар
        /// </summary>
        public double USD { get; set; }
        /// <summary>
        /// Євро
        /// </summary>
        public double EUR { get; set; }
        /// <summary>
        /// Рублі
        /// </summary>
        public double RUB { get; set; }

        /// <summary>
        /// Внесення курсу валют
        /// </summary>
        /// <param name="usd">долар</param>
        /// <param name="eur">євро</param>
        /// <param name="rub">рубль</param>
        public Converter(double usd, double eur, double rub)
        {
            if (usd <= 0 || eur <= 0 || rub <= 0)
            {
                Console.WriteLine("\n\tПомилка введеня валюти!");
                return;
            }

            this.usd = usd;
            this.eur = eur;
            this.rub = rub;     // раніше подавали інфо за 10 грн тому можна було б тут записати "rub / 10;"
        }

        /// <summary>
        /// Конвертація в долари
        /// </summary>
        /// <returns></returns>
        public double ConvertToUSD()
        {
            return GRN / usd;
        }

        /// <summary>
        /// Конвертація в євро
        /// </summary>
        /// <returns></returns>
        public double ConvertToEUR()
        {
            return GRN / eur;
        }

        /// <summary>
        /// Конвертація в рублі
        /// </summary>
        /// <returns></returns>
        public double ConvertToRUB()
        {
            return GRN / eur;
        }

        /// <summary>
        /// Конвертація у вибрану валюту
        /// </summary>
        /// <param name="cur">валюта, яку необхідно вибрати для конвертації</param>
        /// <returns></returns>
        public double ConvertTo(Currency cur)
        {
            // конвертована валюта
            double res = default;

            // конвертація, можна заекономи ресурси ПК і скористатися однією змінною
            switch (cur)
            {
                case Currency.usd:
                    res = usd;
                    goto default;
                case Currency.eur:
                    res = eur;
                    goto default;
                case Currency.rub:
                    res = rub;
                    goto default;
                default:
                    res = GRN / res;
                    break;
            }

            // поверненя результату
            return res;
        }

        /// <summary>
        /// Відображення результату конверації в іноземну валюту
        /// </summary>
        public void ShowConvertToOtherCur(Currency cur)
        {
            Console.WriteLine("\nРезультат конвертації:");

            // назва валюти в яку відбуваєть конвертація
            string val = string.Empty;

            switch (cur)
            {
                case Currency.usd:
                    val = "доларів";
                    goto default;
                case Currency.eur:
                    val = "євро";
                    goto default;
                case Currency.rub:
                    val = "рублів";
                    goto default;
                default:
                    Console.WriteLine($"\n\t{GRN:N2} гривень = {ConvertTo(cur):N2} {val}");
                    break;
            }

        }

        /// <summary>
        /// Зворотня конвертація в гривні
        /// </summary>
        /// <param name="cur">конвертована валюта</param>
        /// <returns></returns>
        public double BackConvert(Currency cur)
        {
            // конвертована валюта
            double res = default;

            // конвертація
            switch (cur)
            {
                case Currency.usd:
                    res = usd * USD;
                    break;
                case Currency.eur:
                    res = eur * EUR;
                    break;
                case Currency.rub:
                    res = rub * RUB;
                    break;
            }

            // поверненя результату
            return res;
        }

        /// <summary>
        /// Відображення результату конверації в гривні
        /// </summary>
        public void ShowBackConvertCur(Currency cur)
        {
            Console.WriteLine("\nРезультат конвертації:");

            // назва валюти в яку відбуваєть конвертація
            string val = string.Empty;

            double forCur = default;

            switch (cur)
            {
                case Currency.usd:
                    val = "доларів";
                    forCur = USD;
                    goto default;
                case Currency.eur:
                    val = "євро";
                    forCur = EUR;
                    goto default;
                case Currency.rub:
                    val = "рублів";
                    forCur = RUB;
                    goto default;
                default:
                    Console.WriteLine($"\n\t{forCur:N2} {val} = {BackConvert(cur):N2} гривень");
                    break;
            }
        }


    }
}
