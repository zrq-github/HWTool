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
    public class PullFTPOperater
    {
        public PullFTPOperater()
        {
            FtpProductNames = FtpProducts.GetFtpProductNames();
        }

        /// <summary>
        /// </summary>
        /// <remarks> 类式的格式 ftp://192.168.0.210/ </remarks>
        public string FtpServerId { get; set; } = FtpServer.IP;

        private Dictionary<HWProductEnum, string> FtpProductNames { get; set; }

        /// <summary>
        /// 获取到产品的版本
        /// </summary>
        public IReadOnlyList<string> GetVersions(HWProductEnum productEnum)
        {
            List<string> strings = new();

            // 获取产品路径
            string? productPath = ProductPath(productEnum);
            if (null == productPath)
            {
                throw new InvalidOperationException("没有获取到FTP文件上的名字");
            }

            // 解析版本
            strings = GetFolderVersion(productPath);

            return strings;
        }

        public void Process()
        {
        }

        /// <summary>
        /// 获取到版本信息
        /// </summary>
        private List<string> GetFolderVersion(string requedstPath)
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
        /// 获取FTP上的文件名
        /// </summary>
        private string? ProductPath(HWProductEnum productEnum)
        {
            if (FtpProductNames.TryGetValue(productEnum, out string? ftpName))
            {
                string productPath = @$"{FtpServerId}{ftpName}/";
                return productPath;
            }
            return null;
        }
    }
}
