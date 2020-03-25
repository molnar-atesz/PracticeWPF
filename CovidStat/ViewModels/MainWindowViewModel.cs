using CovidStat.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidStat.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly string API_URL = @"https://coronavirus-19-api.herokuapp.com/";
        private CountryStat _currentCountry;
        private List<CountryStat> countryList;

        public CountryStat CurrentCountry
        {
            get => _currentCountry;
            set
            {
                _currentCountry = value;
                OnPropertyChanged(nameof(CurrentCountry));
            }
        }

        public List<CountryStat> CountryList
        {
            get => countryList;
            set
            {
                countryList = value;
                OnPropertyChanged(nameof(CountryList));
            }
        }

        public MainWindowViewModel()
        {
            CurrentCountry = new CountryStat();
        }

        internal void SelectCountry(string countryName)
        {
            CurrentCountry = CountryList.Where(stat => stat.Country == countryName).FirstOrDefault();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public async Task LoadCountries()
        {
            var client = new HttpClient();
            string requestUri = $"{API_URL}countries";
            var data = await client.GetAsync(requestUri);
            var stats = await data.Content.ReadAsStringAsync().ConfigureAwait(true);

            CountryList = JsonConvert.DeserializeObject<List<CountryStat>>(stats);
        }
    }
}
