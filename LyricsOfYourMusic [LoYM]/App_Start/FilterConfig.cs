using System.Web;
using System.Web.Mvc;

namespace LyricsOfYourMusic__LoYM_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}