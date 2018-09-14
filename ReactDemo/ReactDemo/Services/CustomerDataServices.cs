using ReactDemo.Services.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReactDemo.Models;
using ReactDemo.Util;
using Microsoft.Extensions.Options;
using ReactDemo.Factory;

namespace ReactDemo.Services
{
    public class CustomerDataServices : ICustomerDataServices
    {

        private readonly IOptions<MySettingsModel> appSettings;
        public CustomerDataServices(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
        }

        public async Task<IEnumerable<Customer>> GetCompaniesAsync()
        {
            var data = await ApiClientFactory.Instance.GetCustomer();
            return data;
        }
        private string[] commonWords = {
            "the",
            "and",
            "that",
            "have",
            "for",
            "not",
            "with",
            "you",
            "this",
            "but",
            "his",
            "from",
            "they",
            "say",
            "her",
            "she",
            "will",
            "one",
            "all",
            "would",
            "there",
            "their",
            "what",
            "out",
            "about",
            "who",
            "get",
            "which",
            "when",
            "make",
            "can",
            "like",
            "time",
            "just",
            "him",
            "know",
            "take",
            "people",
            "into",
            "year",
            "your",
            "good",
            "some",
            "could",
            "them",
            "see",
            "other",
            "than",
            "then",
            "now",
            "look",
            "only",
            "come",
            "its",
            "over",
            "think",
            "also",
            "back",
            "after",
            "use",
            "two",
            "how",
            "our",
            "work",
            "first",
            "well",
            "way",
            "even",
            "new",
            "want",
            "because",
            "any",
            "these",
            "give",
            "day",
            "most",
        };
        public List<DataLayout> ProcessData(IList<Customer> customerlist)
        {
            List<DataLayout> lstDataLayout = new List<DataLayout>();
            List<string> companyListKeyword = new List<string>();
            //Splitting company Names
            customerlist.Select(i => i.CompanyName).ToList().ForEach(i => companyListKeyword.AddRange(i.Split()));

            //Remove Unwanted words
            companyListKeyword.RemoveAll(item => commonWords.Contains(item));

            //Removing words with length lesser then 3
            companyListKeyword.RemoveAll(item => item.Length <= 2);

            //Selecting distinct items
            IDictionary<string, int> lstDictionary = companyListKeyword.Distinct()
                    .ToDictionary(dic => dic, dic => 0);
            
            //Assigning value as count and key as word
            List<string> lstCompanyNameKeys = new List<string>(lstDictionary.Keys);
            foreach (string key in lstCompanyNameKeys)
            {
                lstDictionary[key] = companyListKeyword.Count(f => f == key);
            }

            //Taking only maximum 5 values
            List<int> maxValues = lstDictionary.Values.OrderByDescending(i => i).Take(5).ToList();

            //populating viewmodel
            foreach (KeyValuePair<string, int> kvp in lstDictionary)
            {
                if (maxValues.Find(i => i.Equals(kvp.Value)) > 0)
                {
                    lstDataLayout.Add(new DataLayout
                    {
                        Count = kvp.Value,
                        Name = kvp.Key,
                        Companies = customerlist.Where(i => i.CompanyName.Contains(kvp.Key)).Select(i => i.CompanyName).ToList()

                    });
                }
            }
            int counter = 1;
            //slecting only 5 and ordering by count and then by name
            lstDataLayout = lstDataLayout.OrderByDescending(i => i.Count).ThenBy(i => i.Name).Take(5).ToList();
            lstDataLayout.ForEach(i => i.Id = counter++);
            return lstDataLayout;
        }
    }
}
