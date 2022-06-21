using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Reservations.Models;

[Table("Events")]
public class ReservationModel
{
    [Key]
    public int EventId { get; set; }
    [DisplayName("Nazwa")]
    [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
    [MaxLength(50)]
    public string Name { get; set; }
    [DisplayName("Opis")]
    [MaxLength(2000)]
    public string DescriptionEvent { get; set; }

    // public bool Participation { get; set; }
    
    [DisplayName("Ilosc wolnych miejsc")]
    public int AvailableSeats { get; set; }
}