using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab1
{
    public static class SaveLoadController
    {
        public static void SaveFile(MyList<Car> cars)
        {
            string filePath = "output.txt";
            StreamWriter writer = new StreamWriter(filePath);
            writer.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-15} {5,-15} {6,-15}",
            "Car Name", "Price", "Year", "Mileage", "Car Type", "Movement Type", "CarIndex");
            writer.WriteLine("\n");

            foreach (Car car in cars)
            {
                writer.WriteLine("{0,-15} {1,-10} {2,-10} {3,-10} {4,-15} {5,-15} {6,-15}",
                    car.carName + ' ', car.carPrice, car.releaseYear, car.mileage, car.carType, car.movementType, car.carIndex);
            }
            Console.WriteLine("Файл сохранен: " + filePath);
            writer.Close();
        }
        public static MyList<Car> LoadFile()
        {
            string filePath = "output.txt";
            if (File.Exists(filePath))
            {
                MyList<Car> cars = new MyList<Car>();
                StreamReader reader = new StreamReader(filePath);
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        string[] values = Regex.Split(line, @"\s{2,}");
                        if (values.Length != 0)
                        {
                            Car car = new Car
                            {
                                carName = values[0],
                                carPrice = int.Parse(values[1]),
                                releaseYear = int.Parse(values[2]),
                                mileage = int.Parse(values[3]),
                                carType = values[4],
                                movementType = values[5],
                                carIndex = cars.Count + 1,
                            };
                            cars.Add(car);
                        }
                    }
                }
                reader.Close();
                return cars;
            }
            return null;
        }
    }
}
