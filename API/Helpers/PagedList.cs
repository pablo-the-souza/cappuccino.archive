using System.Collections.Generic;
using System.Linq;

namespace API.Data.Helpers
{
    public class PagedList<T>: List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1; 
        //if currentpage > 1 hasprevious = true
        public bool HasNext => CurrentPage < TotalPages; 

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count; 
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)System.Math.Ceiling(count/(double)pageSize);
            AddRange(items);

            //AddRange adds collection instead of loop
        }

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize) 
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}