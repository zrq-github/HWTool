using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Tool.Data
{
    public enum HWProductEnum
    {
        /// <summary>
        /// 建模大师(通用)
        /// </summary>
        CC = 0,
        /// <summary>
        /// 建模大师(建筑)
        /// </summary>
        AEC,
        /// <summary>
        /// 建模大师(机电)
        /// </summary>
        MEP,
        /// <summary>
        /// 建模大师PMEP
        /// </summary>
        PMEP,
        /// <summary>
        /// 建模大师(施工)
        /// </summary>
        CST,
        /// <summary>
        /// 装配式混凝土(PC)
        /// </summary>
        PC,
        /// <summary>
        /// 建模大师(精装)
        /// </summary>
        DEC,
        /// <summary>
        /// 建模大师(钢构)
        /// </summary>
        ST,
        /// <summary>
        /// 协同大师
        /// </summary>
        XT,
        /// <summary>
        /// 族库大师
        /// </summary>
        ZK,
        /// <summary>
        /// MaxiBIM
        /// </summary>
        MaxiBIM,
    }
}
