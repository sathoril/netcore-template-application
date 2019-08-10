using System;

namespace TemplateApplication.Data.Entities
{
    public class BaseEntity
    {
        public BaseEntity() => this.EntityCreated(); 

        public Int32 Id { get; private set; }
        public String CreationUser { get; private set; }
        public DateTime CreationDate { get; private set; }
        public String ModifiedUser { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public String Active { get; private set; }
        
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

        private void EntityModified()
        {
            this.ModifiedDate = DateTime.Now;
            this.ModifiedUser = Environment.UserName;
        }

        private void EntityCreated()
        {
            this.CreationDate = DateTime.Now;
            this.CreationUser = Environment.UserName;
            this.ActivateEntity();
        }
    }
}
