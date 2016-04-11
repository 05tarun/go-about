using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace DIApplication.InterceptionBehaviors
{
    public class CachingInterceptionBehavior : IInterceptionBehavior
    {
        long _Counter = 0;
        IDictionary<long, string> _Cache = new Dictionary<long, string>();

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var methodReturn = getNext().Invoke(input, getNext);
            if (methodReturn.Exception == null)
                _Cache.Add(Interlocked.Increment(ref _Counter), methodReturn.ReturnValue as string);
            Console.WriteLine("Cache has " + _Counter + (_Counter > 1 ? " objects" : " object"));
            foreach (var entry in _Cache)
                Console.WriteLine(entry.Key + ": " + entry.Value);
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
