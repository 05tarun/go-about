using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIApplication.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DIApplication
{
    class Program
    {
        static IUnityContainer _Container;
        static void Main(string[] args)
        {
            var bootstrapper = new Bootstrapper();
            _Container = bootstrapper.Register();

            var obj = _Container.Resolve<IObjectType>(new ResolverOverride[] {new ParameterOverride("name", "Name1"), new ParameterOverride("code", "Code1"), new ParameterOverride("description", "Descripion of Code1") });
            var code = obj.GetCode();
            var desc = obj.GetDescription();

            Console.WriteLine("Received: ");
            Console.WriteLine(code);
            Console.WriteLine(desc);
            Console.ReadKey();
        }
    }
}
