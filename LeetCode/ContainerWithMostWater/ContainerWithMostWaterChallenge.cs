using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.ContainerWithMostWater
{
    /// <summary>
    /// solution to the coding challenge at https://leetcode.com/problems/container-with-most-water/submissions/
    /// </summary>
    public class ContainerWithMostWaterChallenge
    {
        public ContainerWithMostWaterChallenge()
        {
            int[] heightArray = new int[] { 1,1 };
            MaxArea(heightArray);
        }
        public int MaxArea(int[] height)
        {

            List<int> WaterVolumeList = new List<int>();

            int currentStartPoint = 0;
            // start at the first height and go through them one by one comparing them
            // to every other height that follows it
            while (currentStartPoint < height.Length - 1)
            {
                // go through each height that is after the currentStartPoint
                for (int endIndex = currentStartPoint; endIndex < height.Length; endIndex++)
                {
                    int waterVolume;
                    // caculate the water volume between currentStartPoint and endIndex
                    waterVolume = this.CaculateWaterVolume(currentStartPoint, endIndex, height);

                    // keep note of the water volume we just caculated
                    WaterVolumeList.Add(waterVolume);
                }
                // move to the next height on the next while loop
                currentStartPoint++;
            }
            // sort the water volumes
            WaterVolumeList.Sort();
            // the the water with the most volume
            int MostWaterVolume = WaterVolumeList[WaterVolumeList.Count() - 1];

            // return the water with the most volume.
            return MostWaterVolume;

        }



        private int CaculateWaterVolume(int indexStartPosition, int indexEndPosition, int[] HeightArray)
        {
            int length = indexEndPosition - indexStartPosition;
            int height1 = HeightArray[indexStartPosition];
            int height2 = HeightArray[indexEndPosition];
            int waterHeight = height1 > height2 ? height2 : height1;

            int waterVolume = length * waterHeight;

            return waterVolume;

        }
    }
}
