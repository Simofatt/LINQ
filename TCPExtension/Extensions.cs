using System;
using System.Collections.Generic;
using System.Text;

namespace TCPExtensions
{
    public static class Extensions
    {
        //FILTER METHOD IS DEFIFINED AS A EXTENSION METHOD FOR THE LIST<T>
        public static List<T> Filter<T>(this List<T> records, Func<T, bool> filter)
        {
            List<T> filtredList = new List<T>();
            foreach (T record in records)
            {
                if (filter(record))
                {
                    filtredList.Add(record);
                }
            }
            return filtredList;
        }

        public static int getNum(this int num)
        {
            return num;
        }
        // MAIN : 
        // num = 25 ; 
        // num.getNum() ; 


    }
}
