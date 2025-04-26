using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Arithmetic.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime RegistrationDate { get; set; }

        [Required]
        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public int? ClassId { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Class { get; set; }
    }
}
