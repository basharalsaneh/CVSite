using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
   public class Education
    {
        [Key]
        public int Id
        {
            get; set;
        }
        public string Text
        {
            get; set;
        }

        [ForeignKey("Cv")]
        public int CvId { get; set; }
        public Cv Cv { get; set; }    }
}
