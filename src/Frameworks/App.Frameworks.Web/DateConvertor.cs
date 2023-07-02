using System;
using System.Globalization;
namespace App.Frameworks.Web
{
    public class DateConvertor
    {


        public string ConvertToPersianDate(DateTime dateTime)
         {
        PersianCalendar persianCalendar = new PersianCalendar();
        int year = persianCalendar.GetYear(dateTime);
        int month = persianCalendar.GetMonth(dateTime);
        int day = persianCalendar.GetDayOfMonth(dateTime);

            return $"{year}/{month:00}/{day:00}";
         }
        public DateTime ConvertToGregorianDate(int year, int month, int day)
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            DateTime gregorianDate = persianCalendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            return gregorianDate;
        }
    }

}