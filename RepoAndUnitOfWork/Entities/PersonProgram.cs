using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Entities
{
    [Table("PersonProgram")]
    public partial class PersonProgram
    {
        [ForeignKey("Person")]		
        [Column(Order = 1)]
        public int Person_Id { get; set; }
        [ForeignKey("Program")]
        [Column(Order = 2)]
        public int Program_id { get; set; }
        public DateTime SavedDate { get; set; }
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Program Program { get; set; }
    }
}
