using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Arithmetic.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Class { get; set; }

        [Required]
        public int DurationMinutes { get; set; }

        public virtual ICollection<TestTask> TestTasks { get; set; }
    }
}
