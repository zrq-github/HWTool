using AdonisUI;
using HW.DevelopTool.Config;
using System.Windows;

namespace HW.DevelopTool;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : AdonisUI.Controls.AdonisWindow
{
    public static readonly DependencyProperty IsDarkProperty = DependencyProperty.Register("IsDark", typeof(bool), typeof(MainWindow), new PropertyMetadata(false, OnIsDarkChanged));


    public MainWindow()
    {
        InitializeComponent();

        this.Loaded += MainWindow_Loaded;
        this.Closed += MainWindow_Closed;
    }

    private void MainWindow_Closed(object? sender, System.EventArgs e)
    {
        MySettings.Ins.SaveFile();
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        MySettings.Ins.InitSetting();
    }

    public bool IsDark
    {
        get => (bool)GetValue(IsDarkProperty);
        set => SetValue(IsDarkProperty, value);
    }

    private static void OnIsDarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((MainWindow)d).ChangeTheme((bool)e.OldValue);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(this, "这是一个问号");
    }

    private void ChangeTheme(bool oldValue)
    {
        ResourceLocator.SetColorScheme(Application.Current.Resources, oldValue ? ResourceLocator.LightColorScheme : ResourceLocator.DarkColorScheme);
    }
}
