using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobAggregatorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            string strFormattedListings = String.Empty;
            GithubJobsAggregator ga = new GithubJobsAggregator();

            Console.Write("What job do you want to search for?  ");
            string position = Console.ReadLine();

            Console.Write("Where?   ");
            string location = Console.ReadLine();

            List<GitHubJobPosting> githubPostings = ga.GetJobs(new string[] { position, location });

            Console.WriteLine("Searching for jobs...\n");

            Console.WriteLine(string.Format("{0} job listings were found on Github.", githubPostings.Count()));
            Console.WriteLine("\nJob Listings\n======================");

            int maxListingsPerPage = 3;

            for (int i = 0; i < githubPostings.Count(); i++)
            {
                GitHubJobPosting job = githubPostings[i];

                if (i > 0 && i % maxListingsPerPage == 0)
                {
                    //Console.WriteLine("\nPAGE {0} OF {1}\n", i + 1, (githubPostings.Count() / maxListingsPerPage));
                    Console.WriteLine("Press any key to continue to next page.");
                    Console.ReadLine();
                    Console.Clear();
                }

                strFormattedListings = string.Format("Listing #{0}\n\n", i + 1);
                strFormattedListings += string.Format("Listing ID: {0}", job.Id);
                strFormattedListings += string.Format("\nCreated At: {0}", job.Created_At);
                strFormattedListings += string.Format("\nTitle: {0}", job.Title);
                strFormattedListings += string.Format("\nLocation: {0}", job.Location);
                strFormattedListings += string.Format("\nType: {0}", job.Type);
                strFormattedListings += string.Format("\nDescription:\n{0}", job.Description);
                strFormattedListings += string.Format("\nHow to apply:\n{0}", job.How_To_Apply);
                strFormattedListings += string.Format("\nCompany: {0}", job.Company);
                strFormattedListings += string.Format("\nCompany_Url: {0}", job.Company_Url);
                strFormattedListings += string.Format("\nCompany_Logo: {0}", job.Company_Logo);
                strFormattedListings += string.Format("\nURL: {0}\n\n===============================\n\n", job.Url);

                Console.Write(strFormattedListings);

                
            }

            Console.ReadLine();
        }
    }
}
