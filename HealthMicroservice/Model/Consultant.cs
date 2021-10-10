using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMicroservice.Model
{
    public class Consultant
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }


        public string Qualification { get; set; }
        public string Role { get; set; }
        public string Institution { get; set; }

        public int? ApplicationFormId { get; set; } // Foreign key
        [ForeignKey("ApplicationFormId")]
        public ApplicationForm ApplicationForm { get; set; } // Reference navigation
    }
}
