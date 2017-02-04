using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sorting;
using Dictionaries;

namespace AlgorithmsAssignments
{
  class Program
  {
    const double inf = Double.PositiveInfinity;

    double[,] adjacencyTestMatrix =
      {
        { inf, inf, -2, inf },
        { 4, inf, 3, inf },
        { inf, inf, inf, 2 },
        { inf, -1, inf, inf }
      };

    static void Main(string[] args)
    {
            BinarySearchTree<int, String> tree = new BinarySearchTree<int, string>();
            int[] arr = new int[] { 1, 7, 3, 6, 1, 9, 0, 7, 5, 4 };
            var result = SortFunctions<int>.Sort(arr, SortingTechniques.MERGE_SORT);
            
        }
    }
}
