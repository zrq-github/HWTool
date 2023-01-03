using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Tool.Data
{
    /// <summary>
    /// 进度条
    /// </summary>
    public interface IProgress
    {
        /// <summary>
        /// 进度的消息
        /// </summary>
        public string Msg { get; set; }

        /// <summary>
        /// 进度的值
        /// </summary>
        public double Value { get; set; }
    }
}
