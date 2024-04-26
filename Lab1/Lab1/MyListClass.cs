using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;
        private int count;

        public MyList()
        {
            items = new T[4];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item)
        {
            if (count == items.Length)
            {
                Array.Resize(ref items, items.Length * 2);
            }

            items[count] = item;
            count++;
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(items, item);
            if (index >= 0)
            {
                Array.Copy(items, index + 1, items, index, count - index - 1);
                count--;
                items[count] = default(T);
                return true;
            }

            return false;
        }

        public void Set(int index, T item)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            items[index] = item;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }

            return items[index];
        }
        public void Sort(Comparison<T> comparison)
        {
            T[] sortedItems = new T[count];
            Array.Copy(items, sortedItems, count);
            Array.Sort(sortedItems, comparison);
            Array.Copy(sortedItems, items, count);
        }

        public MyList<T> FindAll(Predicate<T> match)
        {
            MyList<T> results = new MyList<T>();

            foreach (T item in this)
            {
                if (match(item))
                {
                    results.Add(item);
                }
            }

            return results;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}