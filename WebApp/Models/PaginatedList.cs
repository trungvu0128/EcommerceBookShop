using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class PaginatedList<T> : List<T>
    {
        public PaginatedList(List<T> items,int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            Totalpages = (int)Math.Ceiling(Count / (double)pageSize);
            this.AddRange(items);
        }

        public int PageIndex { get; set; }
        public int Totalpages { get; set; }
        public bool PreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get
            {
                return (PageIndex < Totalpages);
            }
        }
        public static async Task<PaginatedList<T>> CreateAsync (IQueryable<T> source , int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }
    }
}
