using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Logic.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [AllowNull]
        public AdminKeys? AdminKeys { get; set; }
        public string Education { get; set; }
        public string Specs { get; set; }
        public string Course { get; set; }
        [AllowNull]
        public List<Notes>? Notes { get; set; }
        [AllowNull]
        public List<InternshipGoalCheck>? InternshipGoalCheck { get; set; }
    }
}
