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

        }

        public JsonProgram GetJsonChannel(string date, string channel)
        {
            string url = "http://json.xmltv.se/" + channel + ".se_" + date + ".js.gz";
            var json = new WebClient().DownloadString(url);
            JsonProgram jp = JsonConvert.DeserializeObject<JsonProgram>(json);

            return jp;
        }
    }
}
