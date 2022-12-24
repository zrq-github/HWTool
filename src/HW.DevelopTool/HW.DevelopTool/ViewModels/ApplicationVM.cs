using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using HW.DevelopTool.Views;
using ZRQ.UI.UIModel;

namespace HW.DevelopTool.ViewModels;

internal class ApplicationVM
    : ViewModelBase
{
    private bool _isReadOnly = false;
    private bool _isTitleBarVisible = false;
    private object? _currentView = null;
    private IEnumerable<ApplicationContentVM> pagesCollectionView;
    private ApplicationContentVM? _selectedPage = null;

    public ApplicationVM()
    {
        pagesCollectionView = CreateAllPages();
    }

    /// <summary>
    /// 是否是黑暗主题
    /// </summary>
    public bool IsDark { get; set; } = true;

    /// <summary>
    /// 整个界面是否只读
    /// </summary>
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

    /// <summary>
    /// 总共的分页
    /// </summary>
    public IEnumerable<ApplicationContentVM> PagesCollectionView { get => pagesCollectionView; set => SetProperty(ref pagesCollectionView, value); }

    public ApplicationContentVM? SelectedPage
    {
        get => _selectedPage;
        set
        {
            value ??= PagesCollectionView.FirstOrDefault();

            if (value != null && !value.IsLoading)
            {
                Task.Run(() =>
                {
                    value.Init();
                });
            }

            SetProperty(ref _selectedPage, value);

            //RaisePropertyChanged(nameof(SelectedNavigationGroup));
        }
    }

    private IEnumerable<ApplicationContentVM> CreateAllPages()
    {
        yield return new HomeVM();
        yield return new PullProductVM();
        yield break;
    }
}
