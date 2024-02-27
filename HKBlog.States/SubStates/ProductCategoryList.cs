using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ProductCategoryList
    {
        public IReadOnlyList<string> Categories { get; }
        public ProductCategoryList(List<string> categories)
        {
            Categories = categories.AsReadOnly();
        }
    }
}
