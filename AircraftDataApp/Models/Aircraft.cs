using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AircraftDataApp.Models
{
    public class Aircraft
    {
        [Key]
        public int IdAircraft { get; set; }

        [Display(Name = "Registration")]
        public string Registration { get; set; }

        [Display(Name = "Aircraft Type")]
        public int FsAircraftType { get; set; }

        [Display(Name = "Airline")]
        public int FsAirline { get; set; }


        [ForeignKey("FsAircraftType")]
        public AircraftType? AircraftType { get; set; }

        [ForeignKey("FsAirline")]
        public Airline? Airline { get; set; }


        public ICollection<Aircraft_Airport>? AircraftAirports { get; set; }
    }
}
