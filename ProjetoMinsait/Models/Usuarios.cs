using System.ComponentModel.DataAnnotations;

namespace ProjetoMinsait.Models
{
    public class Usuarios
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
    }
}
