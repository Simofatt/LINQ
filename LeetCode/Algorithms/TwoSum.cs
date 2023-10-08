using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithms
{
    public static class TwoSum
    {
        public static int[] TwoSumm(int[] nums, int target)
        {
            int Summ = 999999;
            for (var i = 0; i < nums.Length; i++)
            {
                for (var j = 0; j < nums.Length; j++)
                {
                    if (i != j)
                    {

                        Summ = nums[i] + nums[j];

                    }

                    if (Summ == target)
                    {
                        int[] result = { i, j };
                        return result;
                    }

                }
            }

            return null;
        }
    }
}
