using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Container;

namespace UnitTestProject1
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void RegisterAndResolveSimpleType()
        {
            var container = new Container.Container();

            container.Register<ICar>(c => new Car());

            var car = container.Resolve<ICar>();

            Assert.IsTrue(car is Car);
        }

        [TestMethod]
        public void RegisterAndResolveTypeWithNestedDependency()
        {
            var container = new Container.Container();

            container.Register<ICar>(c => new Car());
            container.Register<IEngine>(c => new Engine(c.Resolve<ICar>()));

            var car = container.Resolve<ICar>();
            var engine = container.Resolve<IEngine>();


        }


    }

    public interface ICar { }
    public interface IEngine { }
    public class Car : ICar { }
    public class Engine : IEngine
    {
        public ICar car = null;
        public string value = string.Empty;

        public Engine(ICar car)
        {
            this.car = car;
        }

        public Engine(ICar car, string value)
        {
            this.car = car;
            this.value = value;
        }
    }
}
