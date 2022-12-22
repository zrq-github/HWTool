using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile.DB
{
    public class FtpProductVersion
    {
        public FtpProductVersion() { }

        /// <summary>
        /// 版本的名字
        /// </summary>
        public string Version { get; set; } = string.Empty;

        /// <summary>
        /// 版本路径
        /// </summary>
        public string VersionDirPath { get; set; } = string.Empty;
    }
}
