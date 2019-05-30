// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Startup.cs" company="SS">
//   Copyright © SS. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using Host.Owin;
using Infrastructure;
using Infrastructure.ApiDocumentation;
using Infrastructure.Exception;
using Infrastructure.Host;
using Infrastructure.Host.Contracts;
using Infrastructure.Interception.Contract;
using Infrastructure.SessionManagement;
using Microsoft.Owin;
using OnlineCourse.Api;
using OnlineCourse.Api.ApiDocumentation;
using Owin;

[assembly: OwinStartup(typeof(Startup))]

namespace OnlineCourse.Api
{
	/// <summary>
    ///     The startup.
    /// </summary>
    public class Startup : IStartup, IAppStartup
    {
        /// <summary>
        /// The configuration.
        /// </summary>
        /// <param name="app">
        /// The app.
        /// </param>
        public void Configuration(IAppBuilder app)
        {
            var config = this.GetInjectionConfiguration();
            //  config.Services.Replace(typeof(System.Web.Http.ExceptionHandling.IExceptionHandler), new PassthroughException());
            BootstrapperWebApi bootstrapperWebApi = (BootstrapperWebApi)this.GetBootstrapperWebApi(config);

            bootstrapperWebApi.Initialize(true).EnableLogging().DisableWebApiDefaultExceptionHandler();

            //.EnableTransaction();

            /*var container = ServiceLocator.Instance.Current;
            container.RegisterInterceptors();*/

            MappingConfig.RegisterMapping();
            ////WebApiODataConfig.Register(config); //ToDo we will uncomment this again when OData is not supported in web api
            WebApiConfig.Register(config);

            //SecurityConfig.Register(app, bootstrapperWebApi.DependencyResolver);
            //SecurityConfig.RegisterRequestThrottling(app, bootstrapperWebApi.DependencyResolver);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);


            app.UseDependencyInjectorMiddleware(bootstrapperWebApi.DependencyResolver);

            app.UseCorrelationIdInjector();

            app.UseRequestMiddleware();

            app.UseOwinExceptionHandler<ApiExceptionConfiguration>();

            //DbInitializer dbInitializer = bootstrapperWebApi.DependencyResolver.Resolve<DbInitializer>();

            //Database.SetInitializer<OnlineCourseContext>(dbInitializer);
            //AutoMapperConfig.RegisterMappings();

            this.ConfigurationExtension(config, bootstrapperWebApi.DependencyResolver);

            var handler = bootstrapperWebApi.DependencyResolver.Resolve<RequestHandler>();
            config.MessageHandlers.Add(handler);

            app.UseUnityWebApi(config);

            app.UseWebApi(config);

            SetConfigurationFromAppSettings();
        }

        private static void SetConfigurationFromAppSettings()
        {
            /*var instrumentationKey = ConfigurationManager.AppSettings["APPINSIGHTS_INSTRUMENTATIONKEY"];
            if (!string.IsNullOrEmpty(instrumentationKey))
            {
                TelemetryConfiguration.Active.InstrumentationKey = instrumentationKey;
            }*/

            /*if (EnvironmentInfo.IsDevelopmentMachine)
            {
                LogManager.Configuration.AddRule(NLog.LogLevel.Trace, NLog.LogLevel.Fatal, "asyncViewer");
                LogManager.Configuration.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, "asyncFile");
            }*/
        }

        /// <summary>
        /// The configuration extension.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="dependencyResolver">
        /// The dependency Resolver.
        /// </param>
        public virtual void ConfigurationExtension(HttpConfiguration config, IDependencyResolver dependencyResolver)
        {
            SwaggerConfig.Register(config, dependencyResolver, new ApiDocConfig());
        }



        /// <summary>
        /// The get bootstrapper web api.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <returns>
        /// The <see cref="IBootstrapper"/>.
        /// </returns>
        public virtual IBootstrapper GetBootstrapperWebApi(HttpConfiguration config)
        {
            var boostStrapperWebApi = new BootstrapperWebApi(config);
            return boostStrapperWebApi;
        }

        /// <summary>
        ///     The get injection configuration.
        /// </summary>
        /// <returns>
        ///     The <see cref="HttpConfiguration" />.
        /// </returns>
        public virtual HttpConfiguration GetInjectionConfiguration()
        {
            var configuration = new HttpConfiguration();
            return configuration;
        }
    }
}