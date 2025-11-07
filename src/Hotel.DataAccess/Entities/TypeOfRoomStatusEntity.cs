using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("TypesOfRoomsStatuses")]
public class TypeOfRoomStatusEntity : BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<TypeOfRoomEntity> TypeOfRooms { get; set; }
}