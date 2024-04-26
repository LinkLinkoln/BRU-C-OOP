using System;

namespace Lab3
{
    public class Country
    {
        private CarCompany[] _companies;
        private string _countryName;

        public CarCompany[] Companies => _companies;
        public string CountryName => _countryName;

        public Country(string _countryName) 
        {
            _companies = new CarCompany[0];
            this._countryName = _countryName;
        }
        public void AddCompany(CarCompany company)
        {
            Array.Resize(ref _companies, _companies.Length + 1);
            _companies[_companies.Length - 1] = company;
        }
    }
}
