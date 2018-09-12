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
            customerlist.Select(i => i.CompanyName).ToList().ForEach(i => companyListKeyword.AddRange(i.Split()));
            //Remove Unwanted words
            companyListKeyword.RemoveAll(item => commonWords.Contains(item));
            //Removing words with length lesser then 3
            companyListKeyword.RemoveAll(item => item.Length <= 2);
            IDictionary<string, int> lstDictionary = companyListKeyword.Distinct()
                    .ToDictionary(dic => dic, dic => 0);
            List<string> lstCompanyNameKeys = new List<string>(lstDictionary.Keys);
            foreach (string key in lstCompanyNameKeys)
            {
                lstDictionary[key] = companyListKeyword.Count(f => f == key);
            }
            List<int> maxValues = lstDictionary.Values.OrderByDescending(i => i).Take(5).ToList();
            foreach (KeyValuePair<string, int> kvp in lstDictionary)
            {
                if (maxValues.Find(i => i.Equals(kvp.Value)) > 0)
                {
                    lstDataLayout.Add(new DataLayout
                    {
                        Count = kvp.Value,
                        Name = kvp.Key,
                        Customers = customerlist.Where(i => i.CompanyName.Contains(kvp.Key)).ToList()

                    });
                }
            }
            int counter = 1;
            lstDataLayout = lstDataLayout.OrderByDescending(i => i.Count).ThenBy(i => i.Name).Take(5).ToList();
            lstDataLayout.ForEach(i => i.Id = counter++);
            counter = 1;
            lstDataLayout.ToList().ForEach(i => i.Customers.ForEach(d => d.Id = counter++));
            return lstDataLayout;
        }
    }
}
