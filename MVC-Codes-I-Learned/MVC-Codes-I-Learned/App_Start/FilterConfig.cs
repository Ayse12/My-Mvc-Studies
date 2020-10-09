using System.Web;
using System.Web.Mvc;

namespace MVC_Codes_I_Learned
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
