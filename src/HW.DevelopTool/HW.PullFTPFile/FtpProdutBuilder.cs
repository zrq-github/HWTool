using HW.PullFTPFile.DB;
using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile
{
    /// <summary>
    /// FTP上对应的产品名字
    /// </summary>
    internal class FtpProdutBuilder
    {
        public static List<FtpProdut> FtpProduts { get; set; } = InitInternalFtpProduts();

        public FtpProdutBuilder()
        { }

        private static List<FtpProdut> InitInternalFtpProduts()
        {
            List<FtpProdut> ftpProduts = new();

            var produts = ProductBuilder.GetInternalProducts();
            foreach (var produt in produts)
            {
                FtpProdut ftpProdut = new((IProduct)produt)
                {
                    FtpName = GetFtpProductName(produt.Id),
                };
                ftpProduts.Add(ftpProdut);
            }
            return ftpProduts;
        }

        /// <summary>
        /// 获取Ftp上文件的名字
        /// </summary>
        /// <remarks>
        /// 就目前来说 ftp上的名字是由  BuildMaster(产品标识) 组成
        /// </remarks>
        public static string GetFtpProductName(string pId)
        {
            return $"BuildMaster({pId})";
        }
    }
}
