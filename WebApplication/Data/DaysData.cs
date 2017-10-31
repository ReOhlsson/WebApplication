using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class DaysData
    {
        private List<Days> dtTimes = new List<Days>();

        public List<Days> GetAllDays()
        {

            for (int i = -3; i < 3; i++)
            {
                Days d = new Days();
                d.Date = DateTime.Now;
                d.Date = d.Date.AddDays(i);
                d.Day = DateTimeFormatInfo.CurrentInfo.GetDayName(d.Date.DayOfWeek);
                dtTimes.Add(d);
            }

            return dtTimes;
        }
    }
}