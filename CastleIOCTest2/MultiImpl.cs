using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleIOCTest2
{
    public class MultiImpl : InterfaceA, InterfaceB, InterfaceC
    {
        public void FunA()
        {
            throw new NotImplementedException();
        }

        public void FunB()
        {
            throw new NotImplementedException();
        }

        public void FunC()
        {
            throw new NotImplementedException();
        }
    }
}
