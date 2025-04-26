using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class SchoolTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Answer { get; set; }

        [Required]
        public int Type { get; set; } // возможно стоит Enum сделать

        public int Difficulty { get; set; }

        [Required]
        public int ParagraphId { get; set; }
        [ForeignKey("ParagraphId")]
        public virtual Paragraph Paragraph { get; set; }

        public string HashImage { get; set; }

        public bool HasAudio { get; set; }

        public virtual ICollection<TestTask> TestTasks { get; set; }
        public virtual ICollection<TaskResult> TaskResults { get; set; }
    }
}
