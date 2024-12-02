using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.Marshalling;
using System.Diagnostics.CodeAnalysis;

namespace Logic.Models
{
    public class Subj
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SubjectName { get; set; }
        public string Description { get; set; }
        [ForeignKey("Course")]
        [AllowNull]
        public int CourseId { get; set; }
        public string Duration { get; set; }
    }
}
