using JLAPI.Models.Base;

namespace JLAPI.Models
{
    public class Species : EntityBase
    {
        public string Name { get; set; }
        public string WikiName { get; set; }
        public int  SpeciesGroupId { get; set; }
    }
}