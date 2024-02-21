using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int categoryId) : base($"The category with the identifier {categoryId} was not found.")
        {
        }
    }
}
