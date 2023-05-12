using System.ComponentModel.DataAnnotations;

namespace AircraftDataApp.Models
{
    public class Airport
    {
        [Key]
        public int IdAirport { get; set; }

        [Display(Name = "Airport Name")]
        public string AirportName { get; set; }

        [StringLength(3)]
        [Display(Name = "IATA Code")]
        public string AirportCodeShort { get; set; }

        [StringLength(4)]
        [Display(Name = "ICAO Code")]
        public string AirportCodeLong { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        [Display(Name = "Country")]
        public string Country { get; set; }


        [Display(Name = "Airport Designator")]
        public string FullAirport
        {
            get
            {
                return AirportCodeShort + " - " + AirportName;
            }
        }

        public ICollection<Aircraft_Airport>? AircraftAirports { get; set; }
    }
}
