using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ProjectName
    {
        public string Name { get; } = "Shop Now";
        public ProjectName(string name)
        {
            Name = name;
        }
    }
}
