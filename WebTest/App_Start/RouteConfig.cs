using System.Web.Routing;

namespace WebTest.App_Start
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Default",
                "",
                "~/Test.aspx"
            );
        }
    }
}