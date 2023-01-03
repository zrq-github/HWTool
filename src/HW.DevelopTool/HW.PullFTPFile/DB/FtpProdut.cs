using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile.DB
{
    public class FtpProdut : IProduct, IEqualityComparer<FtpProdut>
    {
        public FtpProdut()
        {
        }

        public FtpProdut(IProduct produt)
        {
            this.Id = produt.Id;
            this.Name = produt.Name;
        }

        /// <summary>
        /// FTP上的名字
        /// </summary>
        public string FtpName { get; set; } = string.Empty;

        /// <summary>
        /// Ftp产品的版本信息
        /// </summary>
        public List<FtpProductVersion> FtpVersions { get; set; } = new();

        public string Id { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public bool Equals(FtpProdut? x, FtpProdut? y)
        {
            if (x == null || y == null) return false;

            return x.Id.Equals(y.Id);
        }

        public int GetHashCode([DisallowNull] FtpProdut obj)
        {
            return HashCode.Combine(Id);
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
