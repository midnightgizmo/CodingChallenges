using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysSortingAndManipulating.Challenges.ChallengeOne
{
    /// <summary>
    /// Without creating any addishanl arrays, take an input of number in a static array
    /// and sort the numbers within the array.
    /// e.g. if the inputed numbers were
    /// {5,3,7,2,6,8,1}
    /// the array should be changed to
    /// {1,2,3,5,6,7,8}
    /// </summary>
    public class SortNumbersInArray
    {
        public int[] SortNumbers(int[] arrayToSort)
        {
            // make sure there are at least 2 number in the array 
            // (otherwise there is nothing to sort)
            if (arrayToSort.Length < 2)
                return arrayToSort;

            int currentIndexPosition = 0;

            // [5] [3] [4] [6] [2]
            // loop through each number starting at the first one, all
            // the way up to the second from the end.
            // Don't loop through to the every end number as this will
            // cause use to go outside the array index when checking
            for (int index = 0; index < arrayToSort.Length - 1; index++)
            {
                currentIndexPosition = index;

                // check to see if the current index number is bigger 
                // than the number to the right of it
                if (arrayToSort[index] > arrayToSort[index + 1])
                {
                    // current number is bigger than the one to the right of it
                    // so swop the 2 numbers around.
                    // swop the numbers arround
                    
                    // store each number so we are able to swop them
                    int biggerNumber = arrayToSort[index];
                    int smallerNumber = arrayToSort[index + 1];

                    // move the smaller number to the current index position
                    arrayToSort[index] = smallerNumber;
                    // move the bigger number to the (index position + 1)
                    arrayToSort[index + 1] = biggerNumber;

                    // check numbers to the left of current index position
                    // to see if they need to be swoped with the new number
                    // we just got at current index position
                    this.ReverseSort(index, arrayToSort);
                    
                }
            }

            return arrayToSort;
        }

        /// <summary>
        /// Sorts number from smallest to biggest working backwords within the array.
        /// e.g. if index position is 10 it will compare the number at position 10
        /// with the number at position 9 and them swop them if needed.
        /// </summary>
        /// <param name="index">The index position to start sorting from</param>
        /// <param name="arrayToSort">array containing numbers to search</param>
        private void ReverseSort(int index, int[] arrayToSort)
        {
            // if we are not at the begining of the array,
            // we now need to check numbers to the left of the current
            // index position to see if those numbers are bigger than 
            // the new number we just got at the current index position.
            if (index > 0)
            {
                bool needToCheckPreviouseNumber = false;
                // keep moving backwards through the array until
                // we find the numbers don't need to be swoped
                // or we are at the begining of the array
                do
                {
                    // is the number at the current index poistion smaller
                    // than the number to the left of us.
                    if (arrayToSort[index] < arrayToSort[index - 1])
                    {
                        // current number is smaller than the number to the left of
                        // it so we need to swop them.

                        // store each number so we are able to swop them
                        int biggerNumber = arrayToSort[index - 1];
                        int smallerNumber = arrayToSort[index];

                        // move the smaller number to the left 
                        // of the current index position 
                        arrayToSort[index - 1] = smallerNumber;
                        // move the bigger number to the current
                        // index position
                        arrayToSort[index] = biggerNumber;
                        // minus 1 off the current index position
                        // so that on the next do while loop we have moved
                        // position to the left by one
                        index--;
                        // inform the while loop we need to check the next
                        // number to the left
                        needToCheckPreviouseNumber = true;
                    }
                    // if the numbers do not need to be swoped, we can
                    // exit the while loop and cary on searching where we left off.
                    else
                    {
                        //index = currentIndexPosition;
                        needToCheckPreviouseNumber = false;
                    }

                // check to see if we need to move the previouse number
                } while (index > 0 && needToCheckPreviouseNumber == true);
            }
        }


    }
}
