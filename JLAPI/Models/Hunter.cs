using JLAPI.Models.Base;

namespace JLAPI.ModelsModels
{
    public class Hunter : EntityBase
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}