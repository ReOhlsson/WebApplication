using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Data
{
    public class ProgramOperations
    {
        private List<JsonProgram> jsonList = new List<JsonProgram>();
        public ProgramOperations(string date)
        {
            GetJsonChannel(date, "svt1.svt");
            GetJsonChannel(date, "tv3");
            GetJsonChannel(date, "tv4");
        }
        public List<JsonProgram> GetAllPrograms()
        {
            return jsonList;
        }
        public JsonProgram GetProgram(string name, DateTime time)
        {
            return null;
        }
        private void GetJsonChannel(string date, string channel)
        {
            string url = "http://json.xmltv.se/" + channel + ".se_" + date + ".js.gz";
            var json = new WebClient().DownloadString(url);
            JsonProgram jp = JsonConvert.DeserializeObject<JsonProgram>(json);

            jsonList.Add(jp);
        }
    }
}