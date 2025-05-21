namespace MonopoliaTestAssignment.Models
{
    public abstract class WarehouseItem
    {
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        
        public abstract int Volume { get; }
        public abstract DateOnly? ExpirationDate { get; }
    }
}
