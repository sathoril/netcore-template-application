using System.Collections.Generic;
using TemplateApplication.Domain.Entities;
using TemplateApplication.Domain.Entities.Validation;
using TemplateApplication.Domain.Repositories.Interfaces;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public void Add(TEntity obj) 
        {
            ValidationState validation = obj.Validate();

            obj.EntityCreated();

            if (validation.HasErrors()) 
                return;

            this.repository.Add(obj);
        }

        public void Add(List<TEntity> objs)
        {
            this.repository.Add(objs);
        }

        public void Update(TEntity obj)
        {
            ValidationState validation = obj.Validate();

            if (validation.HasErrors())
                return;

            obj.EntityModified();
            this.repository.Update(obj);
        }

        public void Update(List<TEntity> objs)
        {
            foreach (var obj in objs)
            {
                obj.EntityModified();
            }

            this.repository.Update(objs);
        }

        public TEntity FindById(int id)
        {
            return this.repository.FindById(id);
        }

        public List<TEntity> ListActives()
        {
            return this.repository.ListActives();
        }
    }
}
