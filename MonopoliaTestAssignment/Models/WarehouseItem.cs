using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonopoliaTestAssignment.Models
{
    public abstract class WarehouseItem
    {
        [Required, Key] public int Id { get; set; }
        
        [Required] public int Width { get; set; }
        
        [Required] public int Height { get; set; }
        
        [Required] public int Depth { get; set; }

        [NotMapped] public abstract int Volume { get; }
        
        [NotMapped] public abstract DateOnly? ExpirationDate { get; }
    }
}
