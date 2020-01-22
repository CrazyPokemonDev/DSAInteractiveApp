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

namespace DSAInteractiveApp.Modeling.Calendar
{
    public class AventurianDateSpan
    {
        public int Years { get; }
        public int Months { get; }
        public int Days { get; }
        public int TotalMonths { get => Years * 12 + Months; }
        public int TotalDays { get => Years * 365 + Months * 30 + Days; }

        /// <summary>
        /// Creates a new aventurian date span by adding the months and days to the years
        /// </summary>
        /// <param name="years">Years for this date span</param>
        /// <param name="months">Additional months for this date span</param>
        /// <param name="days">Addiditional days for this date span</param>
        public AventurianDateSpan(int years = 0, int months = 0, int days = 0)
        {
            if (years < 0) throw new ArgumentException("Time span can't be negative", nameof(years));
            if (months < 0) throw new ArgumentException("Time span can't be negative", nameof(months));
            if (days < 0) throw new ArgumentException("Time span can't be negative", nameof(days));
            while (days >= 365)
            {
                years++;
                days -= 365;
            }
            while (days >= 30)
            {
                days -= 30;
                months++;
            }
            while (months >= 12)
            {
                if (days >= 5)
                {
                    years++;
                    months -= 12;
                    days -= 5;
                }
                else if (months > 12)
                {
                    years++;
                    months -= 13;
                    days += 25;
                }
                else break;
            }
            Years = years;
            Months = months;
            Days = days;
        }

        public override bool Equals(object obj)
        {
            if (obj is AventurianDateSpan span) return this == span;
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Days}d{Months}m{Years}y";
        }

        public static bool operator ==(AventurianDateSpan left, AventurianDateSpan right)
        {
            return left.Years == right.Years && left.Months == right.Months && left.Days == right.Days;
        }

        public static bool operator !=(AventurianDateSpan left, AventurianDateSpan right)
        {
            return !(left == right);
        }
    }
}