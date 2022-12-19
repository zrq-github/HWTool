using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile
{
    /// <summary>
    /// FTP上对应的产品名字
    /// </summary>
    internal class FtpProducts
    {
        private static readonly Dictionary<HWProductEnum, string> ftpProductNames = GetFtpProductNames();

        public FtpProducts()
        { }

        /// <summary>
        /// Ftp产品的名字
        /// </summary>
        public static Dictionary<HWProductEnum, string> FtpProductNames => ftpProductNames;

        /// <summary>
        /// 获取Ftp上文件的名字
        /// </summary>
        /// <remarks>
        /// 就目前来说 ftp上的名字是由  BuildMaster(产品缩写) 组成
        /// </remarks>
        public static string GetFtpProductName(HWProductEnum product)
        {
            return $"BuildMaster({product.ToString()})";
        }

        /// <summary>
        /// 获取产品名字的对应关系
        /// </summary>
        /// <returns></returns>
        public static Dictionary<HWProductEnum, string> GetFtpProductNames()
        {
            Dictionary<HWProductEnum, string> ftpProductNames = new();

            foreach (HWProductEnum product in Enum.GetValues(typeof(HWProductEnum)))
            {
                ftpProductNames[product] = GetFtpProductName(product);
            }

            return ftpProductNames;
        }
    }
}
