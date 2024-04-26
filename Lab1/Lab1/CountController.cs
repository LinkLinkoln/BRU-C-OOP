using System.Collections.Generic;

namespace Lab1
{
    public static class CountController
    {
        private static int Count;
        public static int CarIndex(List<Car> cars)
        {
            foreach (Car car in cars)
            {
                if (Count != car.carIndex)
                {

                }
            }
            Count++;
            return Count;
        }
    }
}
