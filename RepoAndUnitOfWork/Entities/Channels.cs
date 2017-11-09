using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Entities
{
    [Table("Channels")]
    public class Channels
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
