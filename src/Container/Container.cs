﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container
{
    public class Container
    {
        Dictionary<Type, object> factories = new Dictionary<Type, object>();
        public void Register<TService>(Func<Container, TService> factory)
        {
            factories.Add(typeof(TService), factory);
        }

        public TService Resolve<TService>()
        {
            return (TService)((Func<Container, TService>)factories[typeof(TService)]).Invoke(this);
        }
    }
}
