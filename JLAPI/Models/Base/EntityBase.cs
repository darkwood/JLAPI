using System;

namespace JLAPI.Models.Base
{
    public class EntityBase
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
    }
}