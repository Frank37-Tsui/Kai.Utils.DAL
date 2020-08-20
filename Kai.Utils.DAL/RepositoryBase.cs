using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kai.Utils.DAL
{
    /// <summary>
/// 數據存取基類
/// </summary>
/// <typeparam name="T"></typeparam>
    public abstract class RepositoryBase<T> where T : class
    {
        /// <summary>
        /// 取得符合條件的資料
        /// </summary>
        /// <param name="predicate">符合條件</param>
        /// <returns>符合條件的內容</returns>
        public IEnumerable<T> Query(Expression<Func<T, bool>> predicate) => Query(predicate, 0, 0).Items;

        /// <summary>
        /// 取得符合條件的分頁資料
        /// </summary>
        /// <param name="sql">SQL語句</param>
        /// <param name="pageIdx">第幾頁(0:全部)</param>
        /// <param name="pageSize">每頁筆數(0全部)</param>
        /// <param name="args">SQL語句參數值</param>
        /// <returns>根據SQL撈出的內容</returns>
        public abstract PageData<T> Query(Expression<Func<T, bool>> predicate, int pageIdx, int pageSize);

        /// <summary>
        /// 取得符合條件的資料
        /// </summary>
        /// <param name="sql">SQL語句</param>
        /// <param name="args">SQL語句參數值</param>
        /// <returns>根據SQL撈出的內容</returns>
        public IEnumerable<T> Query(string sql, params object[] args) => Query(sql, 0, 0, args).Items;

        /// <summary>
        /// 取得符合條件的分頁資料
        /// </summary>
        /// <param name="sql">SQL語句</param>
        /// <param name="pageIdx">第幾頁(0:全部)</param>
        /// <param name="pageSize">每頁筆數(0:全部)</param>
        /// <param name="args">SQL語句參數值</param>
        /// <returns>根據SQL撈出的內容</returns>
        public abstract PageData<T> Query(string sql, int pageIdx, int pageSize, params object[] args);
        
        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns>所有的資料</returns>
        public abstract IEnumerable<T> GetAll();

        /// <summary>
        /// 新增一筆資料。
        /// </summary>
        /// <param name="entity">新增的實體</param>
        public abstract object Create(T entity);

        /// <summary>
        /// 更新一筆資料的內容。
        /// </summary>
        /// <param name="entity">更新的實體內容</param>
        public abstract void Update(T entity);

        /// <summary>
        /// 新增/更新一筆資料內容
        /// </summary>
        /// <param name="entity">新增/更新的內容</param>
        public abstract void Upsert(T entity);

        /// <summary>
        /// 新增/更新多筆資料內容
        /// </summary>
        /// <param name="entity">新增/更新的實體清單</param>
        public abstract void Upsert(IEnumerable<T> entity);

        /// <summary>
        /// 刪除一筆資料內容。
        /// </summary>
        /// <param name="entity">要被刪除的實體</param>
        public abstract void Delete(T entity);        
    }
}
