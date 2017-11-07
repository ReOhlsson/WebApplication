using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace WebApplication.Models.ViewModels
{
    public class DaysVM
    {
        public List<Days> ListOfDays { get; set; } = new List<Days>();

        public DaysVM()
        {
            SetListOfDays();
        }
        private void SetListOfDays()
        {
            DateTime date = DateTime.Now;
            for (int i = 0; i <= 7; i++)
            {
                Days d = new Days();
                d.Date = DateTime.Now;
                d.Date = d.Date.AddDays(i);
                d.Day = DateTimeFormatInfo.CurrentInfo.GetDayName(d.Date.DayOfWeek);
                d.Day = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(d.Day.ToLower());

                ListOfDays.Add(d);
            }
        }
    }
}