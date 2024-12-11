using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class InternshipGoalCheck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<bool> Goals { get; set; }
        [ForeignKey("User")]
        [AllowNull]
        public int UserId { get; set; }
        [ForeignKey("Course")]
        [AllowNull]
        public int? CourseId { get; set; }
    }
}
