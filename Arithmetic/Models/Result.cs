using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class Result
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual User Student { get; set; }

        [Required]
        public int TestId { get; set; }
        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

        public int Score { get; set; }

        public DateTime SubmissionDate { get; set; }

        public virtual ICollection<TaskResult> TaskResults { get; set; }
    }
}
