using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using HWDevelopTool.Framework;

namespace HWDevelopTool.ViewModels
{
    internal class ApplicationViewModel
        : ViewModel
    {
        private bool _isReadOnly;

        private bool _isTitleBarVisible = false;

        public ApplicationViewModel()
        {
        }

        public bool IsReadOnly
        {
            get => _isReadOnly;
            set => SetProperty(ref _isReadOnly, value);
        }

        public bool IsTitleBarVisible
        {
            get => _isTitleBarVisible;
            set => SetProperty(ref _isTitleBarVisible, value);
        }
    }
}
