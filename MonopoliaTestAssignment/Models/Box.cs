namespace MonopoliaTestAssignment.Models
{
    internal sealed class Box : WarehouseItem
    {
        public int Weight { get; set; }

        public DateOnly Date { get; set; }
        public bool IsExpirationDate { get; set; }

        public int PalletId { get; set; }
        public Pallet? Pallet { get; set; }

        public override int Volume => Width * Height * Depth;
        public override DateOnly ExpirationDate => IsExpirationDate ? Date : Date.AddDays(100);
    }
}
