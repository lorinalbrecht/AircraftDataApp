using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AircraftDataApp.Models
{
    public class Aircraft_Airport
    {
        [Key]
        public int IdAircraftAirport { get; set; }

        [Display(Name = "Aircraft")]
        public int FsAircraft { get; set; }

        [Display(Name = "Airport")]
        public int FsAirport { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime DatePosition { get; set; }


        [ForeignKey("FsAircraft")]
        public Aircraft? Aircraft { get; set; }

        [ForeignKey("FsAirport")]
        public Airport? Airport { get; set; }
    }
}
