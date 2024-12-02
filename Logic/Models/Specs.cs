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
    public class Specs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SpecsName { get; set; }
        public string Description {  get; set; }
        [AllowNull]
        public List<Course>? Courses { get; set; }
        public DateTime? EndTime { get; set; }
        public bool EuxAvailability { get; set; }
        // Foreign key to Education
        [AllowNull]
        [ForeignKey("Education")]
        public int EducationId { get; set; }
    }
}
