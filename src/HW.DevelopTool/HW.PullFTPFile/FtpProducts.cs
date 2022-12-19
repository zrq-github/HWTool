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
        /// 获取产品名字的对应关系
        /// </summary>
        /// <returns></returns>
        public static Dictionary<HWProductEnum, string> GetFtpProductNames()
        {
            Dictionary<HWProductEnum, string> ftpProductNames = new()
            {
                {HWProductEnum.CC,"BuildMaster(CC)" },
                {HWProductEnum.AEC,"BuildMaster(AEC)" },
                {HWProductEnum.MEP,"BuildMaster(MEP)" },
                {HWProductEnum.PMEP,"BuildMaster(PMEP)" },
                {HWProductEnum.CST,"BuildMaster(CST)" },
                {HWProductEnum.PC,"BuildMaster(PC)" },
                {HWProductEnum.DEC,"BuildMaster(DEC)" },
                {HWProductEnum.ST,"BuildMaster(ST)" },
                {HWProductEnum.XT,"BuildMaster(XT)" },
                {HWProductEnum.ZK,"BuildMaster(ZK)" },
                {HWProductEnum.MaxiBIM,"BuildMaster(MaxiBIM)" },
            };
            return ftpProductNames;
        }
    }
}
