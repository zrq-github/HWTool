using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile
{
    public class FtpServerConfig : IFtpServerConfig
    {
        //public static string IP { get; set; } = @"ftp://192.168.0.210/";
        public string Host { get; set; } = string.Empty;
        public int Port { get; set; } = 21;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// 创建一个默认的配置
        /// </summary>
        public static FtpServerConfig FtpProductsConfig()
        {
            FtpServerConfig config = new()
            {
                Host = @"192.168.0.210",
                Port = 21,
                Username = "hwclient",
                Password = "hw_ftpa206",
            };
            return config;
        }
    }
}
