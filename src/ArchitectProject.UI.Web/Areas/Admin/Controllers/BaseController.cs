using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using ArchitectProject.UI.Web.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArchitectProject.UI.Web.Areas.Admin.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        [Route("action")]
        public void Alert(string message, NotificationType notificationType)
        {
            var msg = "<script language='javascript'>swal('" + ToDescriptionString(notificationType) + "', '" + message + "','" + notificationType + "')" + "" + "</script>";
            TempData["notification"] = msg;
        }

        [Route("action")]
        public string ToDescriptionString(NotificationType notificationType)
        {
            DescriptionAttribute[] attributes = (DescriptionAttribute[])notificationType
               .GetType()
               .GetField(notificationType.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
    }
}