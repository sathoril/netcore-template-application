using System;

namespace TemplateApplication.Domain.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : IDisposable
    {
    }
}