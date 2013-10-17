using Castle.Core.Resource;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using System;

namespace CastleIOCTest2
{
    class Program
    {
        static void Main(string[] args)
        {
            //建立容器
            IWindsorContainer container = new WindsorContainer(new XmlInterpreter(new ConfigResource()));
            //IWindsorContainer container = new WindsorContainer();
            //获取组件(通过装载的Key,在以后的版本中可以通过接口类型来解析)
            var fooService = container.Resolve(typeof(IFoo)) as IFoo;
            //使用组件
            fooService.FooSay("First Castle IOC Demo");

            //container.AddFacility("startable", new Castle.Facilities.Startable.StartableFacility());
            //container.AddComponent("startableclass", typeof(StartableClass));
            //container.AddComponent("startabledenclass", typeof(StartableDependClass));

            container.AddFacility(new Castle.Facilities.Startable.StartableFacility());
            container.Register(Component.For(typeof(StartableClass)));
            container.Register(Component.For(typeof(StartableDependClass)));

            Console.ReadKey();
        }
    }
}
