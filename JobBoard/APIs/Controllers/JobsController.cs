using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using APIs.Models;
using APIs.Repositories;

namespace APIs.Controllers
{
    public class JobsController : ApiController
    {
        //private JobBoardContext db = new JobBoardContext();

        private readonly JobsRepository jobs = new JobsRepository();

        // GET: api/Jobs
        public IQueryable<Job> GetJobs()
        {
            return jobs.Get();
        }

        // GET: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult GetJob(long id)
        {
            Job job = jobs.Get(id);
            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        // PUT: api/Jobs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutJob(long id, Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != job.Id)
            {
                return BadRequest();
            }


            if (!jobs.Put(job, id))
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Jobs
        [ResponseType(typeof(Job))]
        public IHttpActionResult PostJob(Job job)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var job2 = jobs.Post(job);

            return CreatedAtRoute("DefaultApi", new { id = job.Id }, job2);
        }

        // DELETE: api/Jobs/5
        [ResponseType(typeof(Job))]
        public IHttpActionResult DeleteJob(long id)
        {
            Job job = jobs.Get(id);
            if (job == null)
            {
                return NotFound();
            }
            jobs.Delete(id);

            return Ok(job);
        }
        
        
    }
}