using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectProject.UI.Web.Areas.Admin.Data.DataAnnotations
{
    public class IsTrueRequired : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is bool)
            {
                return (bool)value;
            }

            return false;
        }
    }
}
