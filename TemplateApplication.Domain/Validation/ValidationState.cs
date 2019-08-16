using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Domain.Validation
{
    public class ValidationState
    {
        public List<ValidationError> ValidationErrors { get; set; }

        public ValidationState() { this.ValidationErrors = new List<ValidationError>(); }

        public Boolean HasErrors()
        {
            return this.ValidationErrors != null && this.ValidationErrors.Count > 0;
        }

        public void AddError(string fieldName)
        {
            this.ValidationErrors.Add(
                new ValidationError(fieldName));
        }
    }
}
