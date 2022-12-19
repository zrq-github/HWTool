using System;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels
{
    internal abstract class ApplicationContentVM : ViewModelBase, IApplicationContentVM
    {
        private bool _isLoading = false;

        public abstract string Name { get; }

        /// <summary>
        /// 是否正在加载
        /// </summary>
        public bool IsLoading
        {
            get => _isLoading;
            set => SetProperty(ref _isLoading, value);
        }

        public bool IsInit { get; set; } = false;

        public virtual void Init()
        {
            IsInit = true;
        }
    }
}
