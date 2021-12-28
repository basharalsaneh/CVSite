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
        [Key, ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        [StringLength(150, ErrorMessage = "Max 150 tecken.")]
        [Display(Name = "Kompetens")]
        public string Competence { get; set; }
        [StringLength(150, ErrorMessage = "Max 150 tecken.")]
        [Display(Name = "Utbildning")]
        public string Education { get; set; }
        [StringLength(150, ErrorMessage = "Max 150 tecken.")]
        [Display(Name = "Erfarenhet")]
        public string Experience { get; set; }


    }
}
