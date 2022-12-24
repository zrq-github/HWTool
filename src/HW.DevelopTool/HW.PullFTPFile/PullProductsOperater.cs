using FluentFTP;
using HW.PullFTPFile.DB;
using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HW.PullFTPFile
{
    /// <summary>
    /// FTP操作
    /// </summary>
    public class PullProductsOperater
    {
        private FtpClient? _ftpClient;
        private IFtpServerConfig? _ftpServerConfig;

        public PullProductsOperater()
        {
            FtpProductNames = FtpProducts.GetFtpProductNames();
        }

        /// <summary>
        /// 初始化Ftp
        /// </summary>
        public FtpClient InitFtp(IFtpServerConfig ftpServer)
        {
            // 如果ftp存在, 销毁重新创建
            _ftpClient?.AutoDispose();

            string username = ftpServer.Username;
            string password = ftpServer.Password;
            int port = ftpServer.Port;

            FtpConfig ftpConfig = new()
            {
                EncryptionMode = FtpEncryptionMode.None,
                ValidateAnyCertificate = true
            };
            _ftpClient = new(ftpServer.Host, username, password, port, ftpConfig);
            _ftpServerConfig = ftpServer;

            return _ftpClient;
        }

        private Dictionary<ProductEnum, string> FtpProductNames { get; set; } = new();

        /// <summary>
        /// 获取到产品的 版本 - 版本路径
        /// </summary>
        public List<FtpProductVersion> GetVersionPaths(ProductEnum productEnum)
        {
            if (null == _ftpClient)
            {
                throw new InvalidOperationException($"{nameof(_ftpClient)}, 没有有被初始化");
            }
            if (null == _ftpServerConfig)
            {
                throw new InvalidOperationException($"{nameof(_ftpServerConfig)}, 没有初始化");
            }
            if (!FtpProductNames.TryGetValue(productEnum, out string? ftpName))
            {
                throw new InvalidOperationException($"未找到产品的ftp目录");
            }

            List<FtpProductVersion> ftpProductVersions = new();

            _ftpClient.Connect();

            var ftpProductPath = $"/{ftpName}/";
            var ftpDirPaths = _ftpClient.GetNameListing($"{ftpProductPath}").ToList();

            // 解析路径
            foreach (var ftpDirPath in ftpDirPaths)
            {
                // 提取正确的版本文件夹, 存在log文件夹
                if (ftpDirPath.ToLower().Contains("_log"))
                {
                    continue;
                }

                string version = ftpDirPath.Substring(ftpProductPath.Length, ftpDirPath.Length - ftpProductPath.Length);
                if (null == version) continue;

                ftpProductVersions.Add(new()
                {
                    Version = version,
                    VersionDirPath = ftpDirPath,
                });
            }


            _ftpClient.Disconnect();

            return ftpProductVersions;
        }

        public void Process()
        {
        }

        /// <summary>
        /// 获取到版本信息
        /// </summary>
        private List<string> GetFolderVersionA(string requedstPath)
        {
            List<string> folder = new();
            try
            {
                HttpClient httpClient = new();

                FtpWebRequest reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(requedstPath));
                reqFTP.Credentials = new NetworkCredential();
                reqFTP.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                WebResponse response = reqFTP.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                try
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        if (!line.ToLower().Contains("log") && !line.ToLower().Contains("for"))
                        {
                            int vIndex = line.ToLower().IndexOf(" v");
                            string version = line.Substring(vIndex + 1);
                            try
                            {
                                var number = version.ToLower().Replace("v", "").Replace(".", "");
                                if (int.TryParse(number, out int versionNum))
                                {
                                    folder.Add(version);
                                }
                                Console.WriteLine(version);
                            }
                            catch (Exception)
                            {
                            }
                        }
                        line = reader.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                finally
                {
                    reader.Close();
                    response.Close();
                }
            }
            catch (Exception ex)
            {
                //System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return folder;
        }

        /// <summary>
        /// 获取FTP上产品路径
        /// </summary>
        private string? GetFtpProductPath(ProductEnum productEnum)
        {
            if (FtpProductNames.TryGetValue(productEnum, out string? ftpName))
            {
                string productPath = @$"{_ftpServerConfig.Host}{ftpName}/";
                return productPath;
            }
            return null;
        }
    }
}
