using JLAPI.Models.Base;

namespace JLAPI.Models
{
    public class Dog : EntityBase
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string LicenseNumber { get; set; }
    }
}