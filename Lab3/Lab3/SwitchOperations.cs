using System;
using System.Collections.Generic;

namespace Lab3
{
    public class SwitchOperations
    {
        private int companyIndex;
        private int countryIndex;

        public class PrintResult
        {
            public string carModel { get; private set; }
            public short carYear { get; private set; }
            public int price { get; private set; }
            public string companyName { get; private set; }
            public string countryName { get; private set; }
            public PrintResult(string carModel, short carYear, int price, string companyName, string countryName)
            {
                this.carModel = carModel;
                this.carYear = carYear;
                this.price = price;
                this.companyName = companyName;
                this.countryName = countryName;
            }
            public void printInfo()
            {
                Console.WriteLine($"Модель автомобиля: {carModel} \n" + $"Цена автомобиля {price} \n" + $"Год выпуска {carYear}\n" + $"Компания производитель {companyName} \n" + $"Страна производитель {countryName}");
            }
        }
        
        public Country[] AddNewCar(Country[] countries)
        {
            Console.Clear();
            Car car = new Car(
                Operations.EnterInfo<string>("Введите модель авто"),
                Operations.EnterInfo<int>("Введите цену автомобиля"),
                Operations.EnterInfo<short>("Введите год выпуска автомобиля")
                );
            OutputUndifiedObjectName(countries);
            countryIndex = Operations.EnterInfo<int>("Выберите страну производитель") - 1;

            OutputUndifiedObjectName(countries[countryIndex].Companies);
            companyIndex = Operations.EnterInfo<int>("Выберите компанию производитель") - 1;
            countries[countryIndex].Companies[companyIndex].AddCar(car);
            return countries;
        }

        public Country[] AddNewCompany(Country[] countries)
        {
            Console.Clear();
            
            string companyName = Operations.EnterInfo<string>("Введите имя компании авто");
            
            CarCompany carCompany = new CarCompany(companyName);
            OutputUndifiedObjectName(countries);
            countryIndex = Operations.EnterInfo<int>("Выберите страну производитель") - 1;
            countries[countryIndex].AddCompany(carCompany);

            return countries;
        }

        public Country[] AddNewCountry(Country[] countries)
        {
            Console.Clear();

            string countryName = Operations.EnterInfo<string>("Введите страну производитель");
            
            if (CheckCountryName(countries, countryName) == true)
            {
                Country country = new Country(countryName);
                Array.Resize(ref countries, countries.Length + 1);
                countries[countries.Length - 1] = country;
            }
            return countries;
        }

        private bool CheckCountryName(Country[] countries, string targetName)
        {
            for (int i = 0; i < countries.Length - 1; i++)
            {
                if (targetName == countries[i].CountryName)
                {
                    Console.WriteLine("Страна с таким названием уже существует");
                    Console.ReadKey();
                    return false;
                }
            }
            return true;
        }

        public void FindCarsByTwoParametrs(Country[] countries)
        {
            Console.Clear();
            string carModel = Operations.EnterInfo<string>("Введите модель авто");
            short year = Operations.EnterInfo<short>("Введите год выпуска");
            List<PrintResult> printResult = FindCar(countries, carModel, year);

            foreach (PrintResult printResultItem in printResult)
            {
                if (printResultItem != null)
                {
                    printResultItem.printInfo();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("По данному запросу ничего не найдено");
                }
            }
            Console.ReadKey();
        }

        private void OutputUndifiedObjectName<T>(T[] objects)
        {
            
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is Car car)
                {
                    Console.WriteLine(i + 1 + " " + car.CarModel);
                }
                else if (objects[i] is CarCompany carCompany)
                {
                    Console.WriteLine(i + 1 + " " + carCompany.CompanyName);
                }
                else if (objects[i] is Country country)
                {
                    Console.WriteLine(i + 1 + " " + country.CountryName);
                }
            }
        }
        private List<PrintResult> FindCar(Country[] countries, string carModel, short year)
        {
            List<PrintResult> resultsList = new List<PrintResult>();
            for (int i = 0; i < countries.Length; i++)
            {
                for (int j = 0; j < countries[i].Companies.Length; j++)
                {
                    CarCompany[] carCompany = countries[i].Companies;
                    for (int c = 0; c < carCompany.Length; c++)
                    {
                        Car[] cars = carCompany[c].Cars;
                        if (carModel == cars[c].CarModel && year == cars[c].Year)
                        {
                            PrintResult printResult = new PrintResult(cars[c].CarModel, cars[c].Year, cars[c].Price,
                            carCompany[j].CompanyName, countries[i].CountryName);
                            resultsList.Add(printResult);
                            return resultsList;
                        }
                        else if (carModel == cars[c].CarModel || year == cars[c].Year)
                        {
                            PrintResult printResult = new PrintResult(cars[c].CarModel, cars[c].Year, cars[c].Price, 
                                carCompany[j].CompanyName, countries[i].CountryName );
                            resultsList.Add( printResult);
                        }
                    }
                }
            }
            return resultsList;
        }

    }
}
