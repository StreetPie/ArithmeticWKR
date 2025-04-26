using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class TaskResult
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ResultId { get; set; }
        [ForeignKey("ResultId")]
        public virtual Result Result { get; set; }

        [Required]
        public int TaskId { get; set; }
        [ForeignKey("TaskId")]
        public virtual SchoolTask Task { get; set; }

        public string AnswerGiven { get; set; }

        public bool IsCorrect { get; set; }

        public int TimeSpent { get; set; }
    }
}
