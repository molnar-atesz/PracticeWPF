using CovidStat.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CovidStat.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
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
                OnPropertyChanged();
            }
        }

        public List<CountryStat> CountryList
        {
            get => countryList;
            set
            {
                countryList = value;
                OnPropertyChanged();
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

        public async Task Refresh()
        {
           var service = new CovidDataService();
            CountryList = await service.LoadCountries();
        }
    }
}
