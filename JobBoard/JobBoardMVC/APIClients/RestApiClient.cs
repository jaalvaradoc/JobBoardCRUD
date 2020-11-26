using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobBoardMVC.APIClients
{
    public class RestApiClient<T> : IRestApiClient<T>
    {
        public string ResourceName { get; set; }
        private readonly string BaseUrl;

        public RestApiClient(string resourceName)
        {
            ResourceName = resourceName;
            BaseUrl = System.Configuration.ConfigurationManager.AppSettings["ApisBaseUrl"]??"".ToString();
        }

        public T Delete(long id)
        {
            T data = default(T);
            RestClient client = new RestClient(BaseUrl+ResourceName+"/{id}");
            RestRequest request = new RestRequest(Method.DELETE);
            request.AddUrlSegment("id",id);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse<T> response = client.Execute<T>(request);
            data = response.Data;
            return data;
        }

        public List<T> Get()
        {
            List<T> data = new List<T>();
            RestClient client = new RestClient(BaseUrl + ResourceName);
            RestRequest request = new RestRequest(Method.GET);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse<List<T>> response = client.Execute<List<T>>(request);
            if (response.IsSuccessful)
            {
                data = response.Data;
            }
            return data;
        }

        public T Get(long id)
        {
            T data = default(T);
            RestClient client = new RestClient(BaseUrl + ResourceName + "/{id}");
            RestRequest request = new RestRequest(Method.GET);
            request.AddUrlSegment("id", id);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse<T> response = client.Execute<T>(request);
            data = response.Data;
            return data;
        }

        public T Post(T value)
        {
            T data = default(T);
            RestClient client = new RestClient(BaseUrl + ResourceName);
            RestRequest request = new RestRequest(Method.POST);
            request.AddJsonBody(value);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse<T> response = client.Execute<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.Created)
            {
                data = response.Data;
            }
            return data;
        }

        public bool Put(T value, long id)
        {
            bool data = false;
            RestClient client = new RestClient(BaseUrl + ResourceName+"/{id}");
            RestRequest request = new RestRequest(Method.PUT);
            request.AddUrlSegment("id",id);
            request.AddJsonBody(value);
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };
            IRestResponse<T> response = client.Execute<T>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                data = true;
            }
            return data;
        }
    }
}