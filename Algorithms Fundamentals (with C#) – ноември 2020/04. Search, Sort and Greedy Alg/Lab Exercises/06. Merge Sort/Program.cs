using System;
using System.Linq;

namespace _06._Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            MergeSort(elements, 0, elements.Length - 1);
            Console.WriteLine(string.Join(" ",elements));
        }

        private static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);

                Merge(arr, left, mid, right);
            }
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = (mid - left) + 1;
            int n2 = right - mid;

            var L = new int[n1];
            var R = new int[n2];
            int i, j;
            for (i = 0; i < n1; i++)
            {
                L[i] = arr[left + i];
            }

            for (j = 0; j < n2; j++)
            {
                R[j] = arr[mid + 1 + j];
            }


            i = 0;
            j = 0;
            int k = left;

            while (i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    arr[k] = L[i];
                    i++;
                }
                else
                {
                    arr[k] = R[j];
                    j++;
                }

                k++;
            }

            while (i < n1)
            {
                arr[k] = L[i];
                i++;
                k++;
            }

            while (j < n2)
            {
                arr[k] = R[j];
                j++;
                k++;
            } 
        }
    }

}