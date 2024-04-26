using System;

namespace Lab1
{
    public class Program
    {
        private static MyList<Car> Cars = new MyList<Car>();
        

        private static void WaitingToNextCommand()
        {
            Console.WriteLine("Нажмите любую клавишу, чтобы вернуться в меню");
            Console.ReadKey();
            Console.Clear();
        }
        private static void ChooseOption(CarsOperations operations)
        {
            for (int i = 0; ; i++)
            {
                Console.WriteLine("Выберите действие с товаром");
                Console.WriteLine("1: Сохранить список товаров в документ" + "\n" + "2: Добавить новый товар" +
                    "\n" + "3: Удалить товар по номеру" + "\n" + "4: Редактировать товар по id" + "\n"
                    + "5: Сортировка по типу" + "\n" + "6: Вывести все машины" + "\n" + "7: Поиск по полям");
                switch (Console.ReadLine())
                {
                    case "1":
                        SaveLoadController.SaveFile(Cars);
                        break;

                    case "2":
                        Console.Clear();
                        Cars.Add(operations.AddNewCar(Cars.Count));
                        break;

                    case "3":
                        Cars = operations.DeleteCarByNumber(Cars);
                        SaveLoadController.SaveFile(Cars);
                        Cars = SaveLoadController.LoadFile();
                        break;

                    case "4":
                        Console.Clear();
                        Cars = operations.EditCarByNumber(Cars);
                        break;
                    case "5":
                        Console.Clear();
                        Cars = operations.SortByTypes(Cars);
                        break;

                    case "6":
                        Console.Clear();
                        operations.DisplayAllCars(Cars);
                        break;
                    case "7":
                        Console.Clear();
                        MyList<Car> findedResults =  operations.SearchCarsByFields(Cars);
                        operations.DisplayAllCars(findedResults);
                        break;
                }

                WaitingToNextCommand();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Cars = SaveLoadController.LoadFile();
                CarsOperations operations = new CarsOperations();
                ChooseOption(operations);
            }
            finally
            {
                SaveLoadController.SaveFile(Cars);
            }
        }
    }
}
