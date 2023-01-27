using System.Threading.Tasks;
using System.Windows;

namespace WpfToDoList.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnClose_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Opacity -= 0.1;
                await Task.Delay(2);
            }
            this.Close();
        }

        private void btnMin_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
