using System;
using System.Collections.Generic;
using System.Text;

namespace Kai.Utils.DAL
{
    /// <summary>
    /// 分頁回傳結構
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageData<T> where T : class
    {
        /// <summary>
        /// 目前頁數
        /// </summary>
        public long CurrentPage { get; set; }
        /// <summary>
        /// 總頁數
        /// </summary>
        public long TotalPages { get; set; }
        /// <summary>
        /// 總筆數
        /// </summary>
        public long TotalItems { get; set; }
        /// <summary>
        /// 每頁筆數
        /// </summary>
        public long ItemsPerPage { get; set; }
        /// <summary>
        /// 回傳數據
        /// </summary>
        public List<T> Items { get; set; }
    }
}
