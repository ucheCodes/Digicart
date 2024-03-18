using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKBlog.States.SubStates
{
    public class ShowUploadClicker
    {
        public bool ShowUpload { get; set; } = false;
        public ShowUploadClicker(bool showUpload) 
        { 
            ShowUpload = showUpload;
        }  
    }
}
