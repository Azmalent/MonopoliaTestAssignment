using System.ComponentModel.DataAnnotations.Schema;

namespace MonopoliaTestAssignment.Models
{
    public abstract class WarehouseItem
    {
        public int Id { get; set; }
        
        public int Width { get; set; }
        
        public int Height { get; set; }
        
        public int Depth { get; set; }

        [NotMapped] public abstract int Volume { get; }
        
        [NotMapped] public abstract DateOnly? ExpirationDate { get; }
    }
}
