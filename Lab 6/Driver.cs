//  Based on
//  main.cpp
//  HeapSort Lab
//  and
//  MergeSort Problem from Spring term 2019
//
//  Created by Jim Bailey on 5/15/19.
//
//  Transpiled by Katie Strauss 11/13/2019

using System;
using HeapClass;
using PriorityQ;
using static RecursiveSorts.RecSorts;

namespace Lab7HeapSort
{
    class Driver
    {
        const int NUM_VALUES = 15;

        static void Main(string[] args)
        {
            // Uncomment line to run test

            TestHeap();
            TestPriorityQ();
            TestHeapSort();
            TestMergeSort();
            TestQuickSort();
            TestFindNth();

            Console.Write("Press Enter to exit.");
            Console.Read();
        }

        // generic Display method
        static void Display(int[] theArray, int length)
        {
            const int LINE_LEN = 10;
            const int NUM_WID = 4;

            for (int i = 0; i < length; i++)
            {
                Console.Write(theArray[i].ToString().PadLeft(NUM_WID));
                if ((i + 1) % LINE_LEN == 0)
                    Console.Write("\n");
            }
            Console.Write("\n");
        }

        // load array with random numbers
        static void Init(int[] theArray, int length)
        {
            var rand = new Random();

            const int MAX = 99;
            const int MIN = 1;

            for (int i = 0; i < length; i++)
                theArray[i] = rand.Next(MIN, MAX);
        }

        static void TestHeap()
        {

            int[] heapVals = new int[NUM_VALUES] { 10, 5, 30, 15, 20, 40, 60, 25, 50, 35, 45, 65, 70, 75, 55 };

            Console.Write("Creating heap of default size (10)\n");
            Heap pile = new Heap();

            // load the heap with values
            Console.Write("Now filling it with 15 values, should cause doubling of size\n\n");
            for (int i = 0; i < NUM_VALUES; i++)
                pile.AddItem(heapVals[i]);

            // remove values, should be in ascending order
            Console.Write("Now removing values to see if properly ordered\n");
            Console.Write(" In order s/b: 5 10 15 20 25 30 35 40 45 50 55 60 65 70 75\n");
            Console.Write(" Actual order: ");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(pile.GetItem() + " ");
            Console.Write("\n\n");

            // now test for taking one too many
            Console.Write("Now testing for exception on removing\n");
            try
            {
                pile.GetItem();
                Console.Write("Should have failed, but did not\n");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Write("Caught error message: " + ex.Message + "\n");
            }

            Console.Write("\nDone with testing heap\n\n");
        }

        static void TestPriorityQ()
        {
            int[] pqVals = new int[NUM_VALUES] { 2, 4, 6, 8, 10, 1, 3, 5, 7, 9, 11, 15, 12, 14, 13 };

            Console.Write("Creating priority queue of default size (10)\n");
            PriorityQueue pList = new PriorityQueue();

            // load the heap with values
            Console.Write("Now filling it with 15 values, should cause doubling of size\n\n");
            for (int i = 0; i < NUM_VALUES; i++)
                pList.AddItem(pqVals[i]);

            // remove values, should be in ascending order
            Console.Write("Now removing values to see if properly ordered\n");
            Console.Write(" In order s/b: 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15\n");
            Console.Write(" Actual order: ");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(pList.GetItem() + " ");
            Console.Write("\n\n");

            // now test for taking one too many
            Console.Write("Now testing for exception on removing\n");
            try
            {
                pList.GetItem();
                Console.Write("Should have failed, but did not\n");
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.Write("Caught error message: " + ex.Message + "\n");
            }

            Console.Write("\nDone with testing priority queue\n\n");
        }

        static void TestHeapSort()
        {
            int[] heapArray = new int[NUM_VALUES] { 41, 2, 3, 5, 13, 17, 43, 23, 29, 7, 11, 19, 31, 37, 47 };

            // show starting array
            Console.Write("Starting array is \n");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(heapArray[i] + " ");
            Console.Write("\n");

            // now sort it
            HeapSort(heapArray, NUM_VALUES);
            
            // show updated array, should be in ascending order
            Console.Write("Now the array should be sorted\n");
            Console.Write(" expected: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47\n");
            Console.Write(" actually: ");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(heapArray[i] + " ");
            Console.Write("\n");

            Console.Write("\nDone with testing heap sort\n\n");
        }

        static void TestMergeSort()
        {
            int[] mergeArray = new int[NUM_VALUES] { 41, 2, 3, 5, 13, 17, 43, 23, 29, 7, 11, 19, 31, 37, 47 };

            // show starting array
            Console.Write("Starting array is \n");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(mergeArray[i] + " ");
            Console.Write("\n");

            // now sort it
            MergeSort(mergeArray, NUM_VALUES);

            // show updated array, should be in ascending order
            Console.Write("Now the array should be sorted\n");
            Console.Write(" expected: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47\n");
            Console.Write(" actually: ");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(mergeArray[i] + " ");
            Console.Write("\n");

            Console.Write("\nDone with testing merge sort\n\n");
        }

        static void TestQuickSort()
        {
            int[] quickArray = new int[NUM_VALUES] { 41, 2, 3, 5, 13, 17, 43, 23, 29, 7, 11, 19, 31, 37, 47 };

            // show starting array
            Console.Write("Starting array is \n");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(quickArray[i] + " ");
            Console.Write("\n");

            // now sort it
            QuickSort(quickArray, NUM_VALUES);

            // show updated array, should be in ascending order
            Console.Write("Now the array should be sorted\n");
            Console.Write(" expected: 2 3 5 7 11 13 17 19 23 29 31 37 41 43 47\n");
            Console.Write(" actually: ");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(quickArray[i] + " ");
            Console.Write("\n");

            Console.Write("\nDone with testing quick sort\n\n");
        }

        static void TestFindNth()
        {
            int[] findArray = new int[NUM_VALUES] { 41, 2, 3, 5, 13, 17, 43, 23, 29, 7, 11, 19, 31, 37, 47 };

            // show starting array
            Console.Write("Starting array is \n");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(findArray[i] + " ");
            Console.Write("\n");

            // now find the value
            Console.Write("Finding 7th value, should be 19 \n");
            Console.Write(" actually is: ");
            Console.Write(FindNth(findArray, NUM_VALUES, 7) + "\n");


            // show updated array, should be in partially sorted order
            Console.Write("Now the array should be partially sorted\n");
            Console.Write(" actually: ");
            for (int i = 0; i < NUM_VALUES; i++)
                Console.Write(findArray[i] + " ");
            Console.Write("\n");

            Console.Write("\nDone with testing findNth \n\n");
        }
    }
}