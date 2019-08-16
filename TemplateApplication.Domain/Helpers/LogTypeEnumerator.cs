using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TemplateApplication.Domain.Helpers
{
    public enum LogTypeEnumerator
    {
        [Description("Exception")]
        ExceptionLog = 1,

        [Description("Application")]
        ApplicationLog = 2
    }
}
