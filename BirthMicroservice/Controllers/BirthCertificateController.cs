using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BirthMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BirthMicroservice.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BirthCertificateController : ControllerBase
    {
        // GET: /<controller>/
        private readonly ILogger<BirthCertificateController> _logger;
        private BirthCertificateContext _context;

        public BirthCertificateController(ILogger<BirthCertificateController> logger)
        {
            _logger = logger;

            var options = new DbContextOptionsBuilder<BirthCertificateContext>()
                   .UseInMemoryDatabase(databaseName: "BirthDB")
                   .Options;

            _context = new BirthCertificateContext(options);
        }

        /// <summary>
        /// Creates a BirthCertificate.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /BirthCertificate
        ///  {
        ///      "surName": "doe",
        ///      "lastName": "john",
        ///      "birthDate": "2021-10-04T05:52:36.281Z",
        ///      "birthPlace": "St Hills Road, NSW, Australia",
        ///      "sex": "male",
        ///      "fatherGivenName": "james",
        ///      "fatherSurname": "doe",
        ///      "fatherBirthDate": "1993-01-01T05:52:36.281Z",
        ///      "motherGivenName": "Jill",
        ///      "motherSurname": "doe",
        ///      "motherBirthDate": "1995-12-04T05:52:36.281Z",
        ///      "informantName": "Jill",
        ///      "informantDescription": "mother",
        ///      "submittedDate": "2021-10-04T16:52:39.892159+11:00"
        ///}
        /// </remarks>

        [HttpPost]
        public Response Post(BirthCertificate form)
        {


            form.Status = "Pending";
            form.SubmittedDate = DateTime.Now;
            form.IssuedDate = DateTime.MinValue;
            form.IssuedBy = "";
            _context.Add(form);
            _context.SaveChanges();
            return new Response() { Success = true };
        }

        [HttpPut]
        [Route("{id}/withdraw")]
        public Response Withdraw(string id)
        {
            var cert = _context.BirthCertificates.Single(x => x.Id.ToString() == id);
            if(cert != null)
            {
                cert.Status = "Withdrawn";
                _context.Update(cert);
                _context.SaveChanges();
                return new Response() { Success = true };
            }
            return new Response() { Success = false };
        }

        [HttpPut]
        [Route("{id}/issue")]
        public Response Issue(string id)
        {

            var cert = _context.BirthCertificates.Single(x => x.Id.ToString() == id);
            if (cert != null)
            {
                cert.Status = "Issued";
                cert.IssuedDate = DateTime.Now;
                cert.IssuedBy = "Admin";
                _context.Update(cert);
                _context.SaveChanges();
                return new Response() { Success = true };
            }
            return new Response() { Success = false };
        }

        [HttpGet]
        public IEnumerable<BirthCertificate> Get()
        {

            return _context.BirthCertificates.ToArray();
        }
    }
}
