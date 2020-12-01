using System;

namespace RecursiveSorts
{
    public class RecSorts
    {

        public static void HeapSort(int[] inArray, int length)
        {
            // heapify the array using bubbleUp
            
            int index = 0;
            while (index < length)
            {
                BubbleUp(inArray, index);
                index ++;
                            
            }
            
            // sort the array
            int last = length -1;
            while (last > 0)
            {
                Swap(0, last, inArray);
                TrickleDown(inArray, last, 0);
                last --;
            }
        }

        // recursive method to restore heap after add
        private static void BubbleUp(int[] NewArray, int index)
        {
            //if at root done
            if (index == 0)
            {
                return;
            }
            int parent = GetParent(index);

            if (NewArray[parent] > NewArray[index])
            {
                Swap(parent, index, NewArray);
                BubbleUp(NewArray, parent);
            }
            else
            {
                return;
            }

        }

        private static void TrickleDown(int[] NewArray, int index, int Counter)
        {
            int left = GetLeft(index);
            int right = GetRight(index);


            if (left >= Counter)
            {
                return;
            }

            if (right >= Counter)
            {

                //check for swap
                if (NewArray[left] < NewArray[index])
                {
                    Swap(left, index, NewArray);
                    TrickleDown(NewArray, left, Counter);
                }
            }
            else // two children
            {
                if (NewArray[left] < NewArray[right])
                {
                    if (NewArray[left] < NewArray[index])
                    {
                        Swap(left, index, NewArray);
                        TrickleDown(NewArray, left, Counter);
                    }
                }
                else // left smaller
                {
                    //do we need swapping
                    if (NewArray[right] < NewArray[index])
                    {
                        Swap(right, index, NewArray);
                        TrickleDown(NewArray, right, Counter);
                    }
                }

            }
        }

        public static void MergeSort(int[] inArray, int length)
        {
            inArray = RecMergeSort(inArray, inArray.Length);
        }

        
        //
        public static int[] RecMergeSort(int[] inArray, int length)
        {
            if (inArray.Length <= 1)
                return inArray;

            int middle = inArray.Length / 2;
           
            int[] Ltemp = new int[middle];
            int[] Rtemp;
            if (length % 2 == 0) 
            {
                Rtemp = new int[middle];
            }
            else
            {
                Rtemp = new int[middle+1];
            }

            for(int i = 0; i < middle; i++)
            {
                Ltemp[i] = inArray[i];
            }
            int grr = 0;
            for(int i = middle; i < inArray.Length; i++)
            {
                Rtemp[grr] = inArray[i];
                grr++;
            }
            Ltemp = RecMergeSort(Ltemp, Ltemp.Length);
            Rtemp = RecMergeSort(Rtemp, Rtemp.Length);

            inArray = MergeHelper(Ltemp, Rtemp, inArray);
            return inArray;
            
        }
       
        public static int[] MergeHelper(int[] Ltemp,int[] Rtemp, int[] inArray)
        {
            int leftx = 0, rightx = 0, fullx = 0;

            while(leftx < Ltemp.Length || rightx < Rtemp.Length)
            {
                if(leftx < Ltemp.Length && rightx < Rtemp.Length)
                {
                    if(Ltemp[leftx] <= Rtemp[rightx])
                    {
                        inArray[fullx] = Ltemp[leftx];
                       
                        leftx++;
                        fullx++;
                    }
                    else
                    {
                        inArray[fullx] = Rtemp[rightx];
                        
                        rightx++;
                        fullx++;
                    }
                }
                else if (leftx < Ltemp.Length)
                {
                    inArray[fullx] = Ltemp[leftx];
                   
                    leftx++;
                    fullx++;
                }
                else if(rightx < Rtemp.Length)
                {
                    inArray[fullx] = Rtemp[rightx];
                   
                    rightx++;
                    fullx++;
                }
            }
            return inArray;
        }

        public static void QuickSort(int[] inArray, int length)
        {
            inArray = recQuickSort(inArray, 0, inArray.Length -1);
        }

        private static int[] recQuickSort(int[] theArray, int first, int last)
        {
            if (first < last)
            {
                int pivot = partition(theArray, first, last);
                recQuickSort(theArray, first, pivot - 1);
                recQuickSort(theArray, pivot + 1, last);
            }
            return theArray;
        }

        private static int partition(int[] theArray, int first, int last)
        {
            int pivotIndex = first;
            int pivotElement = theArray[first];

            int index = first + 1;
            
            //move the items less than pivot to know indices
            while(index <= last)
            {
                if (theArray[index] <= pivotElement)
                {
                    pivotIndex += 1;
                    Swap(index, pivotIndex, theArray);
                }
                index++;
            }

            //place pivot in the proper place
            Swap(pivotIndex, first, theArray);

            return pivotIndex;
        }
        

        //hurm .. find nth.. realise that when the array is partitioned the partition funcion returns the index of where pivot was placed.. 
        //and that the pivot is placed in the array in final location.. 
        
        public static string FindNth(int[] inArray, int length, int pivPos)
        {
            inArray = Rec_FindNth_helper(inArray, 0, inArray.Length -1, pivPos);

            return inArray[pivPos].ToString();
        }

        public static int[] Rec_FindNth_helper(int[] theArray, int first, int last, int pivPos)
        {
            int pivot = 0;
            
                if (first < last)
                {
                    pivot = find_N_partition(theArray, first, last, pivPos);
                    recQuickSort(theArray, first, pivot - 1);
                    recQuickSort(theArray, pivot + 1, last);
                }
            
            return theArray;
        }

        private static int find_N_partition(int[] theArray, int first, int last, int pivPos)
        {
            int pivotIndex = first;
            int pivotElement = theArray[first];

            int index = first + 1;

            //move the items less than pivot to know indices
            while (index <= last && pivotElement != pivPos)
            {
                if (theArray[index] <= pivotElement)
                {
                    pivotIndex += 1;
                    Swap(index, pivotIndex, theArray);
                }
                index++;
            }

            //place pivot in the proper place
            Swap(pivotIndex, first, theArray);

            return pivotIndex;
        }
        
        public static void Swap(int x, int y, int[] thisArray)
        {
            if (thisArray.Length <= y || x < 0)
                return;
            int buff = thisArray[x];
            thisArray[x] = thisArray[y];
            thisArray[y] = buff;
            return;
        }

        public static int GetParent(int loc)
        {
            int pos = ((loc -1)/ 2);
            return pos;
        }

        public static int GetLeft(int loc)
        {
            int pos = ((2* loc) + 1);
            return pos;
        }

        public static int GetRight(int loc)
        {
            int pos = ((2*loc) + 2);
            return pos;
        }
        
    }
}
