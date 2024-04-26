
using System;

namespace Lab3
{
    public class Car
    {
        private string _carModel;
        private int _price;
        private short _year;

        public string CarModel => _carModel;
        public int Price => _price;
        public short Year => _year;

        public Car(string _carModel, int _price, short _year) 
        {
            this._carModel = _carModel;
            this._price = _price;
            this._year = _year;
        }


    }
}
