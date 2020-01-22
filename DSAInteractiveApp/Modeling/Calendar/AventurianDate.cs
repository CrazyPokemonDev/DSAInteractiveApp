using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace DSAInteractiveApp.Modeling.Calendar
{
    public class AventurianDate
    {
        /// <summary>
        /// The year of the date after the fall of Bosparan (can be negative)
        /// </summary>
        public int Year { get; }
        /// <summary>
        /// The month of the date, one-based. 0 for the Nameless Days.
        /// Note that the nameless days aren't actually at the beginning of the year, in fact they mark the end of one
        /// </summary>
        public int Month { get; }
        /// <summary>
        /// The day of the month, one-based.
        /// </summary>
        public int Day { get; }
        [JsonIgnore]
        /// <summary>
        /// A list of month names, with the item at index 0 being "Namenloser Tag" for the nameless days
        /// </summary>
        public static readonly string[] MonthNames = { "Namenloser Tag", "Praios", "Rondra", "Efferd", "Travia", "Boron", "Hesinde", "Firun", "Tsa", "Phex", "Peraine", "Ingerimm", "Rahja" };
        /// <summary>
        /// Initializes a new aventurian date
        /// </summary>
        /// <param name="day">The day of the month, one-based.</param>
        /// <param name="month">The month of the year, one-based. 0 for the nameless days.</param>
        /// <param name="year">The year after the fall of Bosparan</param>
        public AventurianDate(int day, int month, int year)
        {
            if (month > 12 || month < 0) throw new ArgumentException("Invalid month number", nameof(month));
            if (day < 1 || day > 30 || (month == 0 && day > 5)) throw new ArgumentException("Invalid day of month", nameof(day));
            Year = year;
            Month = month;
            Day = day;
        }
        public override string ToString()
        {
            return $"{Day}. {MonthNames[Month]} {Math.Abs(Year)} {(Year < 0 ? "v. BF" : "BF")}";
        }

        #region Operators
        public static bool operator ==(AventurianDate left, AventurianDate right)
        {
            return left.Year == right.Year && left.Month == right.Month && left.Day == right.Day;
        }
        public static bool operator !=(AventurianDate left, AventurianDate right)
        {
            return !(left == right);
        }
        public override bool Equals(object obj)
        {
            if (obj is AventurianDate date) return this == date;
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static AventurianDateSpan operator -(AventurianDate left, AventurianDate right)
        {
            if (left == right) return new AventurianDateSpan();
            AventurianDate earlier, later;
            if (left.Year < right.Year
                || (left.Year == right.Year && (left.Month < right.Month || right.Month == 0) && left.Month != 0)
                || (left.Year == right.Year && left.Month == right.Month && left.Day < right.Day))
            {
                earlier = left;
                later = right;
            }
            else
            {
                earlier = right;
                later = left;
            }
            int years, months, days;
            years = later.Year - earlier.Year;
            if (years == 0)
            {
                months = later.Month - earlier.Month;
                // if months is now less than 0, the later month must have been the nameless days
                if (months < 0) months += 13;
                days = later.Day - earlier.Day;
                // if days is now less than 0, it's because of the month difference, correct it
                if (days < 0)
                {
                    days += 30;
                    months--;
                }
            }
            else
            {
                int daysUntilEndOfYear = earlier.Month == 0 ? 5 - earlier.Day : (12 - earlier.Month) * 30 + (30 - earlier.Day) + 5;
                years--;
                if (later.Month == 0)
                {
                    months = 12;
                    days = later.Day;
                }
                else
                {
                    months = later.Month - 1;
                    days = later.Day;
                }
                days += daysUntilEndOfYear;
            }
            return new AventurianDateSpan(years, months, days);
        }

        public static bool operator <(AventurianDate left, AventurianDate right)
        {
            if (left == right) return false;
            if (left.Year < right.Year
                || (left.Year == right.Year && (left.Month < right.Month || right.Month == 0) && left.Month != 0)
                || (left.Year == right.Year && left.Month == right.Month && left.Day < right.Day))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(AventurianDate left, AventurianDate right)
        {
            if (left == right) return false;
            return !(left < right);
        }

        public static bool operator <=(AventurianDate left, AventurianDate right)
        {
            return left == right || left < right;
        }

        public static bool operator >=(AventurianDate left, AventurianDate right)
        {
            return left == right || left > right;
        }
        #endregion
    }
}