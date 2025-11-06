using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("Booking")]
public class BookingEntity:BaseEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int GuestsCount { get; set; }
    public decimal TotalPrice { get; set; }
    public string SpecialRequests { get; set; }
    
    public int BookingStatusId { get; set; }
    public BookingStatusEntity BookingStatus { get; set; }
    
    public int TypeOfRoomId { get; set; }
    public TypeOfRoomEntity TypeOfRoom { get; set; }
}