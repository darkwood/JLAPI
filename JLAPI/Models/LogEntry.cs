using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using JLAPI.Models.Base;

namespace JLAPI.Models
{

    public class LogEntry : EntityBase
    {
        public int Hits { get; set; }
        public int Shots { get; set; }
        public int Observed { get; set; }
        public int HuntId { get; set; }
        public int SpeciesId { get; set; }
        public int HunterId { get; set; }
        public int Dogid { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Notes { get; set; }
        public string DynamicData { get; set; }
    }
}