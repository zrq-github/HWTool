using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile.DB
{
    public class FtpProdut : IProduct
    {
        public FtpProdut()
        {

        }

        public FtpProdut(IProduct produt)
        {
            this.Id = produt.Id;
            this.Name= produt.Name;
        }

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Ftp产品的版本信息
        /// </summary>
        public List<FtpProductVersion> FtpVersions { get; set; } = new();

        /// <summary>
        /// FTP上的名字
        /// </summary>
        public string FtpName { get; set; } = string.Empty;
    }
}
