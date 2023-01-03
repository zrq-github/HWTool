using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.DevelopTool.Config
{
    /// <summary>
    /// 拉包的一些配置文件信息
    /// </summary>
    internal class PullConfig
    {
        public Dictionary<string, string> DownFilePaths { get; set; } = new();

        /// <summary>
        /// 最后选择的产品Id
        /// </summary>
        public string LastSelProductId { get; set; } = string.Empty;

        public string? GetDownFilePath(string key)
        {
            if (DownFilePaths.TryGetValue(key, out var path)) return path;

            return null;
        }

        public void SetDownFilePath(string key, string downFilePath)
        {
            DownFilePaths[key] = downFilePath;
        }
    }
}
