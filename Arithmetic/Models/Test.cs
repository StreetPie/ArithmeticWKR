using System.ComponentModel.DataAnnotations;

namespace Arithmetic.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        public virtual ICollection<TestTask> TestTasks { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
