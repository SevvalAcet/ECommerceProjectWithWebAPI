using Autofac;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Token.Jwt;
using Core.Utilities.Security.Token;
using Microsoft.Extensions.Localization;
using System.ComponentModel.Design;
using Business.Concrete;
using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Abstract;
using Autofac.Extras.DynamicProxy;

namespace Business.DependencyResolvers
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<JwtTokenService>().As<ITokenService>();
            builder.RegisterType<AuthApiService>().As<IAuthApiService>();
            builder.RegisterType<UserService>().As<IUserService>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterseptorSelector()
                }).SingleInstance();
        }
    }
}
