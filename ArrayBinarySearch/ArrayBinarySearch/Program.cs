using System;

namespace ArrayBinarySearch
{
    class Program
    {
        //This code show one basic implementation to binary search algorithm
        static void Main(string[] args)
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            //For example to get index position of value on array
            try
            {
                Console.WriteLine($"Index position is: {BinarySearch(array, 2)}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static int BinarySearch(int[] array, int keyValue)
        {
            Array.Sort(array);

            var middleIndex = 0;
            var leftIndex = 0;
            var rightIndex = array.Length - 1;

            while (leftIndex <= rightIndex)
            {
                middleIndex = (leftIndex + rightIndex) / 2;
                if (array[middleIndex] == keyValue)
                {
                    return middleIndex;
                }
                else if (keyValue > array[middleIndex])
                {
                    leftIndex = middleIndex + 1;
                }
                else
                {
                    rightIndex = middleIndex - 1;
                }
            };

            throw new ArgumentException($"Invalid {nameof(keyValue)} argument. Key don't exist.");
        }
    }
}
