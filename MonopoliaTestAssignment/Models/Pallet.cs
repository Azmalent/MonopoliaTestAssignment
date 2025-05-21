using System.ComponentModel.DataAnnotations.Schema;

namespace MonopoliaTestAssignment.Models
{
    [Table("Pallets")]
    public class Pallet : WarehouseItem
    {
        internal static readonly int PALLET_WEIGHT = 30;

        public List<Box> Boxes { get; set; } = [];

        [NotMapped] public int Weight => Boxes.Sum(box => box.Weight) + PALLET_WEIGHT;

        [NotMapped] public override int Volume => Boxes.Sum(box => box.Volume) + Width * Height * Depth;

        [NotMapped] public override DateOnly? ExpirationDate => Boxes.Count > 0 ? Boxes.Min(box => box.ExpirationDate) : null;
    }
}
