using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData.Batch;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Formatter;
using Domain.Model;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(App.Startup))]

namespace App
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888

            var config = new HttpConfiguration();
            var modelBuilder = new ODataConventionModelBuilder();

            modelBuilder.EntitySet<User>("Users");
            modelBuilder.EntitySet<Order>("Orders");
            modelBuilder.EntitySet<OrderDetail>("OrderDetails");
            modelBuilder.EntitySet<Product>("Products");

            var server = new HttpServer(config);

            var model = modelBuilder.GetEdmModel();

            ODataBatchHandler batchHandler = new DefaultODataBatchHandler(server);

           config.Routes.MapODataServiceRoute("odata", "odata", model, batchHandler);

            config.AddODataQueryFilter();

           config.Formatters.InsertRange(0, ODataMediaTypeFormatters.Create());

           //config.Routes.MapHttpRoute(
           //    name: "DefaultApi",
           //    routeTemplate: "api/{controller}/{id}",
           //    defaults: new { id = RouteParameter.Optional }
           //);

            config.MapHttpAttributeRoutes();


            app.UseWebApi(config);
            app.UseWelcomePage("/Index");
        }
    }
}
