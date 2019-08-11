using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Domain.Entities.Validation;

namespace TemplateApplication.Domain.Services.Interfaces
{
    public interface IValidate
    {
        ValidationState Validate();
    }
}
