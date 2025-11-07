using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.DataAccess.Entities;

[Table("Rooms")]
public class RoomEntity: BaseEntity
{
    public int HotelId { get; set; }
    public HotelEntity Hotel { get; set; }
    
    public int TypeOfRoomId { get; set; }
    public TypeOfRoomEntity TypeOfRoom { get; set; }
    
    public string Number { get; set; }
    
    public int RoomStatusId { get; set; }
    public RoomStatusEntity RoomStatus { get; set; }
    
    public virtual ICollection<RoomImageEntity> RoomImages { get; set; }
}