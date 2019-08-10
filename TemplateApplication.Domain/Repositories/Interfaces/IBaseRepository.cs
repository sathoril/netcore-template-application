using System;
using System.Collections.Generic;

namespace TemplateApplication.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);
        void Add(List<T> objs);
        void Update(T obj);
        void Update(List<T> obj);
        T FindById(int id);
        List<T> ListActives();
    }
}