using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.Marshalling;

namespace Logic.Models
{
    public class Subj
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public virtual Progress? Progress { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
