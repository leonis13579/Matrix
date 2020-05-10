using Matrix.Pages;
using System.Windows.Navigation;

namespace Matrix
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Navigate(new Menu());
        }
    }
}
