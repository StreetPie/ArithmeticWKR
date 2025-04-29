using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class TeacherClass
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Учитель
        public int ClassId { get; set; }

        [ForeignKey("UserId")]
        public User Teacher { get; set; }

        [ForeignKey("ClassId")]
        public Class Class { get; set; }
    }
}
