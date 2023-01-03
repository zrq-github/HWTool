using FluentFTP;
using HW.DevelopTool.Config;
using HW.DevelopTool.Models;
using HW.DevelopTool.Views;
using HW.PullFTPFile;
using HW.PullFTPFile.DB;
using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ZRQ.UI.UICommands;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels
{
    internal class PullProductVM : ApplicationContentVM
    {
        public PullProductVM()
        {
        }

        #region BindingPropertys

        private string? _downFilePath = string.Empty;
        private PullProductsOperater _ftpOperater = new();
        private bool _isShowProgressBar = false;
        private string _productVersion = string.Empty;
        private List<string> _productVersions = new();
        private double _progressValue;
        private RelayCommand? _pull;
        private List<FtpProdut> _pullProducts = new();
        private FtpProdut? _selFtpProdut;
        private FtpProductVersion? _selFtpVersion;

        /// <summary>
        /// 解压路径
        /// </summary>
        public string? DownFilePath { get => _downFilePath; set => SetProperty(ref _downFilePath, value); }

        /// <summary>
        /// 是否显示进度条
        /// </summary>
        public bool IsShowProgressBar { get => _isShowProgressBar; set => SetProperty(ref _isShowProgressBar, value); }

        /// <summary>
        /// 产品的版本
        /// </summary>
        public string ProductVersion { get => _productVersion; set => SetProperty(ref _productVersion, value); }

        /// <summary>
        /// 后选的产品版本
        /// </summary>
        public List<string> ProductVersions { get => _productVersions; set => SetProperty(ref _productVersions, value); }

        /// <summary>
        /// 进度信息
        /// </summary>
        public IProgress Progress { get; set; } = new ProgressModel();

        public double ProgressValue { get => _progressValue; set => SetProperty(ref _progressValue, value); }

        /// <summary>
        /// 拉包的数据源
        /// </summary>
        public List<FtpProdut> PullProducts { get => _pullProducts; set => SetProperty(ref _pullProducts, value); }

        /// <summary>
        /// 选着的产品
        /// </summary>
        public FtpProdut? SelFtpProdut
        {
            get => _selFtpProdut;
            set
            {
                SetProperty(ref _selFtpProdut, value);

                SelFtpVersion = _selFtpProdut?.FtpVersions.First();
            }
        }

        /// <summary>
        /// 选择的当前版本
        /// </summary>
        public FtpProductVersion? SelFtpVersion { get => _selFtpVersion; set => SetProperty(ref _selFtpVersion, value); }

        #endregion BindingPropertys

        #region Init

        public override string Name { get; } = "拉包";

        public override bool CustomInit()
        {
            Clear();

            try
            {
                this.LoadingTips = "正在初始化Ftp";
                FtpServerConfig ftpServerConfig = FtpServerConfig.FtpProductsConfig();
                FtpClient ftpClient = _ftpOperater.InitFtp(ftpServerConfig);

                // 初始化产品
                var products = ProductBuilder.AllProducts;
                var ftpProdcts = _ftpOperater.GetFtpProduts();

                PullProducts = ftpProdcts;
                // 获取上次选择的产品
                var lastSelId = MySettings.Ins.PullConfig.LastSelProductId;
                foreach (var ftpProduct in ftpProdcts)
                {
                    if (ftpProduct.Id.Equals(lastSelId))
                    {
                        SelFtpProdut = ftpProduct;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
            }

            return true;
        }

        private void Clear()
        {
            PullProducts.Clear();
        }

        #endregion Init

        #region Event

        public void SelectProductChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_selFtpProdut == null) return;

            // 选择的产品改变, 修改路径
            DownFilePath = MySettings.Ins.PullConfig.GetDownFilePath(_selFtpProdut.Id);
            //DownFilePath =
        }

        #endregion Event

        #region Perform - 执行

        /// <summary>
        /// 执行拉包流程
        /// </summary>
        public ICommand Pull => _pull ??= new RelayCommand(PerformPull);

        private bool _isPerforming { get; set; }

        /// <summary>
        /// 执行拉包流程
        /// </summary>
        private void PerformPull()
        {
            if (_isPerforming) return;
            if (null == _selFtpProdut) return;

            var ftpDirPath = SelFtpVersion?.VersionDirPath;
            if (string.IsNullOrEmpty(ftpDirPath))
            {
                return;
            }

            var downFilePath = _downFilePath;
            if (string.IsNullOrEmpty(downFilePath))
            {
                // todo 缺少提示
                return;
            }

            Task.Run(() =>
            {
                IsShowProgressBar = true;
                _ftpOperater.DownProduct(ftpDirPath, $"{downFilePath}", (FtpProgress ftpProgress) =>
                {
                    Progress.Value = ftpProgress.Progress;
                    Progress.Msg = $"TransferSpeed: {ftpProgress.TransferSpeedToString()}";

                    //Debug.WriteLine(
                    //    $"FileCount: {ftpProgress.FileCount} \n" +
                    //    $"Progress: {ftpProgress.Progress} \n" +
                    //    $"TransferSpeedToString: {ftpProgress.TransferSpeedToString()}");
                });
            }).ContinueWith(t =>
            {
                IsShowProgressBar = false;
                _isPerforming = false;
            });

            MySettings.Ins.PullConfig.SetDownFilePath(_selFtpProdut.Id, downFilePath);
            MySettings.Ins.PullConfig.LastSelProductId = _selFtpProdut.Id;
        }

        #endregion Perform - 执行
    }
}
