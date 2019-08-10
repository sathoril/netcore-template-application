using System;

namespace TemplateApplication.Domain.Entities
{
    public class BaseEntity
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
    }
}
