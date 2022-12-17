using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels
{
    internal class PullPacketVM : ViewModelBase, IApplicationContentVM
    {
        public string Name { get; } = "拉包";
        public bool IsLoading { get; set; } = false;

        public ICommand PullCommand { get; set; }

        public void Init()
        {
        }
    }
}
