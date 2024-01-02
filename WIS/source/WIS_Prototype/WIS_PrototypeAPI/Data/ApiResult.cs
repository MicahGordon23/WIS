using Microsoft.EntityFrameworkCore;

namespace WIS_PrototypeAPI.Data
{
    public class ApiResult<T>
    {
        //******************************************
        // Properites
        public List<T> Data { get; private set; }

        // Zero-based index of current page
        public int PageIndex { get; private set; }

        // Number of items on each page
        public int PageSize { get; private set; }

        // Total number of pages
        public int TotalCount { get; private set; }

        // Total page count
        public int TotalPages { get; private set; }

        // True if current page has a previous page. Otherwise false
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return ((PageIndex + 1) < TotalPages);
            }
        }
        private ApiResult(List<T> data, int count, int pageIndex, int pageSize) 
        {
            Data = data;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = count;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        }
        
        //****************************************
        // Purpose: Creates an Api request to the 
        public static async Task<ApiResult<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            source = source.Skip(pageIndex * pageSize).Take(pageSize);
            var data = await source.ToListAsync();
            return new ApiResult<T>(data, count, pageIndex, pageSize);
        }
    }
}
