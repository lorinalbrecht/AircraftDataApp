using System.ComponentModel.DataAnnotations;

namespace AircraftDataApp.Models
{
    public class Airline
    {
        [Key]
        public int IdAirline { get; set; }

        [Display(Name = "Airline Name")]
        public string AirlineName { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }


        public ICollection<Aircraft>? Aircrafts { get; set; }
    }
}
