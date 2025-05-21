using System.ComponentModel.DataAnnotations.Schema;

namespace MonopoliaTestAssignment.Models
{
    public class Box : WarehouseItem
    {
        public int Weight { get; set; }

        public DateOnly Date { get; set; }
        
        public bool IsExpirationDate { get; set; }

        public int PalletId { get; set; }

        public Pallet? Pallet { get; set; }

        [NotMapped] public override int Volume => Width * Height * Depth;

        [NotMapped] public override DateOnly? ExpirationDate => IsExpirationDate ? Date : Date.AddDays(100);
    }
}
