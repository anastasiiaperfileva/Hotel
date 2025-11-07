using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.DataAccess.Entities;

[Table("Hotel")]
public class HotelEntity: BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public double Rating { get; set; }

    
    public virtual ICollection<ReviewEntity> Reviews { get; set; }
    public virtual ICollection<AnnouncementEntity> Announcements { get; set; }
    public virtual ICollection<RoomEntity> Rooms { get; set; }
}