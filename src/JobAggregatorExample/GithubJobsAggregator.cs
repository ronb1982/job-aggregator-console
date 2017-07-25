using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JobAggregatorExample
{
    public class GithubJobsAggregator
    {
        private static string _apiKey = "";
        private static string _baseUri = "https://jobs.github.com/positions.json?";
        private static string _queryParams = "";
        //static HttpClient _client = new HttpClient();

        public List<GitHubJobPosting> GetJobs(string[] queryParams)
        {
            return GetJobsAsync(queryParams).Result;
        }

        public static async Task<List<GitHubJobPosting>> GetJobsAsync(string[] queryParams)
        {
            List<GitHubJobPosting> jobs = new List<GitHubJobPosting>();

            if (queryParams != null && queryParams.Length > 0)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        string fullPath = String.Empty;
                        client.BaseAddress = new Uri(_baseUri);
                        fullPath = client.BaseAddress + string.Format("search={0}&location={1}", queryParams[0], queryParams[1]);
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                        using (HttpResponseMessage response = await client.GetAsync(_baseUri))
                        using (HttpContent content = response.Content)
                        {
                            string result = await content.ReadAsStringAsync();

                            if (!String.IsNullOrEmpty(result))
                            {    
                                jobs = JsonConvert.DeserializeObject<List<GitHubJobPosting>>(result);
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }

            return jobs;
        }
    }
}
