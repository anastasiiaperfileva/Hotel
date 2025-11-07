using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.DataAccess.Entities;

[Table("RoomsStatuses")] 
public class RoomStatusEntity: BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<TypeOfRoomEntity> TypeOfRooms { get; set; }
    public virtual ICollection<RoomEntity> Rooms { get; set; }
}