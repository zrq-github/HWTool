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
        public PullProductModel(FtpProdut ftpProdct)
        {
            FtpProdct = ftpProdct;
        }

        public FtpProdut FtpProdct { get; }

        public string ShowName()
        {
            return $"{FtpProdct.Name} - {FtpProdct.Id}";
        }

        public override string ToString()
        {
            return ShowName();
        }
    }
}
