using AdonisUI;
using System.Windows;

namespace HWDevelopTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ApplicationView : AdonisUI.Controls.AdonisWindow
    {
        public static readonly DependencyProperty IsDarkProperty = DependencyProperty.Register("IsDark", typeof(bool), typeof(ApplicationView), new PropertyMetadata(false, OnIsDarkChanged));

        public ApplicationView()
        {
            InitializeComponent();
        }

        public bool IsDark
        {
            get => (bool)GetValue(IsDarkProperty);
            set => SetValue(IsDarkProperty, value);
        }

        private static void OnIsDarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((ApplicationView)d).ChangeTheme((bool)e.OldValue);
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
}
