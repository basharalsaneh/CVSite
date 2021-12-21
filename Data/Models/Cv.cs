using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
   public class Cv
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Education> Educations { get; set; }
        public virtual ICollection<Competence> Competences { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

        [ForeignKey("ApplicationUser")]
        public int ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
