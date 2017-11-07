using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepoAndUnitOfWorkJSON.Entites
{
    public class Programme
    {
        public Category category { get; set; } = new Category();
        public string channel { get; set; }
        public EpisodeNumber episodeNum { get; set; } = new EpisodeNumber();
        public Title title { get; set; } = new Title();
        public string start { get; set; }
        public string stop { get; set; }
        public Credits credits { get; set; } = new Credits();
        public Description desc { get; set; } = new Description();
        public List<string> country { get; set; } = new List<string>();
        public List<string> url { get; set; } = new List<string>();
        public string date { get; set; }
        public Video video { get; set; } = new Video();
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public string CategoryToString { get; set; }
    }
}