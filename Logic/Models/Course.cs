using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;

namespace Logic.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CourseName { get; set; }
        [AllowNull]
        public List<Subj> SubjectList {  get; set; } = new List<Subj>();
        [ForeignKey("Specs")]
        [AllowNull]
        public int SpecsId { get; set; }
    }
}
