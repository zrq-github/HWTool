using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Tool.Data
{
    public enum ProductEnum
    {
        /// <summary>
        /// 无效
        /// </summary>
        Invalid = -1,
        /// <summary>
        /// 建模大师(通用)
        /// </summary>
        [Description("建模大师(通用)")]
        CC = 0,
        /// <summary>
        /// 建模大师(建筑)
        /// </summary>
        [Description("建模大师(建筑)")]
        AEC,
        /// <summary>
        /// 建模大师(机电)
        /// </summary>
        [Description("建模大师(机电)")]
        MEP,
        /// <summary>
        /// 建模大师(PMEP)
        /// </summary>
        [Description("建模大师(PMEP)")]
        PMEP,
        /// <summary>
        /// 建模大师(施工)
        /// </summary>
        [Description("建模大师(施工)")]
        CST,
        /// <summary>
        /// 装配式混凝土(PC)
        /// </summary>
        [Description("装配式混凝土(PC)")]
        PC,
        /// <summary>
        /// 建模大师(精装)
        /// </summary>
        [Description("建模大师(精装)")]
        DEC,
        /// <summary>
        /// 建模大师(钢构)
        /// </summary>
        [Description("建模大师(钢构)")]
        ST,
        /// <summary>
        /// 协同大师
        /// </summary>
        [Description("建模大师(建筑)")]
        XT,
        /// <summary>
        /// 族库大师
        /// </summary>
        [Description("族库大师")]
        ZK,
        /// <summary>
        /// MaxiBIM
        /// </summary>
        [Description("MaxiBIM")]
        MaxiBIM,
    }
}
