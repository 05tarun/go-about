using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DIApplication.InterceptionBehaviors
{
    public class LoggingInterceptionBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Calling: " + input.MethodBase.Name);
            var methodReturn = getNext().Invoke(input, getNext);
            if (methodReturn.Exception != null)
                Console.WriteLine(input.MethodBase.Name + " threw exception: " + methodReturn.Exception.Message);
            else
                Console.WriteLine(input.MethodBase.Name + " returned " + methodReturn.ReturnValue);
            return methodReturn;
        }

        public bool WillExecute
        {
            get
            {
                return true;
            }
        }
    }
}
