using ArraysSortingAndManipulating.Challenges.FindAllPermutations;
using System;

namespace ArraysSortingAndManipulating
{
    class Program
    {
        static void Main(string[] args)
        {
            // Challenge one
            //
            // Sort the array from smallest to biggest without creating another array
            // e.g. if the inputed numbers were
            // {5,3,7,2,6,8,1}
            // the array should be changed to
            // {1,2,3,5,6,7,8}
            int[] numbersToSort = { 5, 3, 7, 2, 6, 8, 1 };
            Challenges.ChallengeOne.SortNumbersInArray ChallengeOne = new Challenges.ChallengeOne.SortNumbersInArray();
            ChallengeOne.SortNumbers(numbersToSort);
            // print the sorted numbers to the console
            foreach(int number in numbersToSort)
                Console.WriteLine(number);

            // Find all possible permutations for a given set of data.
            // data must be a string seperated by a comma and each one must only be one char long.
            Permutations permutations = new Permutations();
            // each char must be one letter long and sperated by a comma
            permutations.Initialize("A,B,C");
            permutations.PrintAllPossiblePermutations();



            Console.WriteLine("press any key to exit");
            Console.ReadKey();


        }
    }
}
