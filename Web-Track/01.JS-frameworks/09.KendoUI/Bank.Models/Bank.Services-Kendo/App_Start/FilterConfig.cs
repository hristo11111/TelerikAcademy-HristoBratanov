using System.Web;
using System.Web.Mvc;

namespace Bank.Services_Kendo
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}