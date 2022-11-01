using System;
using System.Collections.Generic;
using System.Text;

namespace ArraysSortingAndManipulating.Challenges.FindAllPermutations
{
    /// <summary>
    /// Find all permutations in a given string. Prints the found permutations to the Console
    /// </summary>
    public class Permutations
    {
        // This will hold the input data that has been split into each letter
        private StringBuilder _InishalInputPermutation = new StringBuilder();

        // Holds a list of all the found permutations after calling PrintAllPossiblePermutations
        private List<string> _FoundPermutations = new List<string>();


        // The input data. MUST be one letter separated by a comma e.g. "A,B,C,D"
        public void Initialize(string data)
        {
            // split the input data at the comma and get each letter
            string[] splitData = data.Split(new char[] { ',' });

            // add each letter to the _InishalInputPermutation.
            // This will be the starting point when working out permutations
            foreach (string aPeace in splitData)
                this._InishalInputPermutation.Append(aPeace);
        }

        /// Find and print to the console all possible permutation that were passed in when
        /// calling the Initialize method
        public void PrintAllPossiblePermutations()
        {
            // We allready have one one permutation, the one that was sent into us
            this._FoundPermutations.Add(this._InishalInputPermutation.ToString());
            // log this permutation to the screen
            Console.WriteLine(this._InishalInputPermutation.ToString());

            // if we have only been sent one letter, then
            // there are no more permutations to do
            if (this._InishalInputPermutation.Length < 2)
                return;

            // Find all permutations of this arrangement of letter.
            // The first letter in this permutation will be locked
            this.FindPermutations(0, this._InishalInputPermutation);


            // By now we have worked out all permutations with the first letter locked.
            // Now, swop the first letter with all letter that follow it. Each time
            // work out the permutations.
            // e.g. If input was "a,b,c,d"
            // go through each letter after a and swop it with a.
            // So "b,a,c,d" (this is a new arrangement so work out all permutations for this)
            // "c,b,a,d" (this is a new arrangement so work out all permutations for this)
            // "d,b,c,a" (this is a new arrangement so work out all permutations for this)

            // find the first letter so we know what we are swapping
            char firstLetter = this._InishalInputPermutation[0];
            for (int index = 1; index < this._InishalInputPermutation.Length; index++)
            {
                // make a copy of the input data we were sent
                StringBuilder sb = new StringBuilder(this._InishalInputPermutation.ToString());
                // take the letter at the specified index and put it at the beging of the string overwriting the first letter in the string
                sb[0] = sb[index];
                // take the letter at the specified index and overwrite it with what was the first letter in the string
                sb[index] = firstLetter;

                // out put this new permutation
                Console.WriteLine(sb.ToString());

                // add this permutation to the list
                this._FoundPermutations.Add(sb.ToString());

                // keeping the first char locked (it can't change position), find out
                // all permutations by changing the rest of the letters in the string.
                this.FindPermutations(0, sb);
            }
        }

        /// Takes in a string and works out all permutations. All letters from start of string to FixedPositionIndex will be ignore (won't be swapped around)
        /// <param FixedPositionsIndex The part of the string where we dont want the string to change during permutations (starts at zero up to FixedPositionsIndex) />
        /// <param data the string we will look at when working out permutations />
        private void FindPermutations(int FixedPositionsIndex, StringBuilder data)
        {
            // If the last letter in the string is the fixed position, then
            // there is nothing to do (no permutations to work out)
            if (FixedPositionsIndex == data.Length - 1)
                return;


            // create a variable that will store the part of the string that will not change
            string fixedPartOfString = string.Empty;

            // create the fixed part of the string
            for (int index = 0; index < FixedPositionsIndex + 1; index++)
                fixedPartOfString += data[index];

            // create the rest of the string where positions will be swopped around
            StringBuilder unfixedPart = new StringBuilder();
            for (int index = FixedPositionsIndex + 1; index < data.Length; index++)
                unfixedPart.Append(data[index]);


            // find the position of the letter we want to swop around
            int newFixedPosition = FixedPositionsIndex + 1;
            // What is the letter we want to swop around
            string letterToSwopAround = data[newFixedPosition].ToString();
            // will keep track of the letter we want to swop with in the  unfixedPart of the string
            int count = 1;
            // go through each unfixed part of the string and swop the first letter with the current
            // letter we are looking at in the loop.
            for (int position = FixedPositionsIndex + 2; position < data.Length; position++)
            {

                // make a copy of the unfixedPart of the string to allow us to manipulate it
                StringBuilder tempString = new StringBuilder();
                tempString.Append(unfixedPart);

                // find the letter at the current position in the loop (for the unfixedpart of the string)
                char letterBeingSwoped = tempString[count];
                // swop the first letter in the unfixed part with the letter at the current position in the loop
                tempString[0] = letterBeingSwoped;
                // swop the letter at the current position in the loop with the first letter in the unfixed part
                tempString[count] = letterToSwopAround[0];
                // increment count by one so we know which letter we are looking at in the unfixedpart of the loop
                count++;

                // get the new permutation we just made by adding the fixed part with the unfixed part
                string newPermutation = fixedPartOfString + tempString.ToString();
                // add this new permutation to the list
                this._FoundPermutations.Add(newPermutation);
                // write out the new permutation to the console
                Console.WriteLine(fixedPartOfString + tempString.ToString());

                // calculate all the permutations for the current permutation we just found.
                // Add 1 to the fixed position (so the current first letter we looked at now becomes the fixed position)
                // We will recursively keep calling this function until all letter become fixed.
                FindPermutations(FixedPositionsIndex + 1, new StringBuilder(newPermutation));

            }




        }
    }
}
