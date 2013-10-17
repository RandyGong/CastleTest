using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CastleIOCTest2
{
    public class InterceptorSelector: IInterceptorSelector
    {
    
        public IInterceptor[] SelectInterceptors(Type type, System.Reflection.MethodInfo method, IInterceptor[] interceptors)
        {
            // 如果是方法FunA
            if (method.Name == "FunA")
                return interceptors;
            return new IInterceptor[0];
            // ...
        }
    }
}
