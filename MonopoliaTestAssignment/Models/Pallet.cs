namespace MonopoliaTestAssignment.Models
{
    internal sealed class Pallet : WarehouseItem
    {
        internal static readonly int PALLET_WEIGHT = 30;

        public List<Box> Boxes { get; set; } = [];

        public int Weight => Boxes.Sum(box => box.Weight) + PALLET_WEIGHT;
 
        public override int Volume => Boxes.Sum(box => box.Volume) + Width * Height * Depth;
        public override DateOnly ExpirationDate => Boxes.Select(box => box.ExpirationDate).Min();
    }
}
