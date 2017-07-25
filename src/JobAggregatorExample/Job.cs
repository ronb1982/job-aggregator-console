using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAggregatorExample
{
    public class Job
    {
        public GitHubJobPosting GithubJobPosting { get; set; }
    }

    public class GitHubJobPosting
    {
        public string Id { get; set; }
        public string Created_At { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string How_To_Apply { get; set; }
        public string Company { get; set; }
        public string Company_Url { get; set; }
        public string Company_Logo { get; set; }
        public string Url { get; set; }
    }
}
