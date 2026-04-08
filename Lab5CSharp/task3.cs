using System;

namespace lab_5.task3

{
    // Абстрактний базовий клас
    abstract class Software
    {
        public string Title { get; set; }
        public string Manufacturer { get; set; }

        public Software(string title, string manufacturer) 
        { 
            Title = title; 
            Manufacturer = manufacturer; 
        }

        public abstract void ShowInfo();
        public abstract bool IsUsable();
    }

    // Похідний клас 1: Вільне ПЗ
    class FreeSoftware : Software
    {
        public FreeSoftware(string title, string manufacturer) : base(title, manufacturer) { }
        
        public override void ShowInfo() => Console.WriteLine($"[Вільне ПЗ] Назва: {Title} | Виробник: {Manufacturer}");
        
        public override bool IsUsable() => true; 
    }

    // Похідний клас 2: Умовно-безкоштовне ПЗ
    class SharewareSoftware : Software
    {
        public DateTime InstallDate { get; set; }
        public int FreeTermDays { get; set; } 

        public SharewareSoftware(string title, string manufacturer, DateTime installDate, int freeTermDays) : base(title, manufacturer)
        {
            InstallDate = installDate; 
            FreeTermDays = freeTermDays;
        }

        public override void ShowInfo() => Console.WriteLine($"[Shareware] Назва: {Title} | Встановлено: {InstallDate.ToShortDateString()} | Термін: {FreeTermDays} днів");
        
        public override bool IsUsable() => (DateTime.Today - InstallDate).Days <= FreeTermDays;
    }

    // Похідний клас 3: Комерційне ПЗ
    class CommercialSoftware : Software
    {
        public double Price { get; set; }
        public DateTime InstallDate { get; set; }
        public int UsageTermDays { get; set; } 

        public CommercialSoftware(string title, string manufacturer, double price, DateTime installDate, int usageTermDays) : base(title, manufacturer)
        {
            Price = price; 
            InstallDate = installDate; 
            UsageTermDays = usageTermDays;
        }

        public override void ShowInfo() => Console.WriteLine($"[Комерційне ПЗ] Назва: {Title} | Ціна: {Price} грн | Термін: {UsageTermDays} днів");
        
        public override bool IsUsable() => (DateTime.Today - InstallDate).Days <= UsageTermDays;
    }

    // Клас для запуску Завдання 3
    public static class task3Runner
    {
        public static void Run()
        {
            Console.WriteLine(" ВИКОНАННЯ ЗАВДАННЯ 3 ");
            Console.WriteLine($"Поточна дата: {DateTime.Today.ToShortDateString()}\n");

            Software[] softwareList = new Software[]
            {
                new FreeSoftware("VLC Media Player", "VideoLAN"),
                new SharewareSoftware("WinRAR", "RAR LAB", DateTime.Today.AddDays(-15), 30), // Це ще доступне
                new CommercialSoftware("Microsoft Office", "Microsoft", 3200.00, DateTime.Today.AddDays(-400), 365) // А тут термін вже вийшов
            };

            // 1. Виведення повної інформації з бази (згідно умови)
            Console.WriteLine(" ПОВНИЙ СПИСОК ПЗ ");
            foreach (var sw in softwareList)
            {
                sw.ShowInfo();
                Console.WriteLine($"    Статус: {(sw.IsUsable() ? "ДОСТУПНО" : "ТЕРМІН ВИЙШОВ")}\n");
            }

            // 2. Організація пошуку ПЗ, яке припустимо використовувати (згідно умови)
            Console.WriteLine("РЕЗУЛЬТАТИ ПОШУКУ: ПЗ, ДОСТУПНЕ ДЛЯ ВИКОРИСТАННЯ ");
            
            bool foundAny = false;
            foreach (var sw in softwareList)
            {
                if (sw.IsUsable()) // Перевіряємо метод: якщо true, виводимо
                {
                    sw.ShowInfo();
                    foundAny = true;
                }
            }
            
            if (!foundAny)
            {
                Console.WriteLine("Доступного ПЗ не знайдено.");
            }
        }
    }
}