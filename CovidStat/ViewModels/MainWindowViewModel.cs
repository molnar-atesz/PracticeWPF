using CovidStat.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CovidStat.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
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
