using LeetCode.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
     class Program
    {
        static void Main(string[] args)
        {
            //TWO SUM 
            int[] nums = { 0,4,3,0 };
            int target = 0;
            int[] result = TwoSum.TwoSumm(nums, target);
            Console.WriteLine("result : ");
            foreach (var i in result) {Console.WriteLine(i );}

                

            //LenghtOfTheLongestSubString
            var s = "ohomm";
            int result2 = LenghtOfTheLongestSubString.LengthOfLongestSubstring(s);
            Console.WriteLine(result2);



            //Adding an item in the end of the list.
            List<int> result3 = new List<int>() { 1,2,3,5};
            
            foreach(var i in result3) { 
            if(i ==2)
                {
                    result3.Remove(i);
                    result3.Add(i);
                    break;
                }
            }
            result3.Select(i=> { Console.WriteLine(i);return i;  }).ToList();





            //triplet count 
            var arr = new[] {1,2,3,5 }; 
            Console.WriteLine("Triplet : " + CountTriplets.countGoodTriplets(arr, 7, 2, 3)); 




            Console.ReadKey();
        }

     
        


















    }
}
