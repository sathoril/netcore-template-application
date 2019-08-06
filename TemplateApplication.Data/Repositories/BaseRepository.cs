using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TemplateApplication.Data.Context;
using TemplateApplication.Data.Entities;
using TemplateApplication.Domain.Repositories.Interfaces;

namespace TemplateApplication.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : IDisposable
    {
        protected readonly DatabaseContext context;
        // TODO: Implement dbSet???
        // protected DbSet<T> dbSet;

        public BaseRepository(DatabaseContext context)
        {
            this.context = context;
            //this.dbSet = this.context.Set<T>();
        }

        public void Add(T entity)
        {
            this.context.Add(entity);
            this.context.SaveChanges();
        }

        public void AddList(List<T> entities)
        {
            this.context.Add(entities);
            this.context.SaveChanges();
        }

        public void Update(T entity)
        {
            this.context.Update(entity);
            this.context.SaveChanges();
        }
        public void UpdateList(List<T> entities)
        {
            this.context.Update(entities);
            this.context.SaveChanges();
        }

        // How to implement this method with Generic T entity
        public void ListActive()
        {
            //var dbSet = 


            //if (ativo.HasValue)
            //{
            //    var situacaoAtivoProp = dbSet.ElementType.GetMember("SituacaoAtivo");
            //    var ativoProp = dbSet.ElementType.GetMember("Ativo");

            //    // Se houver a propriedade ativo na entidade, a define como ativo ou false(geralmente vem de base própria)
            //    // se não, se houver a propriedade situacaoAtivo, define o valor como "A" para ativo ou "I" inativo
            //    if (ativoProp.Count() > 0)
            //        query = dbSet.Where("ativo = @0", ativo.Value ? "S" : "N");
            //    else if (situacaoAtivoProp.Count() > 0)
            //        query = dbSet.Where("situacaoAtivo = @0", ativo.Value ? "A" : "I");
            //}

            //return query;

            //this.context.Where(w => w.id);
        }
    }
}
