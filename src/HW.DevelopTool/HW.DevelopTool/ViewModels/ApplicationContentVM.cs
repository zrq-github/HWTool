using System;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels
{
    internal abstract class ApplicationContentVM : ViewModelBase, IApplicationContentVM
    {
        private readonly static string loadingTips = "正在加载界面...";

        private bool _isLoading = false;
        private string _loadingTips = loadingTips;

        public bool IsInit { get; set; } = false;

        /// <summary>
        /// 是否正在加载
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        /// <summary>
        /// 初始化的提示
        /// </summary>
        public string LoadingTips { get => _loadingTips; set => SetProperty(ref _loadingTips, value); }

        public abstract string Name { get; }

        public void Init()
        {
            IsLoading = true;

            // CustomInit();
            if (!IsInit)
            {
                IsInit = CustomInit();
            }

            IsLoading = false;
            LoadingTips = loadingTips;
        }

        /// <summary>
        /// 实现下面界面格式的初始化
        /// </summary>
        public virtual bool CustomInit()
        {
            return true;
        }

        private void InitAfter()
        {
        }
    }
}
