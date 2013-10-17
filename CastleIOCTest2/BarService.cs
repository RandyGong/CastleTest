using System;

namespace CastleIOCTest2
{
    public class BarService:IBar
    {
        public string BarSayString(string barString)
        {
            string ss = string.Format("BarString:{0}", barString);
            Console.WriteLine(ss);
            return ss;
        }
    }
}
