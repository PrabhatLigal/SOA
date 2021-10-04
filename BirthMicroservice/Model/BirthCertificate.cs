using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirthMicroservice.Model
{
    public class BirthCertificate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public string SurName { get; set; }
        public string GivenName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string Sex { get; set; }

        public string FatherGivenName { get; set; }
        public string FatherSurname { get; set; }
        public DateTime FatherBirthDate { get; set; }

        public string MotherGivenName { get; set; }
        public string MotherSurname { get; set; }
        public DateTime MotherBirthDate { get; set; }

        public string InformantName { get; set; }
        public string InformantDescription { get; set; }
        public DateTime SubmittedDate { get; set; }

        public string Status { get; set; }
        public DateTime IssuedDate { get; set; }
        public string IssuedBy { get; set; }

    }
}
