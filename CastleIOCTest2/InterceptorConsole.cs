using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleIOCTest2
{
    public class InterceptorConsole : IInterceptor
    {
        int calledCount = 0;

        public int GetCalledCount()
        {
            return calledCount;
        }

        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("invoke method: " + invocation.Method.Name);
            calledCount++;
            invocation.Proceed();
        }
    }
}
