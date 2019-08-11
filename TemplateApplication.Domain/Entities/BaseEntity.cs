using System;
using System.Collections.Generic;
using System.Reflection;
using TemplateApplication.Domain.Entities.Validation;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.Domain.Entities
{
    public class BaseEntity : IValidate
    {
        public BaseEntity() { }

        public Int32 Id { get; set; }
        public String CreationUser { get; set; }
        public DateTime CreationDate { get; set; }
        public String ModifiedUser { get; set; }
        public DateTime ModifiedDate { get; set; }
        public String Active { get; set; }

        public void InactivateEntity()
        {
            this.Active = "I";  
            this.EntityModified();
        }

        public void ActivateEntity()
        {
            this.Active = "A";
            this.EntityModified();
        }

        public void EntityModified()
        {
            this.ModifiedDate = DateTime.Now;
            this.ModifiedUser = Environment.UserName;
        }

        public void EntityCreated()
        {
            this.CreationDate = DateTime.Now;
            this.CreationUser = Environment.UserName;
            this.ActivateEntity();
        }

        /// Implements simple validation, for example:
        /// Property is of type Int32, so it can not be 0 or property is of type String can not be null or empty
        /// It can be overrided on other classes that inherits BaseEntity
        public ValidationState Validate()
        {
            ValidationState validation = new ValidationState();
                
            foreach (var field in this.GetType().GetProperties())
            { 
                switch (field.PropertyType.Name)
                {
                    case "Int32":
                        if (Convert.ToInt32(this.GetType().GetProperty(field.Name).GetValue(this, null)) == 0)
                            validation.AddError(field.Name);
                        break;
                    case "String":
                        if (String.IsNullOrEmpty(Convert.ToString(this.GetType().GetProperty(field.Name).GetValue(this, null))))
                            validation.AddError(field.Name);
                        break;
                    case "DateTime":
                        if (Convert.ToDateTime(this.GetType().GetProperty(field.Name).GetValue(this, null)) == DateTime.MinValue)
                            validation.AddError(field.Name);
                        break;
                }
            }

            return validation;
        }
    }
}
