using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Entities
{
    [Table("Program")]
    public class Program
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Start_time { get; set; }
        public string End_time { get; set; }
        public string Channel { get; set; }
        public int Click { get; set; }
        public bool Most_clicked { get; set; }
        public bool Editor_recommendation { get; set; }
        public string Picture { get; set; }
    }
}
