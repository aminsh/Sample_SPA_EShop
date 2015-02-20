using System.Web.Http;
using App.Config;
using Core;
using DataAccess.RavenDB;
using Domain.Data;
using Domain.Service;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;

[assembly: OwinStartup(typeof(App.Startup))]

namespace App
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            
            config.MapHttpAttributeRoutes();

            Ioc.Register();
            config.DependencyResolver = new UnityResolver(DependencyManager.Container);
            
            app.UseWebApi(config);
            app.UseWelcomePage("/Index");
        }
    }
}
