using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class TestTask
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TestId { get; set; }

        [ForeignKey("TestId")]
        public virtual Test Test { get; set; }

        [Required]
        public int TaskId { get; set; }

        [ForeignKey("TaskId")]
        public virtual SchoolTask Task { get; set; }
    }
}
