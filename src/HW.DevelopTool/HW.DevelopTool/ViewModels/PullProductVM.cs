using FluentFTP;
using HW.DevelopTool.Models;
using HW.DevelopTool.Views;
using HW.PullFTPFile;
using HW.PullFTPFile.DB;
using HW.Tool.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ZRQ.UI.UICommands;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels
{
    internal class PullProductVM : ApplicationContentVM
    {
        private bool _isShowProgressBar = false;
        private RelayCommand? _pull;
        private PullProductsOperater _ftpOperater = new();
        private List<string> _productVersions = new();
        private string _productVersion = string.Empty;
        private List<FtpProdut> _pullProducts = new();
        private FtpProdut _selFtpProdut;
        private FtpProductVersion _selFtpVersion;

        public PullProductVM()
        {
        }

        /// <summary>
        /// 是否显示进度条
        /// </summary>
        public bool IsShowProgressBar { get => _isShowProgressBar; set => SetProperty(ref _isShowProgressBar, value); }

        /// <summary>
        /// 拉包的数据源
        /// </summary>
        public List<FtpProdut> PullProducts { get => _pullProducts; set => SetProperty(ref _pullProducts, value); }

        /// <summary>
        /// 选着的产品
        /// </summary>
        public FtpProdut SelFtpProdut { get => _selFtpProdut; set => SetProperty(ref _selFtpProdut, value); }

        /// <summary>
        /// 选择的当前版本
        /// </summary>
        public FtpProductVersion SelFtpVersion { get => _selFtpVersion; set => SetProperty(ref _selFtpVersion, value); }

        private void OnSelectProduct(string? selectProductName)
        {
            //if (null == selectProductName) { return; }

            //foreach (var pullProduct in _pullProducts)
            //{
            //    if (pullProduct.ShowName().Equals(selectProductName))
            //    {
            //        //var versions = pullProduct.FtpVersions.ConvertAll(p => p.Version);
            //        //ProductVersions = versions;
            //        return;
            //    }
            //}
        }

        /// <summary>
        /// 产品的版本
        /// </summary>
        public string ProductVersion { get => _productVersion; set => SetProperty(ref _productVersion, value); }

        /// <summary>
        /// 后选的产品版本
        /// </summary>
        public List<string> ProductVersions { get => _productVersions; set => SetProperty(ref _productVersions, value); }

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

            // 验证选择的路径
            if (null == SelFtpVersion)
            {
                return;
            }
            var ftpDirPath = SelFtpVersion.VersionDirPath;


            _ftpOperater.DownProduct(ftpDirPath, @"C:\Users\zrq\Downloads");

            IsShowProgressBar = false;
        }

        #endregion
    }
}
