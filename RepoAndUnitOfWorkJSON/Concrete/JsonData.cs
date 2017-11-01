using Newtonsoft.Json;
using RepoAndUnitOfWorkJSON.Entites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWorkJSON.Concrete
{
    public class JsonData
    {
        private List<JsonProgram> jsonList = new List<JsonProgram>();
        public JsonData()
        {
            //GetJsonChannel(date, "svt1.svt");
            //GetJsonChannel(date, "tv3");
            //GetJsonChannel(date, "tv4");
        }
        //public List<JsonProgram> GetAllPrograms()
        //{
        //    return jsonList;
        //}
        //public JsonProgram GetProgram(string name, DateTime time)
        //{
        //    return null;
        //}
        //private void GetJsonChannel(string date, string channel)
        //{
        //    string url = "http://json.xmltv.se/" + channel + ".se_" + date + ".js.gz";
        //    var json = new WebClient().DownloadString(url);
        //    JsonProgram jp = JsonConvert.DeserializeObject<JsonProgram>(json);

        //    jsonList.Add(jp);



        //    var culture = new System.Globalization.CultureInfo("sv-SE");
        //    var day = culture.DateTimeFormat.GetDayName(DateTime.Today.DayOfWeek);

        //    DateTime d = DateTime.Today;
        //    string dt = DateTimeFormatInfo.CurrentInfo.GetDayName(d.DayOfWeek);

        //}
        public JsonProgram GetJsonChannel(string date, string channel)
        {
            string url = "http://json.xmltv.se/" + channel + ".se_" + date + ".js.gz";
            var json = new WebClient().DownloadString(url);
            JsonProgram jp = JsonConvert.DeserializeObject<JsonProgram>(json);

            return jp;
        }
    }
}
