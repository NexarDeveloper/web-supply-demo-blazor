using System.ComponentModel.DataAnnotations;

namespace Nexar.Supply.Models
{
    public class Login
    {
        [Required]
        public string ClientId { get; set; }
        [Required]
        public string ClientSecret { get; set; }
    }
}
