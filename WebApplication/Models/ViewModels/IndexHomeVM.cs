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
        public string ChannelName { get; set; }
        public string ChannelIconUrl { get; set; }

        public IndexHomeVM(string channel)
        {
            GetChannelName(channel);
        }
        private void GetChannelName(string channel)
        {
            switch (channel)
            {
                case "svt1.svt":
                    ChannelName = "SVT1";
                    ChannelIconUrl = "http://logos.xmltv.se/svt1.svt.se.png";
                    break;
                case "tv3":
                    ChannelName = "TV3";
                    ChannelIconUrl = "http://logos.xmltv.se/tv3.se.png";
                    break;
                case "tv4":
                    ChannelName = "TV4";
                    ChannelIconUrl = "http://logos.xmltv.se/tv4.se.png";
                    break;
                case "tv6":
                    ChannelName = "TV6";
                    break;
                case "kanal5":
                    ChannelName = "Kanal 5";
                    break;
                case "tv8":
                    ChannelName = "TV8";
                    break;
                default:
                    ChannelName = "Error";
                    break;
            }
        }
        //public void setStartTime()
        //{
        //    foreach (var p in ProgramJsonList)
        //    {
        //        DateTime dateTime = new DateTime(1970, 1, 1, 1, 0, 0, 0, DateTimeKind.Local);
        //        dateTime = dateTime.AddSeconds(Convert.ToInt32(p.start));
        //        p.StartTime = dateTime;
        //    }
            
        //}
        
        //public void ConvertListToString()
        //{
        //    foreach (var item in ProgramJsonList)
        //    {
        //        foreach (var c in item.category.en)
        //        {
        //            item.CategoryToString += c + "/";
        //        }
        //    }
        //}
    }
}