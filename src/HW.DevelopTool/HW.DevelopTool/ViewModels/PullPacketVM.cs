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
    internal class PullPacketVM : ViewModelBase, IApplicationContentVM
    {
        private bool _isLoading;
        private RelayCommand? pull;

        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public string Name { get; } = "拉包";

        /// <summary>
        /// 执行拉包流程
        /// </summary>
        public ICommand Pull => pull ??= new RelayCommand(PerformPull);

        public void Init()
        {
        }

        private void PerformPull()
        {
            MessageBox.Show(Application.Current.MainWindow, "拉包完成");
        }
    }
}
