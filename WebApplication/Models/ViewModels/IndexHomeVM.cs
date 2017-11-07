using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Data;
using System.Data.Entity;
using RepoAndUnitOfWorkJSON.Entites;
using RepoAndUnitOfWork.Concrete;
using RepoAndUnitOfWorkJSON.Concrete;
using System.Globalization;

namespace WebApplication.Models.ViewModels
{
    public class IndexHomeVM
    {
        public List<Programme> ProgramJsonList { get; set; } = new List<Programme>();
        public List<Days> ListOfDays { get; set; } = new List<Days>();
        public string ChannelName { get; set; }

        public IndexHomeVM(UnitOfWorkJson unit, string date, string channel)
        {
            ProgramJsonList = unit.ProgramRepository.ListOfJsonProgram(date, channel);
            GetChannelName(channel);
            setStartTime();
            SetListOfDays();
            ConvertListToString();
        }
        private void GetChannelName(string channel)
        {
            switch (channel)
            {
                case "svt1.svt":
                    ChannelName = "SVT1";
                    break;
                case "tv3":
                    ChannelName = "TV3";
                    break;
                case "tv4":
                    ChannelName = "TV4";
                    break;
                default:
                    ChannelName = "Error";
                    break;
            }
        }
        private void setStartTime()
        {
            foreach (var p in ProgramJsonList)
            {
                DateTime dateTime = new DateTime(1970, 1, 1, 1, 0, 0, 0, DateTimeKind.Local);
                dateTime = dateTime.AddSeconds(Convert.ToInt32(p.start));
                p.StartTime = dateTime;
            }
            
        }
        private void SetListOfDays()
        {
            DateTime date = DateTime.Now;
            for (int i = -3; i < 3; i++)
            {
                Days d = new Days();
                d.Date = DateTime.Now;
                d.Date = d.Date.AddDays(i);
                d.Day = DateTimeFormatInfo.CurrentInfo.GetDayName(d.Date.DayOfWeek);
                d.Day = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(d.Day.ToLower());

                ListOfDays.Add(d);
            }
        }
        private void ConvertListToString()
        {
            foreach (var item in ProgramJsonList)
            {
                foreach (var c in item.category.en)
                {
                    item.CategoryToString += c + "/";
                }
            }
        }
    }
}