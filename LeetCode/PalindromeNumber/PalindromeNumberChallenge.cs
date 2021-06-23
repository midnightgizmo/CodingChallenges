using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.PalindromeNumber
{
    /// <summary>
    /// solution to the coding challenge at https://leetcode.com/problems/palindrome-number/
    /// </summary>
    public class PalindromeNumberChallenge
    {
        /// <summary>
        /// Finds out if the number is the same backwords as it is forwards.
        /// </summary>
        /// <returns></returns>
        public bool Solve()
        {
            int x = 121;
            int num = x;

            // zero is the same backwards as it is fowards
            if (num == 0)
                return true;


            // if num is less than 10 or number ends in a zero.
            // Numbers that end in a zero won't be a palindrome because
            // numbers don't start with zero
            if (num < 0 || (num % 10 == 0))
                return false;

            int palindromeNum = 0;
            // every time we go around the loop, num looses a unit on the end of its number (and palindromeNum gains one).
            // so if we started with 123, the second loop around would be 12 (number gets divided by 10
            // each time around the loop)
            // PlaindromeNum gains one unit each time around the loop (it takes the last number off num).
            // so if num == 123, after the first loop is done, palindromeNum will == 3 (taken the last number off num)
            // and at the end of the second loop palindromeNum will equal 32
            while (num > palindromeNum)
            {
                int lastDigitInNumber = (num % 10);

                // we want to add the lastDigitNumber to the end of the current palindromeNum.
                // this means we need to move the palindromeNumber one digit to the left. To 
                // do this we times the palindrome number by 10;
                palindromeNum = (palindromeNum * 10);

                //now we can add the numbers together
                palindromeNum += lastDigitInNumber;

                // remove the last digit off the number (the units part of the number)
                num = num / 10;
            }

            // if the original number length was an even number (1235 is an even number because it is 4 digits long.
            // 123 is an odd numebr because it is 3 digits long)
            // we can do a simple comparision between um and palindromeNum
            if (num == palindromeNum)
                return true;
            // if the origninal nums length was not even then the palindroneNum will be one digit longer than num
            // and hold the middle number. We need to remove this number and then compare the 2 numbers
            if (num == palindromeNum / 10)
                return true;

            // if we get this far then the orignal number is not a Palindrome (same number backwards as is forwards)
            return false;
        }
    }
}
