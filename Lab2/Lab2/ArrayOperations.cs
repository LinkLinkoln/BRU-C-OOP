
namespace Lab2
{
    public class ArrayOperations
    {
        private double[] _array;

        public ArrayOperations(int n, double minValue, double maxValue)
        {
            _array = new double[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                _array[i] = random.NextDouble() * (maxValue - minValue) + minValue;
            }
        }

        public ArrayOperations(int n) : this(n, -4.5, 4.5)
        {

        }

        public double SumPositiveElements()
        {
            double sum = 0;
            foreach (double element in _array)
            {
                if (element > 0)
                {
                    sum += element;
                }
            }
            return sum;
        }
        public double ProductBetweenMinMax()
        {
            double min = double.MaxValue, max = double.MinValue;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] < min)
                {
                    min = _array[i];
                }
                else if (_array[i] > max)
                {
                    max = _array[i];
                }
            }

            double product = 1;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] > min && _array[i] < max)
                {
                    product *= _array[i];
                }
            }
            return product;
        }
        public double MaxElement => _array.Max();
    }
}
