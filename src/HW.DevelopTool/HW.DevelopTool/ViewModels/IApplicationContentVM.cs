using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HW.DevelopTool.ViewModels
{
    internal interface IApplicationContentVM
    {
        /// <summary>
        /// 是否正在加载
        /// </summary>
        bool IsLoading { get; set; }

        /// <summary>
        /// 视图的名字
        /// </summary>
        string Name { get; }

        /// <summary>
        /// 加载提示
        /// </summary>
        string LoadingTips { get; set; }

        /// <summary>
        /// 是否正在初始化
        /// </summary>
        void Init();
    }
}
