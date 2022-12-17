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
        public string Name { get; } = "拉包";

        private bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public void Init()
        {
            IsLoading = true;
            Thread.Sleep(2000);
            IsLoading = false;
        }

        private RelayCommand? pull;
        public ICommand Pull => pull ??= new RelayCommand(PerformPull);

        private void PerformPull()
        {
            MessageBox.Show(Application.Current.MainWindow, "拉包完成");
        }
    }
}
