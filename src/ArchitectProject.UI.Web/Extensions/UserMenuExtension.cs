using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Mvc
{
    public static class UserMenuExtension
    {
        //public static bool IsMenuActive(this IHtmlHelper htmlHelper, string menuItemUrl)
        //{
        //    var viewContext = htmlHelper.ViewContext;
        //    var currentPageUrl = viewContext.ViewData["ActiveMenu"] as string ?? viewContext.HttpContext.Request.Path;
        //    return currentPageUrl.StartsWith(menuItemUrl, StringComparison.OrdinalIgnoreCase);
        //}

        public static bool IsMenuActive(this IHtmlHelper htmlHelper, string menuItemUrl, bool isUniqueLink)
        {
            var viewContext = htmlHelper.ViewContext;
            var currentPageUrl = viewContext.ViewData["ActiveMenu"] as string ?? viewContext.HttpContext.Request.Path;

            if (!isUniqueLink)
                return currentPageUrl.StartsWith(menuItemUrl, StringComparison.OrdinalIgnoreCase);

            return currentPageUrl.Equals(menuItemUrl, StringComparison.OrdinalIgnoreCase);
        }
    }
}
