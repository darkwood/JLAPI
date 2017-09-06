using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JLAPI.Models.Base;

namespace JLAPI.Models
{

    public class Hunt : EntityBase
    {
        public string Location { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public virtual List<int> HunterIds { get; set; }
        public virtual List<int> DogIds { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Notes { get; set; }
    }
}