using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.Models
{
    internal class ProgressModel : ViewModelBase, IProgress
    {
        private string _msg = string.Empty;
        private double _value = 0;

        public string Msg { get => _msg; set => SetProperty(ref _msg, value); }

        public double Value { get => _value; set => SetProperty(ref _value, value); }
    }
}
