using System;

namespace Lab3
{
    public class CarCompany
    {
        private Car[] _cars;
        private string _companyName;

        public Car[] Cars => _cars;
        public string CompanyName => _companyName;

        public CarCompany(string _companyName)
        {
            _cars = new Car[0];
            this._companyName = _companyName;
        }

        public void AddCar(Car car)
        {
            Array.Resize(ref _cars, _cars.Length + 1);
            _cars[_cars.Length - 1] = car;
        }
    }
}
