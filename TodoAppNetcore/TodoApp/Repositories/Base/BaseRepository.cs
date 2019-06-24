using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApp.Entities;
using TodoApp.Models;

namespace TodoApp.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {

        protected TodoAppContext DataContext { get; set; }

        //constructor
        public BaseRepository(TodoAppContext entities)
        {
            DataContext = entities;
        }
        //call DataContext
        public TodoAppContext DbContext
        {
            get { return DataContext; }
        }
        public TodoAppContext GetDbContext()
        {
            return DbContext;
        }
        #region Get

        public IQueryable<T> GetAll()
        {
            return DataContext.Set<T>().Where(i => !i.RecordDeleted).OrderBy(i => i.RecordOrder);
        }

        public async Task<T> GetByIdAsync(Guid? id)
        {
            return await DataContext.Set<T>().FirstOrDefaultAsync(i => i.Id == id);
        }

        #endregion

        #region Post

        public async Task<ResponseModel> InsertAsync(T entity)
        {
            var response = new ResponseModel();

            var dbSet = DataContext.Set<T>();
            dbSet.Add(entity);
            await DataContext.SaveChangesAsync();
            response.Data = entity;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        #endregion

        #region Put
        public async Task<ResponseModel> UpdateAsync(T entity)
        {
            var response = new ResponseModel();
            entity.UpdatedOn = DateTime.UtcNow;

            await DataContext.SaveChangesAsync();
            response.Data = entity;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        public async Task<ResponseModel> SetRecordDeletedAsync(T entity)
        {
            var response = new ResponseModel();
            entity.DeletedOn = DateTime.UtcNow;
         //   entity.DeletedBy = entity.Id;
            entity.RecordDeleted = true;
            await DataContext.SaveChangesAsync();
            response.Data = entity;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        #endregion

        #region Delete

        public async Task<ResponseModel> DeleteAsync(T entity)
        {
            var response = new ResponseModel();

            var dbSet = DataContext.Set<T>();
            dbSet.Remove(entity);
            await DataContext.SaveChangesAsync();
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return response;
        }
        #endregion
    }
}
