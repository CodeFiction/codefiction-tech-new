using Microsoft.AspNetCore.Mvc.Rendering;

namespace Codefiction.CodefictionTech.CodefictionApi.Server.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static bool IsDebug(this IHtmlHelper<dynamic> htmlHelper)
        {
#if DEBUG
            return true;
#else
            return false;
#endif
        }
    }
}