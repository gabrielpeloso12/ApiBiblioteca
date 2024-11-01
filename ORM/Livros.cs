using System.ComponentModel.DataAnnotations;


namespace ORM
{
    public class Livros
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Title obrigatorio")]
        [StringLength(40, ErrorMessage = "O Title deve conter no máximo 40 caracteres")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Campo Author obrigatorio")]
        [StringLength(40, ErrorMessage = "O Author deve conter no máximo 40 caracteres")]
        public string Autor { get; set; } = null!;

        public string? DataPublicacao { get; set; }

        [Required(ErrorMessage = "Campo Status obrigatorio")]
        [StringLength(40, ErrorMessage = "O Status deve conter no máximo 40 caracteres")]
        public char Disponivel { get; set; } 
    }
}
