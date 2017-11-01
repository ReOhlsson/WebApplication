using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWorkJSON.Entites
{
    public class ListOfChannel
    {
        private List<Channel> listOfChannels { get; set; }

        public List<Channel> GetListOfChannels()
        {
            FillList();
            return listOfChannels;
        }
        private void FillList()
        {
            Channel c = new Channel();
            c.Name = "tv3.se";
            Channel b = new Channel();
            b.Name = "svt.svt1.se";
            listOfChannels.Add(c);
            listOfChannels.Add(b);
        }
    }
}
