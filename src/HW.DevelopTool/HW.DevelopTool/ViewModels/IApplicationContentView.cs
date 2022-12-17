using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.DevelopTool.ViewModels
{
    interface IApplicationContentVM
    {
        string Name { get; }

        bool IsLoading { get; set; }

        void Init();
    }
}
