using System.ComponentModel.DataAnnotations;

namespace BlogNoticias.Data.Dtos
{
    public class CreateEditorDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string CPF { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}

