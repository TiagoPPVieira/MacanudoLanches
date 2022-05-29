using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MacanudoLanches.Models
{
    public class Lanche
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome do lanche deve ser informado")]
        [Display(Name="Nome do lanche")]
        [StringLength(80, MinimumLength = 5, ErrorMessage ="O {0} deve ter no mínimo {1} e no máximo {2}")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Descrição do lanche")]
        [MinLength(20, ErrorMessage = "Descrição deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição deve ter no máximo {1} caracteres")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "O nome do lanche deve ser informado")]
        [Display(Name = "Descrição detalhada do lanche")]
        [MinLength(20, ErrorMessage = "Descrição detalhada deve ter no mínimo {1} caracteres")]
        [MaxLength(200, ErrorMessage = "Descrição detalhada deve ter no máximo {1} caracteres")]
        public string LongDescription { get; set; }

        [Required(ErrorMessage ="Informe o preço do lanche")]
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")]
        [Range(1, 999.99, ErrorMessage ="O preço deve estar entre 1 e 999,99 reais")]
        public decimal Price { get; set; }

        [Display(Name ="Caminho Imagem Normal")]
        [StringLength(200, ErrorMessage ="O {0} deve ter no máximo {1} caracteres")]
        public string ImageUrl { get; set; }

        [Display(Name = "Caminho Imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name ="Preferido?")]
        public bool IsLanchePreferred { get; set; }

        [Display(Name ="Estoque")]
        public bool InStock { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
