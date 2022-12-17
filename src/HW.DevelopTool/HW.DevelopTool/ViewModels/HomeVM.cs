using HW.DevelopTool.Framework;

namespace HW.DevelopTool.ViewModels;

internal class HomeVM : ViewModelBase, IApplicationContentVM
{
    public string Name { get; } = "Home";
    public bool IsLoading { get; set; } = false;

    public void Init()
    {
    }
}
