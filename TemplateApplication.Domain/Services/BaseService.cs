using System;
using System.Collections.Generic;
using System.Text;
using TemplateApplication.Domain.Repositories.Interfaces;
using TemplateApplication.Domain.Services.Interfaces;

namespace TemplateApplication.Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly IBaseRepository<T> repository;

        public BaseService(IBaseRepository<T> repository)
        {
            this.repository = repository;
        }

        public void Add(T obj)
        {
            this.repository.Add(obj);
        }

        public void Add(List<T> objs)
        {
            this.repository.Add(objs);
        }

        public void Update(T obj)
        {
            this.repository.Update(obj);
        }

        public void Update(List<T> objs)
        {
            this.repository.Update(objs);
        }

        public List<T> ListActives()
        {
            return this.repository.ListActives();
        }
    }
}
