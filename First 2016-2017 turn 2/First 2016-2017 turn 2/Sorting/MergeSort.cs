using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
  public enum SortingTechniques { MERGE_SORT };

  public class SortFunctions<T> where T : IComparable
  {

        //2,3,1,7,4,0,9,5
    private static T[] Merge(T[] arr, int left, int middle, int right)
    {
      int i, j, k;
            var resultList = new List<T>();
            T[] result = new T[arr.Length];
      T[] arr1 = new T[middle - left + 1];
      T[] arr2 = new T[right - middle];
      for (i = 0, k = left; i < arr1.Length; i++, k++)
        arr1[i] = arr[k];
        //2,3,1,7
      for (j = 0, k = middle + 1; j < arr2.Length; j++, k++)
        arr2[j] = arr[k];
            //4,0,9,5
            //complete
            var tempArr1 = arr1.ToList();
            var tempArr2 = arr2.ToList();
            while (tempArr1.Count > 0 && tempArr2.Count > 0)
            {
                if (tempArr1[0].CompareTo(tempArr2[0]) < 0)
                {
                    resultList.Add(tempArr1[0]);
                    tempArr1.RemoveAt(0);
                }
                else
                {
                    resultList.Add(tempArr2[0]);
                    tempArr2.RemoveAt(0);
                }
                foreach (var item in resultList)
                {
                    Console.WriteLine(item);
                }
            }

            while (tempArr1.Count > 0)
            {
                resultList.Add(tempArr1[0]);
                tempArr1.RemoveAt(0);
            }

            while (tempArr2.Count > 0)
            {
                resultList.Add(tempArr2[0]);
                tempArr2.RemoveAt(0);
            }
            arr = resultList.ToArray();
            return arr;
    }

    private static T[] MergeSort(T[] arr, int leftBoundary, int rightBoundary)
    {
      if (leftBoundary < rightBoundary)
      {
        int middle = (leftBoundary + rightBoundary) / 2;
        T[] leftHalf = MergeSort(arr, leftBoundary, middle);
        T[] rightHalf = MergeSort(arr, middle + 1, rightBoundary);
        T[] mergedHalves = Merge(arr, leftBoundary, middle, rightBoundary);
        return mergedHalves;
      }
      else
        return arr;
    }

    public static T[] Sort(T[] arr, SortingTechniques sortingAlgorithm)
    {
      switch (sortingAlgorithm)
      {
        case SortingTechniques.MERGE_SORT:
          return MergeSort(arr, 0, arr.Length - 1);
        default:
          break;
      }
      return arr;
    }
  }
}
