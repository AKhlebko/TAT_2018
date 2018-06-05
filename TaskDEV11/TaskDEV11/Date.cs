using System;

namespace TaskDEV11
{
    public class Date
    {
        public static readonly int[] MonthDays = new int[12] { 31, 28, 31, 30, 31, 30, 31, 30, 31, 30, 31, 30 };

        private int day;
        private int month;
        private int year;

        public int Day
        {
            get
            {
                return day;
            }
            set
            {
                if (MonthDays[Month - 1] < value || value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of days for this month is incorrect");
                }
                else
                {
                    day = value;
                }
            }
        }

        public int Month
        {
            get
            {
                return month;
            }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentOutOfRangeException("Month can only be between 1 and 12.");
                }
                else
                {
                    month = value;
                }
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("Year can't be smaller than 1.");
                }
                else
                {
                    year = value;
                }
            }
        }

        /// <summary>
        /// Constructor makes instance of Date structer
        /// </summary>
        /// <param name="DateInStringFormat">
        /// Date in DD/MM/YYYY format
        /// </param>
        public Date(string DateInStringFormat)
        {
            string[] parts = DateInStringFormat.Split('/');
            int month = 0;
            int day = 0;
            int year = 0;
            if (parts.Length != 3)
                throw new FormatException(message: "Date was input in a wrong way");
            if (!(int.TryParse(parts[0], out day) && int.TryParse(parts[1], out month) && int.TryParse(parts[2], out year)))
            {
                throw new FormatException(message: "Date format is invalid.");
            }
            Month = month;
            Day = day;
            Year = year;
        }

        /// <summary>
        /// Method gets all extra days added because of leap year
        /// </summary>
        /// <param name="year">
        /// The last year
        /// </param>
        /// <returns>
        /// number of 
        /// </returns>
        public int GetLeapYearsExtraDays(int year)
        {
            int response = 0;
            for (int i = 1; i <= year; i++)
            {
                if (IsLeapYear(i))
                    response++;
            }
            return response;
        }

        /// <summary>
        /// Method checks whether the year is leap or not
        /// </summary>
        /// <param name="year">
        /// The year to check whether it's leap
        /// </param>
        /// <returns>
        /// True when the it's leap year, false when it's not
        /// </returns>
        public bool IsLeapYear(int year)
        {
            bool response = false;
            if (year % 4 == 0)
            {
                response = true;
            }
            if (year % 100 == 0)
            {
                response = false;
            }
            if (year % 400 == 0)
            {
                response = true;
            }
            return response;
        }
    }
}