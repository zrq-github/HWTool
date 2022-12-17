using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using HW.DevelopTool.Framework;

namespace HW.DevelopTool.ViewModels;

class ApplicationViewModel
    : ViewModel
{
    private bool _isTitleBarVisible = false;

    public ApplicationViewModel()
    {
    }

    public bool IsTitleBarVisible
    {
        get => _isTitleBarVisible;
        set => SetProperty(ref _isTitleBarVisible, value);
    }

    private object currentView;

    public bool IsDark { get; set; }

    /// <summary>
    /// 当前的视图
    /// </summary>
    public object CurrentView { get => currentView; set => SetProperty(ref currentView, value); }
}
