using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Data.Entities
{
    public class BaseEntity
    {
        public Int32 Id { get; private set; }
        public String CreationUser { get; private set; }
        public DateTime CreationDate { get; private set; }
        public String ModifiedUser { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        public Boolean Active { get; private set; }

        public void InactivateEntity()
        {
            this.Active = false;
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
        }
    }
}
