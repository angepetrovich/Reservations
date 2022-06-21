using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Reservations.Models;

[Table("Bilets")]
public class BiletModel
{
    [Key]
    public int BiletId { get; set; }
    public int EventId { get; set; }
    [DisplayName("Nazwa wydarzenia")]
    [Required(ErrorMessage = "Pole Nazwa wydarzenia jest wymagane.")]
    [MaxLength(50)]
    public string NameBilet { get; set; }
    [DisplayName("Miejsce")]
    [MaxLength(50)]
    public string DescriptionBilet { get; set; }

    [DisplayName("Szczegłówy wydarzenia")]
    [MaxLength(2000)]
    public string Description { get; set; }

    [DisplayName("Ilość miejsc")] 
    public int NumberOfSeats { get; set; }

    [DisplayName("Imie i Nazwisko")]
    [MaxLength(500)]
    public string Personality { get; set; }
    
    [DisplayName("Adres email")]
    [MaxLength(60)]
    public string Email { get; set; }
    
    [DisplayName("Numer telefonu")]
    [MaxLength(20)]
    public string Number { get; set; }
    
    
}