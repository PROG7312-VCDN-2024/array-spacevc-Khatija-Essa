using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_VC
{
    public class CustomArray<T>
    {
        private T[] array;
        private int count;

        public CustomArray(int size = 4)
        {
            array = new T[size];
            count = 0;
        }

        public void Add(T item)
        {
            if (count == array.Length)
            {
                ResizeArray(array.Length + 2);
            }
            array[count] = item;
            count++;
        }

        public T Get(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index does not exisit");
            }
            return array[index];
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException("Index does not exisit");
            }
            for (int i = index; i < count; i++)
            {
                array[i] = array[i + 1];
            }
            count--;
            array[count] = default(T);
        }

        public void OutputContents()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public void ResizeArray(int newSize)
        {
            if (newSize < count)
            {
                throw new ArgumentException("The new size must be larger then the number of elements in the array.");
            }

            T[] newArray = new T[newSize];
            for (int i = 0; i < count; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
    }
}
