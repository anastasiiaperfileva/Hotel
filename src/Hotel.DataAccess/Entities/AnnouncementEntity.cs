using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;
using Hotel.DataAccess.Primitives;

[Table("Announcements")]
public class AnnouncementEntity: BaseEntity
{
    public int UserId { get; set; }
    public UserEntity User { get; set; }
    
    public int HotelId { get; set; }
    public HotelEntity Hotel { get; set; }
    
    public string Title { get; set; }
    public string Text { get; set; }
    public DateTime PublishedAt { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    
    public AnnouncementStatus Status { get; set; }
}