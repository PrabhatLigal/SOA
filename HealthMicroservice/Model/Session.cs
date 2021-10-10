using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthMicroservice.Model
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        public int Slot { get; set; }//
        public DateTime AppointmentDate { get; set; }

        public int? ApplicationFormId { get; set; } // Foreign key
        [ForeignKey("ApplicationFormId")]
        public ApplicationForm ApplicationForm { get; set; } // Reference navigation
    }
}
