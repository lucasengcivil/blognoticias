using System.ComponentModel.DataAnnotations;

namespace NoticiasApi.Models;

public class Noticia
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O título da notícia é obrigatório")]
    [MaxLength(100, ErrorMessage = "Título não pode exceder 50 caracteres!")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "O chápeu da notícia é obrigatório")]
    [MaxLength(50, ErrorMessage = "Chápeu não pode exceder 50 caracteres!")]
    public string Chapeu { get; set; }
    [Required(ErrorMessage = "A descrição da notícia é obrigatório!")]
    public string Descricao { get; set; }
    public DateTime DataPublicacao { get; set; }
    [Required(ErrorMessage = "O autor da notícia é obrigatório!")]
    public string Editor { get; set; }
}
