using HW.DevelopTool.Models;
using HW.DevelopTool.Views;
using HW.PullFTPFile;
using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private bool _isShowProgressBar = false;
        private RelayCommand? _pull;
        private PullFTPOperater _ftpOperater = new();
        private object? selectPullProduct;

        public PullPacketVM()
        {
        }

        /// <summary>
        /// 是否显示进度条
        /// </summary>
        public bool IsShowProgressBar { get => _isShowProgressBar; set => SetProperty(ref _isShowProgressBar, value); }

        /// <summary>
        /// 拉包的数据源
        /// </summary>
        public ObservableCollection<PullPacketModel> PullPackets { get; set; } = new();

        /// <summary>
        /// 选择拉取的产品
        /// </summary>
        public object? SelectPullProduct { get => selectPullProduct; set => SetProperty(ref selectPullProduct, value); }

        #region Init

        public override string Name { get; } = "拉包";

        public override void Init()
        {
            if (this.IsInit) return;

            base.Init();

            var productDic = HWProductBuilder.GetHWProducts();

            // 初始化产品
            foreach (var product in productDic.Values)
            {
                PullPackets.Add(new(product));
            }

            // 初始化产品的版本信息
            foreach (var product in PullPackets)
            {
                try
                {
                    var versions = _ftpOperater.GetVersions(product.HWProduct.HWProductEnum);
                }
                catch (Exception)
                {

                }
                finally
                {

                }
            }
        }

        #endregion Init

        #region Perform - 执行

        /// <summary>
        /// 执行拉包流程
        /// </summary>
        public ICommand Pull => _pull ??= new RelayCommand(PerformPull);

        /// <summary>
        /// 执行拉包流程
        /// </summary>
        private void PerformPull()
        {
            IsShowProgressBar = true;
            MessageBox.Show(Application.Current.MainWindow, "拉包完成");
            IsShowProgressBar = false;
        }

        #endregion Perform - 执行
    }
}
