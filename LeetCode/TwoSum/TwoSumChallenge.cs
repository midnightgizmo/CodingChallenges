using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TwoSum
{
    /// <summary>
    /// solution to the coding challenge at https://leetcode.com/problems/two-sum/submissions/
    /// </summary>
    public class TwoSumChallenge
    {

        /// <summary>
        /// looks through the array of numbers to see if any 2 of the numbers add up to the target number
        /// </summary>
        /// <param name="nums">numbes to look through</param>
        /// <param name="target">target number to look for</param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {

            int[] answer = new int[2];
            bool WasValueFound = false;
            // go through each number in the array
            for (int index = 0; index < nums.Length; index++)
            {
                // go through each number in the array starting after index current position
                for (int secondIndex = index + 1; secondIndex < nums.Length; secondIndex++)
                {
                    // add the number fromthe first loop and the second loop together
                    int sumOfNumbers = nums[index] + nums[secondIndex];
                    // is this the number we are looking for
                    if (sumOfNumbers == target)
                    {
                        // store the index position of the first number
                        answer[0] = index;
                        // store the index position of the second number
                        answer[1] = secondIndex;
                        // let the outer for loop know we found the number we were looking for
                        // so it can break out of the loop
                        WasValueFound = true;
                        // break out of the inner loop
                        break;
                    }
                }

                // if we found the number in the inner for loop, no longer
                // need to go through any numbers
                if (WasValueFound)
                    break;
            }
            // return the found answer
            return answer;

        }
    }
}
