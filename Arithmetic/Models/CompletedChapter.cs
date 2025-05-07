using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Models
{
    public class CompletedChapter
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.Now;
    }

}
