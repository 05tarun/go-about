using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIApplication.Implementation;
using DIApplication.InterceptionBehaviors;
using DIApplication.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DIApplication
{
    public class Bootstrapper
    {
        IUnityContainer _Container;

        public IUnityContainer Register()
        {
            var container = new UnityContainer();
#if UseConfiguration
            container.LoadConfiguration();
#else
            container.AddNewExtension<Interception>();
            container.RegisterType<IObjectBase, ObjectBase>(
                new Interceptor<InterfaceInterceptor>(),
                new InterceptionBehavior<LoggingInterceptionBehavior>(),
                new InterceptionBehavior<CachingInterceptionBehavior>(),
                new InjectionConstructor(typeof(string), typeof(string), typeof(string)));
#endif
            _Container = container;

            return container;
        }
    }
}
