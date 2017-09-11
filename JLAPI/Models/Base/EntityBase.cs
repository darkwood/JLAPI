using System;
using System.ComponentModel.DataAnnotations;

namespace JLAPI.Models.Base
{
    public class EntityBase
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public DateTime Created { get; set; }
        public DateTime Changed { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
    }
}