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
        public string ChannelOriginalName { get; set; }

        public IndexHomeVM(string channel)
        {
            GetChannelName(channel);
        }
        private void GetChannelName(string channel)
        {
            switch (channel)
            {
                case "tv10":
                    ChannelName = "TV10";
                    ChannelIconUrl = "http://logos.xmltv.se/svt1.svt.se.png";
                    ChannelOriginalName = "tv10";
                    break;
                case "tv3":
                    ChannelName = "TV3";
                    ChannelIconUrl = "http://logos.xmltv.se/tv3.se.png";
                    ChannelOriginalName = "tv3";
                    break;
                case "tv4":
                    ChannelName = "TV4";
                    ChannelIconUrl = "http://logos.xmltv.se/tv4.se.png";
                    ChannelOriginalName = "tv4";
                    break;
                case "tv6":
                    ChannelName = "TV6";
                    ChannelIconUrl = "http://logos.xmltv.se/tv6.se.png";
                    ChannelOriginalName = "tv6";
                    break;
                case "kanal5":
                    ChannelName = "Kanal 5";
                    ChannelIconUrl = "http://logos.xmltv.se/kanal5.se.png";
                    ChannelOriginalName = "kanal5";
                    break;
                case "tv8":
                    ChannelName = "TV8";
                    ChannelIconUrl = "http://logos.xmltv.se/tv8.se.png";
                    ChannelOriginalName = "tv8";
                    break;
                default:
                    ChannelName = "Error";
                    break;
            }
        }
    }
}