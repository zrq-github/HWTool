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
using static System.Net.WebRequestMethods;

namespace HW.PullFTPFile
{
    /// <summary>
    /// 获取包的所有流程
    /// </summary>
    public class PullProductsOperater
    {
        private FtpClient? _ftpClient;
        private IFtpServerConfig? _ftpServerConfig;

        public PullProductsOperater()
        {
            //FtpProductNames = FtpProdutBuilder.GetFtpProductNames();
        }

        /// <summary>
        /// 得到ftp上的名字
        /// </summary>
        /// <returns></returns>
        public List<FtpProdut> GetFtpProduts()
        {
            if (null == _ftpClient)
            {
                throw new InvalidOperationException($"{nameof(_ftpClient)}, 没有有被初始化");
            }

            _ftpClient.Connect();

            List<FtpProdut> ftpProduts = FtpProdutBuilder.FtpProduts;

            foreach (var ftpProduct in ftpProduts)
            {
                List<FtpProductVersion> ftpProductVersions = new();

                var ftpProductPath = ftpProduct.FtpName;
                var ftpDirPaths = _ftpClient.GetNameListing($"{ftpProductPath}").ToList();

                // 解析路径
                foreach (var ftpDirPath in ftpDirPaths)
                {
                    // 提取正确的版本文件夹, 存在log文件夹
                    if (ftpDirPath.ToLower().Contains("_log"))
                    {
                        continue;
                    }

                    string version = Path.GetFileName(ftpDirPath);
                    if (null == version) continue;

                    ftpProductVersions.Add(new()
                    {
                        Version = version,
                        VersionDirPath = ftpDirPath,
                    });

                    ftpProduct.FtpVersions = ftpProductVersions;
                }
            }
            _ftpClient.Disconnect();

            return ftpProduts.ToList();
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

        private void CheckInit()
        {
            if (null == _ftpClient)
            {
                throw new InvalidOperationException($"{nameof(_ftpClient)}, 没有有被初始化");
            }
            if (null == _ftpServerConfig)
            {
                throw new InvalidOperationException($"{nameof(_ftpServerConfig)}, 没有初始化");
            }
        }

        /// <summary>
        /// 下载产品, 默认下载最新的列表
        /// </summary>
        public void DownProduct(string ftpDirPath, string downDirPath, Action<FtpProgress> progress = null)
        {
            if (null == _ftpClient)
            {
                throw new InvalidOperationException($"{nameof(_ftpClient)}, 没有有被初始化");
            }

            bool dirExists = _ftpClient.DirectoryExists(ftpDirPath);
            if (!dirExists)
            {
                throw new InvalidOperationException($"{ftpDirPath}, 路径不存在");
            }

            try
            {
                _ftpClient.Connect();

                List<FtpListItem> ftpListItems = _ftpClient.GetListing(ftpDirPath).ToList();
                if (ftpListItems.Count == 0) return;

                // 按照创建的时间, 从近到远排序
                ftpListItems.Sort((a, b) =>
                {
                    return -a.Modified.CompareTo(b.Modified);
                });

                FtpListItem ftpListItem = ftpListItems[0];
                string downFileName = Path.Combine(downDirPath, ftpListItem.Name);

                _ftpClient.DownloadFile(@$"{downFileName}", $"{ftpListItem.FullName}", FtpLocalExists.Overwrite, FtpVerify.Retry, progress);

                //(FtpProgress ftpProgress) =>
                //{
                //    Debug.WriteLine(
                //        $"FileCount: {ftpProgress.FileCount} \n" +
                //        $"Progress: {ftpProgress.Progress} \n" +
                //        $"TransferSpeedToString: {ftpProgress.TransferSpeedToString()}");
                //}
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                _ftpClient.Disconnect();
            }
        }
    }
}
