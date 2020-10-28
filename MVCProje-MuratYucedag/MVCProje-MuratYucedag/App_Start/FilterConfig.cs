using System.Web;
using System.Web.Mvc;

namespace MVCProje_MuratYucedag
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
