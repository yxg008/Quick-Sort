using System;

namespace CSC_515_Sorting
{
    class Program
    {  // ruuning time O(n)
        static void Main(string[] args) // O(n^2)
        {
            int[] values = { 7, 3, 21, 9, 14, 15, 10 };

            //BubbleSort(values); // O(n^2)
            //DisplayArray(values); //o(n)

            //BubbleSort2(values);
            //DisplayArray(values);

            Mergeshort2(values);
            DisplayArray(values);
            //string[] words = { "saint", "Martin", "University" };
            //Mergeshort2(words);
            //DisplayArray(words);


        }

        static void DisplayArray(int[] arr)
        {
            foreach (var val in arr)
            {
                Console.Write($"{val} ");
            }
            Console.WriteLine();
        }

        //static void BubbleSort(int[] arr) // O(n^2) best and worst case
        //{for(int j = 0; j < arr.Length - 1 ; j++) // 0(n^2)
        //    // traverse the array
        //    for (int i = 0; i < arr.Length - 1 - j; i++) // 0(n)
        //    {
        //        if (arr[i] > arr[i + 1]) //0(1)
        //        {
        //            // swap
        //            int tmp = arr[i];
        //            arr[i] = arr[i + 1];
        //            arr[ i + 1] =  tmp;

        static void BubbleSort2(int[] arr) // O(n^2) best and worst case big OMega
        {
            for (int j = 0; j < arr.Length - 1; j++) // 0(n^2)
            {
                bool performedSwapsFlag = false; // set the flags
                for (int i = 0; i < arr.Length - 1 - j; i++) // 0(n)
                {
                    // traverse the array
                    if (arr[i] < arr[i + 1]) //0(1)
                    {
                        // swap
                        int tmp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = tmp;
                        performedSwapsFlag = true; // set the flags
                    }
                }

                if (performedSwapsFlag == false) // if no swaps

                {
                    break;// return; We are done early, the array is sorted
                }

            }

            //}
            //static void Selectionsort(int[] arr) // O(n^2)
            //{
            //    for (int i = 0; i < arr.Length - 1; i++) // O(n^2)
            //    {
            //        int posMin = i;
            //        for (int j = i; j < arr.Length; j++) //O(n)
            //        {

            //            if (arr[j] < arr[posMin])
            //            {
            //                posMin = j;
            //            }

            //        }
            //        // Swao elements at position i and minPos
            //        int tmp = arr[i];
            //        arr[i] = arr[posMin];
            //        arr[posMin] = tmp;

            //}

            //public static void Merge(int[] arr, int startIdx, int midIdx, int endIdx, int[] tmp) // bigO(logn)
            //{
            //    int[] tmp = new int[arr.Length];

            //    int i = startIdx;
            //    int j = midIdx + 1;
            //    int k = startIdx;
            //    while(i <= midIdx && j <= endIdx) // there are still values in both "halaves"
            //    {
            //        if (arr[i] < arr[j])
            //        {
            //            tmp[k] = arr[i];
            //            i++;
            //            k++;
            //        }
            //        else
            //        {
            //            tmp[k] = arr[j];
            //            k++;
            //            j++;
            //        }
            //        while (i <= midIdx) // copy left overs
            //        {
            //            tmp[k] = arr[i];
            //            i++;
            //            k++;
            //        }
            //        while (j <= endIdx)
            //        {
            //            tmp[k] = arr[j];
            //            k++;
            //            j++;
            //        }
            //        // move vlues from tmp back onto arr
            //        for (i = startIdx; i<= endIdx; i++)
            //        {
            //Array[i] = tmp[i];
            //        }

            //        static void MergeSort(int[] arr)
            //        {
            //            int[] tmp = new int[arr.Length]; // only created once
            //            MergeSortHelper(arr, 0, arr.Length - 1, tmp);
            //        }

            //        static void MergeSortHelper(int[] arr, int startIdx, int endIdx)
            //        {
            //            if(startIdx < endIdx)// at lease two elements
            //            {
            //                int midIdx = (startIdx + endIdx) / 2;
            //                MergeSortHelper(arr, startIdx, midIdx); // sort the first "half"
            //                MergeSortHelper(arr, midIdx + 1, endIdx); // sort the second "half"
            //                Merge(arr, startIdx, midIdx, endIdx);
            //            }

            //        }
            //    }

            static void Mergeshort2(int[] arr)
        {
            int[] tmp = new int[arr.Length];
            MergeSort2Helper(arr, 0, arr.Length - 1, tmp);
        }


        static void MergeSort2Helper(int[] arr, int startIdx, int endIdx, int[] tmp)
        {
            if (startIdx < endIdx)// as long as we have at least 2 element in the slice
            {
                // divide
                int midIdx = (startIdx + endIdx) / 2;
                MergeSort2Helper(arr, startIdx, midIdx, tmp);// sort the first half
                MergeSort2Helper(arr, midIdx, endIdx, tmp);// sort the second half

                // conquer
                Merge2(arr, startIdx, midIdx, endIdx, tmp);
            }

        }
        public static void Merge2(int[] arr, int startIdx, int midIdx, int endIdx, int[] tmp)
        {
            int i = startIdx;
            int j = midIdx + 1;
            int k = startIdx;
            if (arr[i] < arr[j])
                while (i <= midIdx && j <= endIdx)
                {
                    if (arr[i] < arr[j])
                    {
                        tmp[k] = tmp[i];
                        i++;
                        k++;
                    }
                    else
                    {
                        tmp[k] = tmp[j];
                        j++;
                        k++;
                    }

                    while (i <= midIdx) // copy leftover for i's
                    {
                        tmp[k] = tmp[i];
                        j++;
                        k++;
                    }
                    while (i <= midIdx) // copy leftover for i's
                    {
                        tmp[k] = tmp[j];
                        j++;
                        k++;
                    }
                    // move vlues from tmp back onto arr
                    for (i = startIdx; i <= endIdx; i++)
                    {
                        arr[i] = tmp[i];
                    }

                }
            //static void Mergeshort2<T>(T[] arr)
            //   where T : IComparable
            //{
            //    T[] tmp = new T[arr.Length];
            //    MergeSort2Helper(arr, 0, arr.Length - 1, tmp);

            //}


            //static void MergeSort2Helper<T>(T[] arr, int startIdx, int endIdx, T[] tmp)
            //    where T : IComparable
            //{
            //    if (startIdx < endIdx)// as long as we have at least 2 element in the slice
            //    {
            //        // divide
            //        int midIdx = (startIdx + endIdx) / 2;
            //        MergeSort2Helper(arr, startIdx, midIdx, tmp);// sort the first half
            //        MergeSort2Helper(arr, midIdx, endIdx, tmp);// sort the second half

            //        // conquer
            //        Merge2(arr, startIdx, midIdx, endIdx, tmp);
            //    }

            //}
            //public static void Merge2<T>(T[] arr, int startIdx, int midIdx, int endIdx, T[] tmp)
            //    where T:IComparable
            //{
            //    int i = startIdx;
            //    int j = midIdx + 1;
            //    int k = startIdx;
            //    while (i <= midIdx && j <= endIdx)

            //    {
            //        if (arr[i].CompareTo(arr[j]) <0)
            //        {
            //            tmp[k] = arr[i];
            //            i++;
            //            k++;
            //        }
            //        else
            //        {
            //            tmp[k] = arr[j];
            //            k++;
            //            j++;
            //        }
            //        while (i <= midIdx) // copy left overs
            //        {
            //            tmp[k] = arr[i];
            //            i++;
            //            k++;
            //        }
            //        while (j <= endIdx)
            //        {
            //            tmp[k] = arr[j];
            //            k++;
            //            j++;
            //        }
            //        // move vlues from tmp back onto arr
            //        for (i = startIdx; i <= endIdx; i++)
            //        {
            //            arr[i] = tmp[i];
            //        }

        }

    }

    }

