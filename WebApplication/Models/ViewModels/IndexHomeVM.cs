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
    }
}