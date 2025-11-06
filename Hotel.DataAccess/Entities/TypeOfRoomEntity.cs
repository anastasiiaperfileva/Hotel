using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("TypesOfRooms")]
public class TypeOfRoomEntity: BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int MaxGuests { get; set; }
    public decimal PricePerDay { get; set; }
    public int RoomsCount { get; set; }
    public double Area { get; set; }
    public bool AvailabilityBalcony { get; set; }
    public string Amenities { get; set; }
    
    public int TypeOfRoomsStatusId { get; set; }
    public TypeOfRoomStatusEntity TypeOfRoomStatus { get; set; }
    
    public virtual ICollection<BookingEntity> Bookings { get; set; }
    public virtual ICollection<RoomEntity> Rooms { get; set; }
}