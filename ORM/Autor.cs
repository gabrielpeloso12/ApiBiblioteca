using System.ComponentModel.DataAnnotations;

namespace ORM
{
    public class Autor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [StringLength(40, ErrorMessage = "O campo nome deve ter no máximo 40 caracteres")]
        public string? Nome { get; set; } 
    }
}
