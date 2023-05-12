using System.ComponentModel.DataAnnotations;

namespace AircraftDataApp.Models
{
    public class AircraftType
    {
        [Key]
        public int IdAircraftType { get; set; }

        [Display(Name = "Aircraft Type Name")]
        public string TypeName { get; set; }

        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Max Weight [Kg]")]
        public int MaxWeight { get; set; }

        [Display(Name = "Range [Miles]")]
        public int Range { get; set; }


        [Display(Name = "Aircraft Config")]
        public string FullType
        {
            get
            {
                return Manufacturer + " " + TypeName;
            }
        }

        public ICollection<Aircraft>? Aircrafts { get; set; }
    }
}
