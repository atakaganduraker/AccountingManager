using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {


            builder.RegisterType<CompanyManager>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>().SingleInstance();

            builder.RegisterType<OperationManager>().As<IOperationService>().SingleInstance();
            builder.RegisterType<EfOperationDal>().As<IOperationDal>().SingleInstance();
          
            builder.RegisterType<CaseManager>().As<ICaseService>().SingleInstance();
            builder.RegisterType<EfCaseDal>().As<ICaseDal>().SingleInstance();

            builder.RegisterType<CaseRatioManager>().As<ICaseRatioService>().SingleInstance();
            builder.RegisterType<EfCaseRatioDal>().As<ICaseRatioDal>().SingleInstance();

            builder.RegisterType<CurrencyManager>().As<ICurrencyService>().SingleInstance();
            builder.RegisterType<EfCurrencyDal >().As<ICurrencyDal>().SingleInstance();


            builder.RegisterType<OperationCaseManager>().As<IOperationCaseService>().SingleInstance();
            builder.RegisterType<EfOperationCaseDal >().As<IOperationCaseDal>().SingleInstance();


            builder.RegisterType<OperationDetailManager>().As<IOperationDetailService>().SingleInstance();
            builder.RegisterType<EfOperationDetailDal>().As<IOperationDetailDal>().SingleInstance();

            builder.RegisterType<OperationTypeManager>().As<IOperationTypeService>().SingleInstance();
            builder.RegisterType<EfOperationTypeDal>().As<IOperationTypeDal>().SingleInstance();

            builder.RegisterType<RatioManager>().As<IRatioService>().SingleInstance();
            builder.RegisterType<EfRatioDal>().As<IRatioDal>().SingleInstance();



            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }



}
