using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ReverseInteger
{
    /// <summary>
    /// 
    /// </summary>
    public class ReverseIntegerChallenge
    {
        /// <summary>
        /// solution to the coding challenge at https://leetcode.com/problems/reverse-integer/
        /// </summary>
        /// <returns></returns>
        public int Solve()
        {
            int x = 153423669;
            int num = x;

            int reversedNumber = 0;

            bool wasNegative = false;

            // get value the max value an int can store.
            int maxVal = int.MaxValue / 10;

            // if the number is a minus, convert it to a positive
            if (num < 0)
            {
                num = num * -1;
                wasNegative = true;
            }

            // each time around the loop, num will loose its last digit until 
            // finaly it will be less than 1. At this point we will have reversed
            // the number
            while (num > 0)
            {
                // we are about to times reversedNumber by 10.
                // however we need to check doing so does not go out side the
                // int.max value. to do this we can compare its current value to
                // half of the ints max value and if it is greater than half of 
                // int.max value we know that if we were to time it by 10 it would
                // go over the int.max value.
                if (reversedNumber > maxVal)
                    return 0;// solution asked us to return zero if number goes over int.max value

                // get the digit on the far right of the number
                int lastDigit = num % 10;
                // move the reversedNumber left one place by timesing it by 10.
                // this allows us to add the new number (lastDigt) to the units place of the number
                reversedNumber = reversedNumber * 10;

                // add the 2 numbers together 
                reversedNumber += lastDigit;

                // remove the digit farthest to the right off the number
                num = num / 10;
            }

            if (wasNegative)
                reversedNumber = reversedNumber * -1;



            return reversedNumber;
        }
    }
}
