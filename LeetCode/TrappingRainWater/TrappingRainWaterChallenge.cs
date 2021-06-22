using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.TrappingRainWater
{
    /// <summary>
    /// solution to the coding challenge at https://leetcode.com/problems/trapping-rain-water/
    /// </summary>
    public class TrappingRainWaterChallenge
    {
        /// <summary>
        /// indicates the position of a wall and the height of a wall.
        /// </summary>
        //private int[] _InputData = new int[]{0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1};
        private int[] _InputData = new int[] { 4, 2, 0, 3, 2, 5 };

        public void SolveChallenge()
        {
            int TotalVolumeOfWater = GetWaterVolume();
            Console.WriteLine(TotalVolumeOfWater);
        }

        private int GetWaterVolume()
        {
            Dictionary<string, List<int>> wallCounter = new Dictionary<string, List<int>>();

            // go through each elevation map
            for (int WallIndexPosition = 0; WallIndexPosition < this._InputData.Length; WallIndexPosition++)
            {
                // get the current elevation at current position
                int wallHeight = this._InputData[WallIndexPosition];

                // if we are at ground zero (elevation zero), do nothing. as this is not a wall
                if (wallHeight == 0)
                    continue;

                // count all the walls at this elivation and keep track of them and the position they are at
                // e.g. if we are at elevation 2, there will be 2 walls (one at elevation 1 and one at elevation 2)
                this.AddWalls(wallHeight, WallIndexPosition, wallCounter);
            }

            // keeps track of the total volume of water
            int TotalVolumeOfWater = 0;
            // go throgh each elevation
            foreach (var item in wallCounter)
            {
                // make sure there are at least 2 walls (can't hold water when there is only 1 wall)
                if (item.Value.Count() < 2)
                    continue;

                // go through each wall at the current elevation starting from the furthest away wall and
                // working back towards the first wall
                for(int eachWall = item.Value.Count() - 1; eachWall > 0; eachWall--)
                {
                    // get the horizontal position the current wall is at
                    int currentWallPosition = item.Value[eachWall];
                    // looking in a horizontal strate line, find the next wall we can see at this elevation
                    int previouseWallPosition = item.Value[eachWall - 1];

                    // find the horizontal volume of water between the 2 walls
                    int HorizontalVolumeOfWaterBetweenBlocks = currentWallPosition - previouseWallPosition - 1;

                    // add the horizontal volume of water to the total volume of water found
                    TotalVolumeOfWater += HorizontalVolumeOfWaterBetweenBlocks;
                }
            }

            return TotalVolumeOfWater;

        }

        private void AddWalls(int WallHeight, int WallIndexPosition, Dictionary<string, List<int>> wallCounter)
        {
            int CurrentHeight = WallHeight;
            // go through each elevation until we reach zero
            while(CurrentHeight > 0)
            {
                // check to see if we have had water at current elevation before. if not create a new list
                if (wallCounter.ContainsKey(CurrentHeight.ToString()) == false)
                    wallCounter[CurrentHeight.ToString()] = new List<int>();

                // note down the position (horizontally) this water volume is at.
                wallCounter[CurrentHeight.ToString()].Add(WallIndexPosition);

                // get the next elvation
                CurrentHeight--;
            }
        }



    }
}
