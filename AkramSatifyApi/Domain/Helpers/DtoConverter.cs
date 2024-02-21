using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class DtoConverter
    {
        public static PagedList<TDto> ConvertToPagedList<T, TDto>(PagedList<T> source, Func<T, TDto> mapFunc)
        {
            var dtos = source.Select(mapFunc).ToList();
            return new PagedList<TDto>(dtos, source.TotalCount, source.CurrentPage, source.PageSize);
        }
    }
}
