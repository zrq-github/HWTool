using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.DevelopTool.Models
{
    /// <summary>
    /// 拉包工具的Model
    /// </summary>
    internal class PullPacketModel
    {
        public PullPacketModel() { }

        public PullPacketModel(HWProduct hwProduct)
        {
            HWProduct = hwProduct;
        }

        /// <summary>
        /// 产品
        /// </summary>
        public HWProduct HWProduct { get; set; } = new();

        public string FtpProductName { get; set; } = string.Empty;

        /// <summary>
        /// 产品的版本
        /// </summary>
        public ObservableCollection<string> Versions { get; set; } = new();

        public override string ToString()
        {
            return HWProduct.Name;
        }
    }
}
