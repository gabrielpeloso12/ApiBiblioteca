using System.ComponentModel.DataAnnotations;


namespace ORM
{
    public class Livros
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Title obrigatorio")]
        [StringLength(40, ErrorMessage = "O Title deve conter no máximo 40 caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Campo Autor obrigatorio")]
        public int Autor { get; set; }

        public DateTime DataPublicacao { get; set; }

        [Required(ErrorMessage = "Campo Status obrigatorio")]
        public char Disponivel { get; set; } 
    }
}
