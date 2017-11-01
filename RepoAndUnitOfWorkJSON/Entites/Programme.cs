using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoAndUnitOfWorkJSON.Entites
{
    public class Programme
    {
        public Category category { get; set; }
        public string channel { get; set; }
        public EpisodeNumber episodeNum { get; set; }
        public Title title { get; set; }
        public string start { get; set; }
        public string stop { get; set; }
        public Credits credits { get; set; }
        public Description desc { get; set; }
        public List<string> country { get; set; }
        public List<string> url { get; set; }
        public string date { get; set; }
        public Video video { get; set; }
    }
}