using System;
using System.Globalization;

namespace Lab_4
{
    // Запечатаний та частковий клас
    sealed partial class Date : IComparable<Date>
    {
        
        private int day;
        private int month;
        private int year;

        // Властивості
        public int Day
        {
            get { return day; }
            set 
            { 
                if (value >= 1 && value <= 31) day = value; 
                else Console.WriteLine("Помилка: День має бути від 1 до 31.");
            }
        }

        public int Month
        {
            get { return month; }
            set 
            { 
                if (value >= 1 && value <= 12) month = value; 
                else Console.WriteLine("Помилка: Місяць має бути від 1 до 12.");
            }
        }

        public int Year
        {
            get { return year; }
            set 
            { 
                if (value > 0) year = value; 
                else Console.WriteLine("Помилка: Рік має бути додатнім числом.");
            }
        }

        public int Century
        {
            get { return (year - 1) / 100 + 1; }
        }

        // Конструктор
        public Date(int day, int month, int year)
        {
            Day = day;
            Month = month;
            Year = year;
        }

        // Індексатор
        public Date this[int i]
        {
            get
            {
                DateTime dt = new DateTime(year, month, day).AddDays(i);
                return new Date(dt.Day, dt.Month, dt.Year);
            }
        }

        // Перевантаження операторів та перетворень типів 
        public static bool operator !(Date d)
        {
            int daysInMonth = DateTime.DaysInMonth(d.year, d.month);
            return d.day != daysInMonth;
        }

        public static bool operator true(Date d) => d.day == 1 && d.month == 1;
        public static bool operator false(Date d) => d.day != 1 || d.month != 1;

        public static bool operator &(Date d1, Date d2)
        {
            if (ReferenceEquals(d1, null) || ReferenceEquals(d2, null)) return false;
            return d1.day == d2.day && d1.month == d2.month && d1.year == d2.year;
        }

        public static implicit operator string(Date d) => $"{d.day:D2}.{d.month:D2}.{d.year:D4}";

        public static explicit operator Date(string s)
        {
            if (DateTime.TryParseExact(s, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dt))
            {
                return new Date(dt.Day, dt.Month, dt.Year);
            }
            throw new ArgumentException("Помилка: Невірний формат рядка. Очікується 'ДД.ММ.РРРР'.");
        }

        public override string ToString()
        {
            return $"{day:D2}.{month:D2}.{year:D4}";
        }
        // Оголошення методів 
        public partial bool IsValidDate();
        public partial void PrintTextFormat();
        public partial void PrintNumberFormat();
        private partial int GetAbsoluteDays();
        public partial int DaysBetween(Date otherDate);
        public partial int CompareTo(Date other);
    }
}