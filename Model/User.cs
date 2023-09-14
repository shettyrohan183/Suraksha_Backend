using System.ComponentModel.DataAnnotations;

namespace Final_youtube.Model
{
    public class User
    {
        [Key,Required]
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
