using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Entities;
using TodoApp.Models;

namespace TodoApp.Repositories.Base
{
    public interface IBaseRepository<T>
    {
        TodoAppContext GetDbContext();
        #region Get

        IQueryable<T> GetAll();
 
        Task<T> GetByIdAsync(Guid? id);

        #endregion

        #region Post
        Task<ResponseModel> InsertAsync(T entity);

        #endregion

        #region Put
        Task<ResponseModel> UpdateAsync(T entity);

        Task<ResponseModel> SetRecordDeletedAsync(T entity);
        #endregion

        #region Delete
        Task<ResponseModel> DeleteAsync(T entity);

        #endregion
    }
}
