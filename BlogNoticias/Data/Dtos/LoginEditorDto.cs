using System.ComponentModel.DataAnnotations;

namespace BlogNoticias.Data.Dtos
{
    public class LoginEditorDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

