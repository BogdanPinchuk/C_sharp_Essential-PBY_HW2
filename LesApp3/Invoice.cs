using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// не зрозуміло, для чого просто створювати закриті поля і їх не використовувати
// string article, int quantity - відповідно до умови???
// + ні слова про ціну товару

namespace LesApp3
{
    /// <summary>
    /// Накладна
    /// </summary>
    class Invoice
    {
        /// <summary>
        /// ПДВ з/без вкрахування
        /// </summary>
        public enum Tax
        {
            /// <summary>
            /// включає ПДВ
            /// </summary>
            include,
            /// <summary>
            /// без ПДВ
            /// </summary>
            without
        }

        /// <summary>
        /// Номер облікового запису
        /// </summary>
        public readonly int account;
        /// <summary>
        /// Покупець - в магазині
        /// </summary>
        public readonly string customer;
        /// <summary>
        /// Постачальник послуг - доставщик
        /// </summary>
        public readonly string provider;

        // назва продукту
        private string article;
        // кількість одиниць
        private int quantity;

        /// <summary>
        /// Ціна продукції за одиницю/кг
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Розрахунок ПДВ в 20%
        /// </summary>
        /// <returns></returns>
        public double CalcTax()
        {
            return 0.2 * Quantity * Price;
        }

        /// <summary>
        /// Оплата з ПДВ і без
        /// </summary>
        /// <returns></returns>
        public double Pay(Tax tax)
        {
            // ціна на оплату
            double pay = Quantity * Price;

            switch (tax)
            {
                case Tax.without:
                    break;
                case Tax.include:
                    pay += CalcTax();
                    break;
            }

            return pay;
        }
        /// <summary>
        /// Відображення оплати з/без ПДВ
        /// </summary>
        /// <param name="tax"></param>
        public void ShowPay(Tax tax)
        {
            Console.Write("Оплата ");
            switch (tax)
            {
                case Tax.include:
                    Console.WriteLine($"з ПДВ: {Pay(tax):N2} грн");
                    break;
                case Tax.without:
                    Console.WriteLine($"без ПДВ: {Pay(tax):N2} грн");
                    break;
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Підсумкова інформація
        /// </summary>
        public void ShowInfo()
        {
            Console.WriteLine($"Номер облікового запису: {account}");
            Console.WriteLine($"Покупець: {customer}");
            Console.WriteLine($"Постачальник послуг: {provider}");
            Console.WriteLine($"\n\tНазва продукту: {article}");
            Console.WriteLine($"\tКількість одиниць або маса: {quantity}\n");
            // виведення результуючої ціни
            ShowPay(Tax.without);
            ShowPay(Tax.include);
        }

        // додаткові дані по продукції
        /// <summary>
        /// Назва продукту, додаткові дані на накладну
        /// </summary>
        public string Article
        {
            get { return article; }
            set { article = value; }
        }
        /// <summary>
        /// Кількість одиниць продукції, додаткові дані на накладну
        /// </summary>
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Невірно введені дані!");
                }
                else
                {
                    quantity = value;
                }
            }
        }

        /// <summary>
        /// Створення закупки в певний момент
        /// </summary>
        /// <param name="account">Номер облікового запису</param>
        /// <param name="customer"> Покупець - в магазині</param>
        /// <param name="provider">Постачальник послуг - доставщик</param>
        public Invoice(int account, string customer, string provider)
        {
            this.account = account;
            this.customer = customer;
            this.provider = provider;
        }

    }
}
