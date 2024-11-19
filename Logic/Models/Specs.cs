using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class Specs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string SpecsName { get; set; }
        public string Description {  get; set; }
        public List<Course>? Courses { get; set; } = new List<Course>();
        public DateTime? EndTime { get; set; }
    }
}
