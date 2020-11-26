using JobBoardMVC.APIClients;
using JobBoardMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardMVC.Services
{
    public class JobsService : IRestService<Job>
    {
        private readonly RestApiClient<Job> jobsApiClient = new RestApiClient<Job>("Jobs"); 
        public Job Delete(long id)
        {
            return jobsApiClient.Delete(id);
        }

        public List<Job> Get()
        {
            return jobsApiClient.Get();
        }

        public Job Get(long id)
        {
            return jobsApiClient.Get(id);
        }

        public Job Post(Job value)
        {
            return jobsApiClient.Post(value);
        }

        public bool Put(Job value)
        {
            return jobsApiClient.Put(value,value.Id);
        }
    }
}