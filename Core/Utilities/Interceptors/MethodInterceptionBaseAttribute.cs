
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public virtual void Intercept(IInvocation invocation)
        {
        }
    }
}
