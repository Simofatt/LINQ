using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithms
{
    public static class CountTriplets
    {
        
        public static int countGoodTriplets(int[] arr, int a,int b,int c)
        {
            int count = 0;

           for(var i =0; i < arr.Length; i++)
            {

                for(var j =0; j < arr.Length; j++)
                {
                    if (i<j && Math.Abs(arr[i] - arr[j]) <= a)
                    {
                        for (var k = 0; k < arr.Length; k++)
                        {
                            if( k > j && Math.Abs(arr[i] - arr[k]) <= b && Math.Abs(arr[j]-arr[k]) <= c)
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count; 
        }
    }
}
