using APIs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace APIs.Repositories
{
    public class JobsRepository : IRepository<Job>
    {
        private JobBoardContext db = new JobBoardContext();
        public Job Delete(long id)
        {
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return null;
            }

            db.Jobs.Remove(job);
            db.SaveChanges();
            return job;
        }

        public IQueryable<Job> Get()
        {
            return db.Jobs;
        }

        public Job Get(long id)
        {
            Job job = db.Jobs.Find(id);
            return job; 
        }

        public Job Post(Job job)
        {
            job.CreatedAt = DateTime.Now;
            db.Jobs.Add(job);
            db.SaveChanges();
            return job;
        }

        public bool Put(Job job, long id)
        {
            db.Entry(job).State = EntityState.Modified;
            db.Entry(job).Property("CreatedAt").IsModified = false;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JobExists(id))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }
            return true;
        }
        

        private bool JobExists(long id)
        {
            return db.Jobs.Count(e => e.Id == id) > 0;
        }

    }
}