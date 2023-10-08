using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.Algorithms
{
    public static class LenghtOfTheLongestSubString
    {
        public static int LengthOfLongestSubstring(string s)
        {

            // s = "abcabcbb";
            Dictionary<char, int> map = new Dictionary<char, int>();
            int count = 0;
            var countOfSubString = 0;

            for (var i = 0; i < s.Length; i++)
            {
                char cur = s[i];


                if (map.ContainsKey(cur))
                {
                    if (cur.Equals(s[i - 1]))
                    {
                        count = 1;
                    }
                    else
                    {

                        count = 2;
                    }


                }
                else
                {
                    count++;
                    map.Add(cur, count);
                }



            }
            foreach (var value in map)
            {

                if (value.Value > countOfSubString)
                {
                    countOfSubString = value.Value;
                }

            }
            return countOfSubString;
        }
    }
}
