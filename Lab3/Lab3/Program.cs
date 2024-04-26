using System;

namespace Lab3
{
    public class Program
    {
        static void Main(string[] args)
        {
            SaveLoadController saveLoadController = new SaveLoadController();
            Country[] countries = saveLoadController.LoadInformation();

            SwitchOperations switchOperations = new SwitchOperations();

            for (int i = 0; ;)
            {
                string inputKey = Operations.EnterInfo<string>("1: Добавить новое авто" + "\n" + "2: Добавить новую компанию" +
                    "\n" + "3: Добавить новую страну" + "\n" + "4: Сохранить данные" + "\n" +  "5: Поиск по двум параметрам");
                switch (inputKey)
                {
                    case "1":
                        countries = switchOperations.AddNewCar(countries);
                        break;
                        
                    case "2":
                        countries = switchOperations.AddNewCompany(countries);
                        break;

                    case "3":
                        countries = switchOperations.AddNewCountry(countries);
                        break;

                    case "4":
                        saveLoadController.SaveInformation(countries);
                        break;
                    case "5":
                        switchOperations.FindCarsByTwoParametrs(countries);
                        break;
                }
                Console.Clear();
            }
        }
    }
}
