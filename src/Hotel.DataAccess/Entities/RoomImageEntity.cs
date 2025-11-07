using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("RoomImages")] 
public class RoomImageEntity: BaseEntity
{
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    
    public int RoomId { get; set; }
    public RoomEntity Room { get; set; }
}