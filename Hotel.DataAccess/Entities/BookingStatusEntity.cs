using System.ComponentModel.DataAnnotations.Schema;
namespace Hotel.DataAccess.Entities;

[Table("BookingStatuses")]
public class BookingStatusEntity: BaseEntity
{
    public string Name { get; set; }
    public virtual ICollection<BookingEntity> Bookings { get; set; }
}