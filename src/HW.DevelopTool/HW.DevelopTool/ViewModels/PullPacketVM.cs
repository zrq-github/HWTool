using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZRQ.UI.UICommands;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels
{
    internal class PullPacketVM : ApplicationContentVM
    {
        private RelayCommand? _pull;
        private bool _isShowProgressBar = false;

        public override string Name { get; } = "拉包";

        /// <summary>
        /// 执行拉包流程
        /// </summary>
        public ICommand Pull => _pull ??= new RelayCommand(PerformPull);

        /// <summary>
        /// 是否显示进度条
        /// </summary>
        public bool IsShowProgressBar { get => _isShowProgressBar; set => SetProperty(ref _isShowProgressBar, value); }

        public override void Init()
        {
            base.Init();
            // 初始化拉包数据源;
        }

        private void PerformPull()
        {
            MessageBox.Show(Application.Current.MainWindow, "拉包完成");
        }
    }
}
