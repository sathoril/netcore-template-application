using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateApplication.Domain.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        void Add(T obj);
        void Add(List<T> objs);
        void Update(T obj);
        void Update(List<T> obj);
        List<T> ListActives();
    }
}
