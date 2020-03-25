using CovidStat.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidStat
{
    public class CovidDataService
    {
        private readonly string API_URL = @"https://coronavirus-19-api.herokuapp.com/";

        public async Task<List<CountryStat>> LoadCountries()
        {
            var client = new HttpClient();
            string requestUri = $"{API_URL}countries";
            var data = await client.GetAsync(requestUri);
            var stats = await data.Content.ReadAsStringAsync().ConfigureAwait(true);

            return JsonConvert.DeserializeObject<List<CountryStat>>(stats);
        }
    }
}
