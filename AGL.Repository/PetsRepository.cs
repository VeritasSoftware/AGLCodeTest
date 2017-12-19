using AGL.Entities;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AGL.Repository
{
    /// <summary>
    /// Class PetsRepository
    /// </summary>
    public class PetsRepository : IPetsRepository
    {
        public string Url { get; set; }        

        public async Task<Person[]> GetPersonAndPets()
        {
            if (string.IsNullOrEmpty(this.Url))
            {
                throw new ArgumentNullException(nameof(this.Url));
            }

            using (HttpClient client = new HttpClient())
            {
                return await client.GetAsync(this.Url)
                                   .ContinueWith(task =>
                                                 {
                                                    // Get HTTP response from completed task. 
                                                    HttpResponseMessage response = task.Result;

                                                    // Check that response was successful or throw exception 
                                                    response.EnsureSuccessStatusCode();

                                                    //Read the content
                                                    HttpContent content = response.Content;

                                                    //Deserialize the data
                                                    var result = content.ReadAsStringAsync().Result?.DeserializeArray<Person>();

                                                    return result;
                                                 });
            }                
        }
    }
}
