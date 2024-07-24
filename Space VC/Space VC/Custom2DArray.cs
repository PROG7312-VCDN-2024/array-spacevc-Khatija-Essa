using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_VC
{
    public class Custom2DArray<T>
    {
        private T[,] array;
        private int rows;
        private int cols;

        public Custom2DArray(int rows, int cols)
        {
            this.rows = rows;
            this.cols = cols;
            array = new T[rows, cols];
        }

        public void Add(int row, int col, T item)
        {
            if (row >= rows || col >= cols || row < 0 || col < 0)
            {
                throw new IndexOutOfRangeException("The coordinates are out of range.");
            }
            array[row, col] = item;
        }

        public T Get(int row, int col)
        {
            if (row >= rows || col >= cols || row < 0 || col < 0)
            {
                throw new IndexOutOfRangeException("The coordinates are out of range.");
            }
            return array[row, col];
        }

        public void Remove(int row, int col)
        {
            if (row >= rows || col >= cols || row < 0 || col < 0)
            {
                throw new IndexOutOfRangeException("The coordinates are out of range.");
            }
            array[row, col] = default(T);
        }

        public void OutputContents()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (array[i, j] != null)
                    {
                        Console.Write($"{array[i, j]}\t");
                    }
                    else
                    {
                        Console.Write("Empty\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
