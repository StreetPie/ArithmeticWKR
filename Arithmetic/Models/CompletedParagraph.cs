using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arithmetic.Models
{
    public class CompletedParagraph
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public int ParagraphId { get; set; }
        [ForeignKey("ParagraphId")]
        public virtual Paragraph Paragraph { get; set; }

        public DateTime CompletedAt { get; set; } = DateTime.Now;
    }

}
