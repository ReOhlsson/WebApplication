using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoAndUnitOfWork.Entities
{
    [Table("Program")]
    public class Program
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Program()
        {
            this.Person = new HashSet<Person>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public long Start_time { get; set; }
        public long End_time { get; set; }
        public string Channel { get; set; }
        public int Click { get; set; }
        public bool Editor_recommendation { get; set; }
        public string Picture { get; set; }
        public string Description { get; set; }
        public string Categories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Person> Person { get; set; }

    }
}
