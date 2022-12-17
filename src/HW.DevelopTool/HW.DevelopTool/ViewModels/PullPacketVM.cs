using HW.DevelopTool.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.DevelopTool.ViewModels
{
    internal class PullPacketVM : ViewModelBase, IApplicationContentVM
    {
        public string Name { get; } = "拉包";
        public bool IsLoading { get; set; } = false;

        public void Init()
        {
        }
    }
}
