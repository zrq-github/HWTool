using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile.DB
{
    /// <summary>
    /// Ftp产品信息
    /// </summary>
    class FtpProduct
    {
        public FtpProduct() { }

        public HWProduct HWProduct { get; set; } = new();
    }
}
