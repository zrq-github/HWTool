using HW.PullFTPFile.DB;
using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW.DevelopTool.Models
{
    /// <summary>
    /// 拉包工具的Model
    /// </summary>
    internal class PullProductModel
    {
        public PullProductModel()
        { }

        public PullProductModel(Product hwProduct)
        {
            Product = hwProduct;
        }

        /// <summary>
        /// 产品
        /// </summary>
        public Product Product { get; set; } = new();

        /// <summary>
        /// Ftp产品的版本信息
        /// </summary>
        public List<FtpProductVersion> FtpVersions { get; internal set; } = new();

        public string ShowName()
        {
            return $"{Product.Name} - {Product.Abbr}";
        }

        public override string ToString()
        {
            return ShowName();
        }
    }
}
