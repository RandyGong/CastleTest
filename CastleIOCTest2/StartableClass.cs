
using Castle.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleIOCTest2
{
    class StartableClass : IStartable
    {
        private StartableDependClass den;

        public StartableClass(StartableDependClass c)
        {
            den = c;
        }

        public void Start()
        {
            Console.WriteLine("StartableClass starts");
        }

        public void Stop()
        {
            Console.WriteLine("StartableClass stops");
        }
    }
}
