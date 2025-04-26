using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class Paragraph
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [Required]
        public int ChapterId { get; set; }
        [ForeignKey("ChapterId")]
        public virtual Chapter Chapter { get; set; }

        public virtual ICollection<SchoolTask> Tasks { get; set; }
    }
}
