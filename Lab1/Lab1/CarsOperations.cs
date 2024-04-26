using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;

namespace Lab1
{
    public class CarsOperations
    {

        public Car AddNewCar(int CarsCount)
        {
            Console.WriteLine("Введите название автомобиля");
            string carName = Console.ReadLine();
            Car car = new Car()
            {
                carName = carName,
                carType = ChooseOptionFromEnum<CarType>("Выберите тип автомобиля"),
                movementType = ChooseOptionFromEnum<MovementType>("Выберите коробку передач"),
                carPrice = ReadIntInput("Введите цену автомобиля"),
                releaseYear = ReadIntInput("Введите год выпуска автомобиля"),
                mileage = ReadIntInput("Введите пробег автомобиля"),
                carIndex = CarsCount,
            };
            return car;
        }

        private int ReadIntInput(string prompt)
        {
            int result;
            Console.WriteLine(prompt);
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
                }
            }
            return result;
        }

        private string ChooseOptionFromEnum<T>(string prompt)
        {
            string[] enumOptions = Enum.GetNames(typeof(T));
            for (int i = 0; i < enumOptions.Length; i++)
            {
                Console.WriteLine($"{enumOptions[i]} - {i + 1}");
            }

            int index = ReadIntInput(prompt + "\nВведите номер типа") - 1;
            return enumOptions[index];
        }

        public void DisplayAllCars(MyList<Car> cars)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-15} {5,-15} {6, -15}",
                "Car Name", "Price", "Year", "Mileage", "Car Type", "Movement Type", "CarIndex");
            Console.WriteLine("---------------------------------------------------------------------------------");

            foreach (Car car in cars)
            {
                Console.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-15} {5,-15} {6, -15}",
                car.carName, car.carPrice, car.releaseYear, car.mileage, car.carType, car.movementType, car.carIndex);
            }
        }
        public MyList<Car> DeleteCarByNumber(MyList<Car> cars)
        {
            int index = ReadIntInput("Введите id машины для удаления") - 1;
            Car targetCar = cars.Get(index);
            return cars;
        }

        public MyList<Car> EditCarByNumber(MyList<Car> cars)
        {
            int index = ReadIntInput("Введите id машины для редактирования") - 1;
            Car targetCar = cars.Get(index);
            Console.WriteLine("Что будем редактировать?" + "\n" + "1: Название" + "\n" + "2: Цену" + 
                "\n" + "3: Год выпуска" + "\n" + "4: Пробег" + "\n" + "5: Тип авто" + "\n" + "6: Коробка передач");
            string Choise = Console.ReadLine();

            switch (Choise)
            {
                case "1":
                    Console.WriteLine($"Введите название автомобиля, текущее {targetCar.carName}");
                    targetCar.carName = Console.ReadLine();
                    break;
                case "2":
                    targetCar.carPrice = ReadIntInput($"Введите цену автомобиля, текущая {targetCar.carPrice}");
                    break;
                case "3":
                    targetCar.releaseYear = ReadIntInput($"Введите год выпуска автомобиля, текущий {targetCar.releaseYear}");
                    break;
                    
                case "4":
                    targetCar.mileage  = ReadIntInput($"Введите пробег автомобиля, текущий {targetCar.mileage}");
                    break;

                case "5":
                    targetCar.carType =  ChooseOptionFromEnum<CarType>($"Выберите тип автомобиля, текущий {targetCar.carType}");
                    break;

                case "6":
                    targetCar.movementType = ChooseOptionFromEnum<MovementType>($"Выберите коробку передач, текущая {targetCar.movementType}");
                    break;
            }
            cars.Set(index, targetCar);
            return cars;
        }


        public MyList<Car> SortByTypes(MyList<Car> cars)
        {
            Console.WriteLine("Выберите тип сортировки:" + "\n" + "1: По названию" + "\n" + "2: По цене" +
                    "\n" + "3: По году выпуска" + "\n" + "4: По пробегу" + "\n" + "5: По типу авто" + "\n" + "6: По коробке передач");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    cars.Sort((car1, car2) => car1.carName.CompareTo(car2.carName));
                    break;
                case "2":
                    cars.Sort((car1, car2) => car1.carPrice.CompareTo(car2.carPrice));
                    break;
                case "3":
                    cars.Sort((car1, car2) => car1.releaseYear.CompareTo(car2.releaseYear));
                    break;
                case "4":
                    cars.Sort((car1, car2) => car1.mileage.CompareTo(car2.mileage));
                    break;
                case "5":
                    cars.Sort((car1, car2) => car1.carType.CompareTo(car2.carType));
                    break;
                case "6":
                    cars.Sort((car1, car2) => car1.movementType.CompareTo(car2.movementType));
                    break;
            }

            return cars;
        }

        public MyList<Car> SearchCarsByFields(MyList<Car> cars)
        {
            Console.WriteLine("Выберите поля для поиска:");
            Console.WriteLine("1: Название");
            Console.WriteLine("2: Цена");
            Console.WriteLine("3: Год выпуска");
            Console.WriteLine("4: Пробег");
            Console.WriteLine("5: Тип авто");
            Console.WriteLine("6: Коробка передач");

            string input = Console.ReadLine();
            string[] searchFields = input.Split(',');

            MyList<Car> searchResults = new MyList<Car>();
            searchResults = cars;

            foreach (string field in searchFields)
            {
                switch (field)
                {
                    case "1":
                        Console.WriteLine("Введите название автомобиля для поиска:");
                        string nameInput = Console.ReadLine();
                        searchResults = searchResults.FindAll(car => car.carName.ToLower().Contains(nameInput.ToLower()));
                        break;
                    case "2":
                        Console.WriteLine("Введите минимальную цену автомобиля для поиска:");
                        int minPrice = ReadIntInput("Минимальная цена:");
                        Console.WriteLine("Введите максимальную цену автомобиля для поиска:");
                        int maxPrice = ReadIntInput("Максимальная цена:");
                        searchResults = searchResults.FindAll(car => car.carPrice >= minPrice && car.carPrice <= maxPrice);
                        break;
                    case "3":
                        Console.WriteLine("Введите минимальный год выпуска автомобиля для поиска:");
                        int minYear = ReadIntInput("Минимальный год выпуска:");
                        Console.WriteLine("Введите максимальный год выпуска автомобиля для поиска:");
                        int maxYear = ReadIntInput("Максимальный год выпуска:");
                        searchResults = searchResults.FindAll(car => car.releaseYear >= minYear && car.releaseYear <= maxYear);
                        break;
                    case "4":
                        Console.WriteLine("Введите минимальный пробег автомобиля для поиска:");
                        int minMileage = ReadIntInput("Минимальный пробег:");
                        Console.WriteLine("Введите максимальный пробег автомобиля для поиска:");
                        int maxMileage = ReadIntInput("Максимальный пробег:");
                        searchResults = searchResults.FindAll(car => car.mileage >= minMileage && car.mileage <= maxMileage);
                        break;
                    case "5":
                        string carType = ChooseOptionFromEnum<CarType>("Выберите тип автомобиля для поиска:");
                        searchResults = searchResults.FindAll(car => car.carType == carType);
                        break;
                    case "6":
                        string movementType = ChooseOptionFromEnum<MovementType>("Выберите коробку передач для поиска:");
                        searchResults = searchResults.FindAll(car => car.movementType == movementType);
                        break;
                    default:
                        Console.WriteLine($"Некорректный выбор поля: {field}");
                        break;
                }
            }

            return searchResults;
        }
    }

}