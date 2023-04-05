using System.ComponentModel.DataAnnotations;
namespace Models
{
   public class Car
   {
      public long Id { get; set; }

      [Required(ErrorMessage = "Digite o nome do carro")]
      [MaxLength(100)]
      public string Name { get; set; } = string.Empty;
   }
}