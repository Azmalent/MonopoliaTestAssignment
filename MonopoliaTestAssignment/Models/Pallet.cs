namespace MonopoliaTestAssignment.Models
{
    public class Pallet : WarehouseItem
    {
        internal static readonly int PALLET_WEIGHT = 30;

        public List<Box> Boxes { get; set; } = [];

        public int Weight => Boxes.Sum(box => box.Weight) + PALLET_WEIGHT;

        public override int Volume => Boxes.Sum(box => box.Volume) + Width * Height * Depth;

        public override DateOnly? ExpirationDate => Boxes.Count > 0 ? Boxes.Min(box => box.ExpirationDate) : null;
    }
}
