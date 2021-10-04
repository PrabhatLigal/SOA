using System;
using BirthMicroservice.Model;
using Microsoft.EntityFrameworkCore;

namespace BirthMicroservice
{
    public class BirthCertificateContext : DbContext
    {
        public BirthCertificateContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BirthCertificate> BirthCertificates { get; set; }
    }
}
