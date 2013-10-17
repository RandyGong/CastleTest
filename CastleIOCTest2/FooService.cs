using System;

namespace CastleIOCTest2
{
    public class FooService:IFoo
    {
        private string _fooString;
        private IBar _bar;
        public FooService(string fooString,IBar bar)
        {
            _fooString = fooString;
            _bar = bar;
        }

        public string FooSay(string foostring)
        {
            var foostringInstead = _fooString.Replace("$", foostring);
            return _bar.BarSayString(foostringInstead);
        }
    }
}
