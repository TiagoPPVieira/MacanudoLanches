using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacanudoLanches.Models
{
    [Table("Categorias")]
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100,ErrorMessage ="O tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage ="Informe o nome da categoria")]
        [Display(Name ="Nome")]
        public string Name { get; set; }

        [StringLength(200, ErrorMessage = "O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage = "Informe a descrição da categoria")]
        [Display(Name = "Descrição")]
        public string Description { get; set; }
        public List<Lanche> Lanches { get; set; }
    }
}