using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthMicroservice.Model
{
    public class ApplicationForm
    {
        [Key]
        public int Id { get; set; }
        public string SurName { get; set; }
        public string GivenName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        //if applicable
        public string GaurdianName { get; set; }
        public string GaurdainPhoneNumber { get; set; }
        public bool isAcknowledgedByGuardian { get; set; }

        public bool isFirstTime {get;set;} 

        public string decribeEmotions { get; set; }
        public string traumaticEvents { get; set; }

        public bool isOnDrugs { get; set; }
        public string drugsUsed { get; set; }

        public string Status { get; set; }
        public DateTime ReviewedDate { get; set; }
        public string ReviewedBy { get; set; }


        public Consultant AssignedConsultant { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
