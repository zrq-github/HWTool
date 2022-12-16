using System.Diagnostics;

namespace HW.Tool.Common
{
    public static class ProcessTool
    {
        /// <summary>
        /// 是否revit还在运行
        /// </summary>
        public static bool IsRevitRuning()
        {
            return IsRunning("Revit");
        }

        /// <summary>
        /// 程序是否正在运行
        /// </summary>
        public static bool IsRunning(in string processesName)
        {
            var processes = Process.GetProcessesByName(processesName);
            if (processes.Length > 0)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 是否XT还在运行
        /// </summary>
        /// <returns> </returns>
        public static bool IsXTRunning()
        {
            return IsRunning("HW.Collaborate.ClientApp");
        }
    }
}
