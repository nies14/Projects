using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Routing;
using TutorSeekerData;

namespace TutorSeeker
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<TutorSeekerDbContext>());
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
