using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class Chapter
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<Paragraph> Paragraphs { get; set; }
    }
}
