using System.ComponentModel.DataAnnotations;
using Models.Validations;
namespace Models
{
   public class Car
   {
      public long Id { get; set; }

      [Required(ErrorMessage = "Digite o nome do carro")]
      [StringLength(100, MinimumLength = 1)]
      [Trim(ErrorMessage = "Espaço inválido")]
      public string Name { get; set; } = string.Empty;
   }
}