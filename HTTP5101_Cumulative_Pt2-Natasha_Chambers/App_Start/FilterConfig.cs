using System.Web;
using System.Web.Mvc;

namespace HTTP5101_Cumulative_Pt2_Natasha_Chambers
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
