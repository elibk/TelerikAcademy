using System;
using System.Diagnostics;
using System.Linq;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
            Debug.Assert(arr[index].CompareTo(arr[minElementIndex]) <= 0, string.Format("The swap is not correct {0} is not <= {1}", arr[index], arr[minElementIndex]));
        }

        Debug.Assert(IsSort<T>(arr), "The sort is not correct.");
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(startIndex >= 0, "value of 'startIndex' can not be negative number.");
        Debug.Assert(startIndex < arr.Length, " value of 'startIndex' should be in the bounce off 'arr'");
        Debug.Assert(startIndex <= endIndex, " value of 'startIndex' can not be bigger than value of 'endIndex'");
        Debug.Assert(endIndex < arr.Length, " value of 'endIndex' should be in the bounce off 'arr'");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex) 
        where T : IComparable<T>
    {
        Debug.Assert(IsSort<T>(arr), "can not preform BinarySearch on unsorted array");
        Debug.Assert(arr.Length > 0, "can not preform BinarySearch in empty array");
        Debug.Assert(startIndex >= 0, "value of 'startIndex' can not be negative number.");
        Debug.Assert(startIndex < arr.Length, " value of 'startIndex' should be in the bounce off 'arr'");
        Debug.Assert(startIndex <= endIndex, " value of 'startIndex' can not be bigger than value of 'endIndex'");
        Debug.Assert(endIndex < arr.Length, " value of 'endIndex' should be in the bounce off 'arr'");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            Debug.Assert(midIndex < arr.Length || midIndex < 0, "value of 'midIndex' should be in the bounce off 'arr'.");
            if (arr[midIndex].Equals(value))
            {
                Debug.Assert(arr.Contains(value), "It will be returned a wrong index for a value that is not found in the 'arr'.");
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else 
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        Debug.Assert(!arr.Contains(value), "It will be returned a wrong index for a value that is contained in the 'arr'.");
        return -1;
    }

    private static bool IsSort<T>(T[] arr)
    where T : IComparable<T>
    {
        for (int index = 0; index < arr.Length - 1; index++)
        {
            if (arr[index].CompareTo(arr[index + 1]) > 0)
            {
                return false;
            }
        }
        return true;
    }

   private static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        ////BinarySearch(arr, 2); //preforming BinarySearch on unsorted array
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));

        // Test sorting empty array
        int[] arrWithZeroElements = new int[0];
        Console.WriteLine("arrWithZeroElements = [{0}]", string.Join(", ", arrWithZeroElements));
        SelectionSort(arrWithZeroElements);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arrWithZeroElements));
        SelectionSort(new int[0]);

       // Console.WriteLine(BinarySearch(arrWithZeroElements, -1000)); //can not preform search in empty array
        
        // Test sorting single element array
        int[] arrWithSingleElement = new int[1];
        Console.WriteLine("arrWithSingleElement = [{0}]", string.Join(", ", arrWithSingleElement));
        SelectionSort(arrWithSingleElement);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arrWithSingleElement));

        Console.WriteLine(BinarySearch(arrWithSingleElement, -1000));
        Console.WriteLine(BinarySearch(arrWithSingleElement, 0));
        Console.WriteLine(BinarySearch(arrWithSingleElement, 17));
        Console.WriteLine(BinarySearch(arrWithSingleElement, 10));
        Console.WriteLine(BinarySearch(arrWithSingleElement, 1000));
    }
}
