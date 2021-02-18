using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IQueryable<T> GetAllQueryable();
        void Insert(T entity);

        int InsertAndReturnEntityId(T entity);

        void InsertRange(List<T> entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void SaveChanges(T entity);
    }
}
