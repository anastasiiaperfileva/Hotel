using System.ComponentModel.DataAnnotations.Schema;
using Hotel.DataAccess.Primitives;
namespace Hotel.DataAccess.Entities;

[Table("Rooms")]
public class RoomEntity: BaseEntity
{
    public int HotelId { get; set; }
    public HotelEntity Hotel { get; set; }
    
    public int TypeOfRoomId { get; set; }
    public TypeOfRoomEntity TypeOfRoom { get; set; }
    
    public string Number { get; set; }
    
    public RoomStatus Status { get; set; }
    
    public virtual ICollection<RoomImageEntity> RoomImages { get; set; }
}