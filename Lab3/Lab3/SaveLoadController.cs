using System.IO;
using System;
using System.Collections.Generic;

namespace Lab3
{
    public class SaveLoadController
    {
        const string countryText = "Страна производитель: ";
        const string companyText = "Навзание компании: ";
        const string carModelText = "Модель автомобиля: ";
        const string carPriceText = "Цена автомобиля: ";
        const string carYearText = "Год выпуска: ";

        public void SaveInformation(Country[] countries)
        {
            string filePath = "output.txt";
            StreamWriter writer = new StreamWriter(filePath);

            foreach (Country country in countries)
            {
                writer.WriteLine("-----------------------------------------------");
                writer.WriteLine(countryText + country.CountryName);

                CarCompany[] companies = country.Companies;
                for (int i = 0; i < companies.Length; i++)
                {
                    writer.WriteLine(companyText + companies[i].CompanyName + "\n");
                    Car[] cars = companies[i].Cars;
                    for (int j = 0; j < cars.Length; j++)
                    {
                        writer.WriteLine(carModelText + cars[j].CarModel);
                        writer.WriteLine(carPriceText + cars[j].Price);
                        writer.WriteLine(carYearText + cars[j].Year);
                    }
                }
            }
            Console.WriteLine("Файл сохранен: " + filePath);
            writer.Close();
        }

        public Country[] LoadInformation() 
        {
            string filePath = "output.txt";
            if (File.Exists(filePath) == false)
            {
                return new Country[0];
            }
            string[] lines = File.ReadAllLines(filePath);
            return checkTrimmedLine(lines).ToArray();
        }

        private List<Country> checkTrimmedLine(string[] lines)
        {
            List<Country> countries = new List<Country>();
            Country currentCountry = null;
            CarCompany currentCompany = null;
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith(countryText))
                {
                    string countryName = trimmedLine.Split(':')[1].Trim();
                    currentCountry = new Country(countryName);
                    countries.Add(currentCountry);
                }
                else if (trimmedLine.StartsWith(companyText))
                {
                    string companyName = trimmedLine.Split(':')[1].Trim();
                    currentCompany = new CarCompany(companyName);
                    currentCountry.AddCompany(currentCompany);
                }
                else if (trimmedLine.StartsWith(carModelText))
                {
                    string carModel = trimmedLine.Split(':')[1].Trim();
                    int price = int.Parse(lines[Array.IndexOf(lines, line) + 1].Split(':')[1].Trim());
                    short year = short.Parse(lines[Array.IndexOf(lines, line) + 2].Split(':')[1].Trim());
                    Car car = new Car(carModel, price, year);
                    currentCompany.AddCar(car);
                }
            }
            return countries;
        }
    }
}
