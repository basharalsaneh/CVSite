using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApplicationUser> Users { get; set; }


        //[ForeignKey("ApplicationUser")]
        //public string UserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
