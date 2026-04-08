using System;

namespace Lab_4
{
    // Друга частина того ж класу
    sealed partial class Date
    {
        // =========================================================
        // РЕАЛІЗАЦІЯ МЕТОДІВ
        // =========================================================
        
        public partial bool IsValidDate()
        {
            if (year < 1 || month < 1 || month > 12 || day < 1 || day > 31)
                return false;

            int[] daysInMonths = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            bool isLeap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
            if (isLeap) daysInMonths[2] = 29;

            return day <= daysInMonths[month];
        }

        public partial void PrintTextFormat()
        {
            string monthName = month switch
            {
                1 => "січня", 2 => "лютого", 3 => "березня", 4 => "квітня",
                5 => "травня", 6 => "червня", 7 => "липня", 8 => "серпня",
                9 => "вересня", 10 => "жовтня", 11 => "листопада", 12 => "грудня",
                _ => "невідомого місяця"
            };
            Console.WriteLine($"{day} {monthName} {year} року");
        }

        public partial void PrintNumberFormat()
        {
            Console.WriteLine((string)this);
        }

        private partial int GetAbsoluteDays()
        {
            int totalDays = day;
            int[] daysInMonths = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

            for (int y = 1; y < year; y++)
                totalDays += (y % 4 == 0 && (y % 100 != 0 || y % 400 == 0)) ? 366 : 365;

            bool isLeap = (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0));
            if (isLeap) daysInMonths[2] = 29;

            for (int m = 1; m < month; m++)
                totalDays += daysInMonths[m];

            return totalDays;
        }

        public partial int DaysBetween(Date otherDate)
        {
            return Math.Abs(this.GetAbsoluteDays() - otherDate.GetAbsoluteDays());
        }

        public partial int CompareTo(Date other)
        {
            if (other == null) return 1;
            return this.GetAbsoluteDays().CompareTo(other.GetAbsoluteDays());
        }
    }
}