using System;

namespace lab_5.task2
{
    abstract class Document
    {
        public string DocNumber { get; set; }
        public DateTime Date { get; set; }

        public Document() { DocNumber = "Без номера"; Date = DateTime.Now; Console.WriteLine("-> [Doc] Викликано конструктор БЕЗ параметрів."); }
        public Document(string num) { DocNumber = num; Date = DateTime.Now; Console.WriteLine($"-> [Doc] Викликано конструктор з 1 параметром."); }
        public Document(string num, DateTime date) { DocNumber = num; Date = date; Console.WriteLine($"-> [Doc] Викликано ПОВНИЙ конструктор."); }
        ~Document() { Console.WriteLine($"<- [Doc] Викликано деструктор для документа №{DocNumber}."); }
        abstract public void Show();
    }

    class Receipt : Document
    {
        public string PaymentPurpose { get; set; }
        public double Amount { get; set; }

        public Receipt() : base() { PaymentPurpose = "Невідомо"; Console.WriteLine("=> [Receipt] Конструктор БЕЗ параметрів.\n"); }
        public Receipt(string num, double amt) : base(num) { PaymentPurpose = "Загальний платіж"; Amount = amt; Console.WriteLine("=> [Receipt] Частковий конструктор.\n"); }
        public Receipt(string num, DateTime date, string purp, double amt) : base(num, date) { PaymentPurpose = purp; Amount = amt; Console.WriteLine("=> [Receipt] ПОВНИЙ конструктор.\n"); }
        ~Receipt() { Console.WriteLine($"<= [Receipt] Деструктор для Квитанції №{DocNumber}."); }
        public override void Show() => Console.WriteLine($"[Квитанція] №{DocNumber} від {Date.ToShortDateString()} | {PaymentPurpose} | {Amount} грн");
    }

    class Waybill : Document
    {
        public string Consignee { get; set; }
        public int ProductCount { get; set; }

        public Waybill() : base() { Consignee = "Невідомо"; Console.WriteLine("=> [Waybill] Конструктор БЕЗ параметрів.\n"); }
        public Waybill(string num, string cons) : base(num) { Consignee = cons; ProductCount = 1; Console.WriteLine("=> [Waybill] Частковий конструктор.\n"); }
        public Waybill(string num, DateTime date, string cons, int count) : base(num, date) { Consignee = cons; ProductCount = count; Console.WriteLine("=> [Waybill] ПОВНИЙ конструктор.\n"); }
        ~Waybill() { Console.WriteLine($"<= [Waybill] Деструктор для Накладної №{DocNumber}."); }
        public override void Show() => Console.WriteLine($"[Накладна] №{DocNumber} від {Date.ToShortDateString()} | Одержувач: {Consignee}");
    }

    // ДОДАНО ПРОПУЩЕНИЙ КЛАС "РАХУНОК" (Bill)
    class Bill : Document
    {
        public string Payer { get; set; }
        public double TotalAmount { get; set; }

        public Bill() : base() { Payer = "Анонім"; TotalAmount = 0.0; Console.WriteLine("=> [Bill] Конструктор БЕЗ параметрів.\n"); }
        public Bill(string num, double totalAmount) : base(num) { Payer = "Роздрібний покупець"; TotalAmount = totalAmount; Console.WriteLine("=> [Bill] Частковий конструктор.\n"); }
        public Bill(string num, DateTime date, string payer, double totalAmount) : base(num, date) { Payer = payer; TotalAmount = totalAmount; Console.WriteLine("=> [Bill] ПОВНИЙ конструктор.\n"); }
        ~Bill() { Console.WriteLine($"<= [Bill] Деструктор для Рахунку №{DocNumber}."); }
        public override void Show() => Console.WriteLine($"[Рахунок] №{DocNumber} від {Date.ToShortDateString()} | Платник: {Payer} | Сума: {TotalAmount} грн");
    }

    public static class task2Runner
    {
        public static void Run()
        {
            Console.WriteLine(" ДЕМОНСТРАЦІЯ РОБОТИ КОНСТРУКТОРІВ \n");
            
            // Збільшуємо масив, щоб вмістити всі 9 варіантів (3 класи * 3 конструктори)
            Document[] docs = new Document[9];

            // 1. Демонстрація всіх 3-х конструкторів для Receipt (Квитанція)
            docs[0] = new Receipt();
            docs[1] = new Receipt("R-002", 500.50);
            docs[2] = new Receipt("R-003", new DateTime(2023, 10, 15), "Оплата послуг", 1200.00);

            // 2. Демонстрація всіх 3-х конструкторів для Waybill (Накладна)
            docs[3] = new Waybill();
            docs[4] = new Waybill("W-002", "ТОВ 'Роги та Копита'");
            docs[5] = new Waybill("W-003", new DateTime(2023, 10, 16), "ПП 'Логістика'", 300);

            // 3. Демонстрація всіх 3-х конструкторів для Bill (Рахунок)
            docs[6] = new Bill();
            docs[7] = new Bill("B-002", 15000.00);
            docs[8] = new Bill("B-003", new DateTime(2023, 10, 17), "Іванов І.І.", 850.00);

            Console.WriteLine(" ВИВІД ДАНИХ ");
            foreach (Document doc in docs) doc.Show();

            Console.WriteLine("\n ЗНИЩЕННЯ ОБ'ЄКТІВ ");
            Array.Clear(docs, 0, docs.Length);
            docs = null;
            
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}