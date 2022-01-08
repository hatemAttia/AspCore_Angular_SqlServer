using System.ComponentModel.DataAnnotations;

namespace AspCore_Angular_SqlServer.Models
{
    public class Admin
    {
        public int Id { get; set; }
        [Required]
        public string Nom { get; set; }
        [Required]
        public string Prenom { get; set; }

        [Required]
        public string Email { get; set; }
        public string Image { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Tel { get; set; }
        public string Token { get; set; }
    }
}
