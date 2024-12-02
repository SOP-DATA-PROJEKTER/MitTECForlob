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
    public class Notes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Note {  get; set; }
        [ForeignKey("User")]
        [AllowNull]
        public int UserId { get; set; }
        [ForeignKey("Course")]
        [AllowNull]
        public int CourseId { get; set; }
    }
}
