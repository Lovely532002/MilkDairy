using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Login
{
    public class AdminLogin
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is reqired!")]
        [StringLength(8, ErrorMessage = "Password length must be 8 characters!")]
        public string Password { get; set; }
    }
}
