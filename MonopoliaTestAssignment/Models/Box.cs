using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopoliaTestAssignment.Models
{
    [Table("Boxes")]
    public class Box : WarehouseItem
    {
        [Required] public int Weight { get; set; }

        [Required] public DateOnly Date { get; set; }

        [Required] public bool IsExpirationDate { get; set; }

        [Required, ForeignKey("PalletId")] public Pallet? Pallet { get; set; }

        [NotMapped] public override int Volume => Width * Height * Depth;

        [NotMapped] public override DateOnly? ExpirationDate => IsExpirationDate ? Date : Date.AddDays(100);
    }
}
