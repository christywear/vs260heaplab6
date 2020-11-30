using System;

namespace HeapClass
{
    public class Heap
    {
        private int[] NewArray { get; set; }  // create new array for heap
        
        
        private int Counter { get; set; }
        private int SizeOfArray { get; set; }
        
        public Heap(int size = 10)
        {
            SizeOfArray = size;
            NewArray = new int[SizeOfArray]; // set size
        }

        public Heap()
        {
            SizeOfArray = 10;
            this.NewArray = new int[SizeOfArray]; // set size
        }       
        public void AddItem(int item)
        {

            if (Counter >= this.NewArray.Length)
            {
                // we need to double to make bigger.
                SizeOfArray *= 2;
                int[] temp = new int[SizeOfArray];
                NewArray.CopyTo(temp, 0);
                NewArray = temp;
            }
            NewArray[Counter] = item;

            BubbleUp(Counter);

            Counter++;

        }

        //removes and returns smallest item from heap
        public int GetItem()
        {

            if (Counter <= 0)
            {
                IndexOutOfRangeException doThis = new IndexOutOfRangeException();
                throw doThis;
            }
            int returnthis = NewArray[0];
            NewArray[0] = NewArray[Counter - 1];
            Counter--;
            TrickleDown(0);
            return returnthis;
            
        }
  
        // recursive method to restore heap after add
        private void BubbleUp(int index)
        {
            //if at root done
            if (index == 0)
            {
                return;
            }
            int parent = GetParent(index);
            
            if(NewArray[parent] > NewArray[index])
            {
                Swap(parent, index);
                BubbleUp(parent);
            }
            else
            {
                return;
            }

        }

        private void TrickleDown(int index)
        {
            int left = GetLeft(index);
            int right = GetRight(index);
            
            if(left >= Counter)
            {
                return;
            }

            if (right >= Counter)
            {

                //check for swap
                if (NewArray[left] < NewArray[index])
                {
                    Swap(left, index);
                    TrickleDown(left);
                }
            }
            else // two children
            {
                if (NewArray[left] < NewArray[right])
                {
                    if (NewArray[left] < NewArray[index])
                    {
                        Swap(left, index);
                        TrickleDown(left);
                    }
                }
                else // left smaller
                {
                    //do we need swapping
                    if (NewArray[right] > NewArray[index])
                    {
                        Swap(right, index);
                        TrickleDown(right);
                    }
                }

            }
        }

        public void Swap(int x, int y)
        {
            if (this.NewArray.Length <= y || x < 0)
                return;
            int buff = this.NewArray[x];
            this.NewArray[x] = this.NewArray[y];
            this.NewArray[y] = buff;
            return;
        }

        public static int GetParent(int loc)
        {
            int pos = ((loc - 1) / 2);
            return pos;
        }

        public static int GetLeft(int loc)
        {
            int pos = ((2 * loc) + 1);
            return pos;
        }

        public static int GetRight(int loc)
        {
            int pos = ((2 * loc) + 2);
            return pos;
        }

    }
}
