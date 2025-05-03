using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Marketplace.Data

{
    [Table("Users")]
    public class User : BaseModel
    {
        [Key]
        [Required]
        [Column("Id")]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Username")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [Column("Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        [Column("Password_Hash")]
        public string PasswordHash { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("Phone_Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}