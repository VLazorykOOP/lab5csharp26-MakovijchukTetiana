using System;
using System.Linq;

namespace lab_5.task1
{
    abstract class Document
    {
        public string DocNumber { get; set; }
        public DateTime Date { get; set; }

        public Document(string docNumber, DateTime date)
        {
            DocNumber = docNumber;
            Date = date;
        }
        abstract public void Show();
    }

    class Receipt : Document
    {
        public string PaymentPurpose { get; set; }
        public double Amount { get; set; }

        public Receipt(string docNumber, DateTime date, string paymentPurpose, double amount) 
            : base(docNumber, date) { PaymentPurpose = paymentPurpose; Amount = amount; }

        public override void Show() => Console.WriteLine($"[Квитанція] №{DocNumber} від {Date.ToShortDateString()} | Призначення: {PaymentPurpose} | Сума: {Amount} грн");
    }

    class Waybill : Document
    {
        public string Consignee { get; set; }
        public int ProductCount { get; set; }

        public Waybill(string docNumber, DateTime date, string consignee, int productCount) 
            : base(docNumber, date) { Consignee = consignee; ProductCount = productCount; }

        public override void Show() => Console.WriteLine($"[Накладна] №{DocNumber} від {Date.ToShortDateString()} | Одержувач: {Consignee} | Кількість: {ProductCount} шт.");
    }

    class Bill : Document
    {
        public string Payer { get; set; }
        public double TotalAmount { get; set; }

        public Bill(string docNumber, DateTime date, string payer, double totalAmount) 
            : base(docNumber, date) { Payer = payer; TotalAmount = totalAmount; }

        public override void Show() => Console.WriteLine($"[Рахунок] №{DocNumber} від {Date.ToShortDateString()} | Платник: {Payer} | До сплати: {TotalAmount} грн");
    }

    // Клас, який відповідає за запуск саме цього завдання
    public static class task1Runner
    {
        public static void Run()
        {
            Console.WriteLine(" ВИКОНАННЯ ЗАВДАННЯ 1");
            Document[] docs = new Document[6];
            docs[0] = new Receipt("R-001", new DateTime(2023, 10, 15), "Оплата електроенергії", 1450.50);
            docs[1] = new Waybill("W-102", new DateTime(2023, 10, 05), "ТОВ 'БудМатеріали'", 500);
            docs[2] = new Bill("B-305", new DateTime(2023, 10, 12), "Іванов І.І.", 5000.00);
            docs[3] = new Receipt("R-002", new DateTime(2023, 10, 16), "Оплата інтернету", 300.00);
            docs[4] = new Waybill("W-103", new DateTime(2023, 10, 01), "ПП 'ТрансЛогістік'", 120);
            docs[5] = new Bill("B-306", new DateTime(2023, 10, 14), "Петров П.П.", 12500.00);

            Console.WriteLine("\n Невідсортований масив ");
            foreach (Document doc in docs) doc.Show();

            var sortedDocs = docs.OrderBy(d => d.Date).ToArray();
            Console.WriteLine("\n Відсортований масив (за зростанням дати) ");
            foreach (Document doc in sortedDocs) doc.Show();
        }
    }
}