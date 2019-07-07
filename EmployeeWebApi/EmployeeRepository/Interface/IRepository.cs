using EmployeeEntities.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeRepository.Interface
{
    public interface IRepository<T> where T : IEntity
    {
        IEnumerable<T> List { get; }
        bool Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T FindById(int Id);

    }
}
