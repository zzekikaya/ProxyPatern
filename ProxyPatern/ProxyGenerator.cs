using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace ProxyPatern
{
    public class ProxyGenerator<TInterface, TClass> : RealProxy
    {
        private ProxyGenerator() : base(typeof(TInterface))
        {

        }

        public static TInterface CreateProxy()
        {
            ProxyGenerator<TInterface, TClass> pg = new ProxyGenerator<TInterface, TClass>();
            return (TInterface)pg.GetTransparentProxy();

        }
        public override IMessage Invoke(IMessage msg)
        {
            //genel metot bilgileri.
            IMethodCallMessage mcm = (IMethodCallMessage)msg;
            //genel nesnenin instance oluşturulur
            object instance = Activator.CreateInstance(typeof(TClass));
            // attribute vrsa eğer bu şekilde kullanabiliyorsunuz.
            //object[] attrs = mcm.MethodBase.GetCustomAttributes(true);  
            object returnVal = mcm.MethodBase.Invoke(instance, mcm.Args); 
            return new ReturnMessage(returnVal, mcm.Args, mcm.ArgCount, mcm.LogicalCallContext, mcm);
        }
    }
}
