using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthMicroservice.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthMicroservice.Controllers
{
    public class HealthController : Controller
    {
        private readonly ILogger<HealthController> _logger;
        private DBContext _context;
        private string[]  states = new string[] { "accept", "reject", "withdraw" };

        public HealthController(ILogger<HealthController> logger)
        {
            _logger = logger;

            var options = new DbContextOptionsBuilder<DBContext>()
                   .UseInMemoryDatabase(databaseName: "HealthDB")
                   .Options;

            _context = new DBContext(options);
            _context.Database.EnsureCreated();
        }

      

        [HttpPost]
        [Route("applications")]
        public Response Post(ApplicationForm form)
        {


            form.Status = "Pending";
            //form.SubmittedDate = DateTime.Now;
            //form.IssuedDate = DateTime.MinValue;
            //form.IssuedBy = "";
            _context.Add(form);
            _context.SaveChanges();
            return new Response() { Success = true };
        }

        [HttpPut]
        [Route("applications")]
        [Route("{id}/application/{state}")]
        public Response Withdraw(string id, string state)
        {
           
            if (string.IsNullOrEmpty(state) || !states.Contains(state))
            {
                return new Response() { Success = false ,ErrorMessage="Unpermitted Action" };
            }
            var cert = _context.ApplicationForms.Single(x => x.Id.ToString() == id);
            if (cert != null)
            {
                cert.Status =state;
                _context.Update(cert);
                _context.SaveChanges();
                return new Response() { Success = true };
            }
            return new Response() { Success = false };
        }

        [HttpPost]
        [Route("{id}/book-session")]
        public Response sesssion(int id, Session session)
        {

            var cert = _context.ApplicationForms.Single(x => x.Id == id);
            if (cert != null)
            {

                //TOD) Check conflict
                session.ApplicationFormId = id;
                _context.Add(session);
                _context.SaveChanges();
                return new Response() { Success = true };
            }
            return new Response() { Success = false };
        }

        [HttpPost]
        [Route("{id}/edit-session")]
        public Response Acc(int id, Session session)
        {

            var cert = _context.ApplicationForms.Single(x => x.Id == id);
            if (cert != null)
            {

                //TOD) Check conflict
                session.ApplicationFormId = id;
                _context.Add(session);
                _context.SaveChanges();
                return new Response() { Success = true };
            }
            return new Response() { Success = false };
        }

        [HttpGet]
        [Route("consultants")]
        public IEnumerable<Consultant> Get()
        {

            var x = _context.Consultants.ToArray();
            return x;
        }

        [HttpGet]
        [Route("applications")]
        public IEnumerable<ApplicationForm> GetApplicationForms()
        {

            var x = _context.ApplicationForms.ToArray();
            return x;
        }

        [HttpGet]
        [Route("{id}/sessions")]
        public IEnumerable<Session> GetSessions(int id)
        {

            return _context.Sessions.Where(x => x.ApplicationFormId == x.Id);
        }

    }
}
