using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArchitectProject.UI.Web.Enum
{
    public enum NotificationType
    {
        [Description("ERRO")]
        error,
        [Description("CONCLUÍDO")]
        success,
        [Description("ATENÇÃO")]
        warning,
        [Description("INFO")]
        info
    }
}
