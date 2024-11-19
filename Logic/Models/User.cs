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
        public virtual AdminKeys? AdminKeys { get; set; }=null;
        public virtual Education? Education { get; set; }
        public virtual Specs? Specs { get; set; }
        public virtual Course? Progress { get; set; }
        public virtual List<Notes>? Notes { get; set; }
    }
}
