using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using CastleIOCTest2;
using Castle.Core.Resource;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Registration;
using Castle.Core;

namespace CastleUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //建立容器
            //IWindsorContainer container = new WindsorContainer(new XmlInterpreter(new ConfigResource()));
            IWindsorContainer container = new WindsorContainer();
            container.Install(Configuration.FromAppConfig());
            //获取组件(通过装载的Key,在以后的版本中可以通过接口类型来解析)
            var fooService = container.Resolve(typeof(IFoo)) as IFoo;
            //使用组件
            string ret = fooService.FooSay("First Castle IOC Demo");

            Assert.AreEqual(ret, "BarString:[abc:First Castle IOC Demo]");
        }

        [TestMethod]
        public void TestMultiImpl()
        {
            var container = new WindsorContainer();
            container.Register(Component.For<InterfaceA>().ImplementedBy<MultiImpl>().Forward<InterfaceB>().Forward<InterfaceC>());

            var objA = container.Resolve<InterfaceA>();
            var objB = container.Resolve<InterfaceB>();
            var objC = container.Resolve<InterfaceC>();

            Assert.AreSame(objA, objB);
            Assert.AreSame(objB, objC);
        }

        [TestMethod]
        public void TestAOP()
        {
            var container = new WindsorContainer();
            container.Register(
                Component.For<IInterceptorInterface>().
                ImplementedBy<InterceptorImpl>().Interceptors(InterceptorReference.ForType<InterceptorConsole>()).Anywhere,
                Component.For<InterceptorConsole>()
                );

            var foo = container.Resolve<IInterceptorInterface>();

            foo.FunA();
            foo.FunB();
            foo.FunA();
            foo.FunB();

            var callCount = container.Resolve<InterceptorConsole>().GetCalledCount();

            Assert.AreEqual(4, callCount);
        }

        [TestMethod]
        public void TestAopByFilter()
        {
            var container = new WindsorContainer();

            container.Register(
                Component.For<IInterceptorInterface>().
                ImplementedBy<InterceptorImpl>().Interceptors(InterceptorReference.ForType<InterceptorConsole>()).SelectedWith(new InterceptorSelector()).Anywhere,
                Component.For<InterceptorConsole>()
                );

            var foo = container.Resolve<IInterceptorInterface>();

            foo.FunA();
            foo.FunB();
            foo.FunA();
            foo.FunB();

            var callCount = container.Resolve<InterceptorConsole>().GetCalledCount();

            Assert.AreEqual(2, callCount);
        }
    }
}
