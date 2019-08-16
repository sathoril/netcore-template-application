using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Domain.Validation
{
    public class ValidationError
    {
        public String Message { get; set; }

        public ValidationError(string fieldName)
        {
            this.Message = $"The field {fieldName} is invalid!";
        }
    }
}
