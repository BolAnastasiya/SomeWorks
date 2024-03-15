using System.Windows;

namespace AMONIC_Airlines_3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FrameNavigate.frame = mainFrame;
            FrameNavigate.NavigateTo(new LoginPage());
        }

        private void mainWind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(mainFrame.Content is UserPage)
            {
                ((UserPage)mainFrame.Content).SaveData();
            }
            
        }
    }
}
