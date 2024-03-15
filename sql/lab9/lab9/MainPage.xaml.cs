using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


using Windows.UI.ViewManagement;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace lab9
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        public MainPage()
        {
            this.InitializeComponent();
        }

        List<String> UrlPhotos = new List<String>();
        int counterOfPhotos = 0;
        List<int> userCheck = new List<int>();


        private async void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginTb.Text = "";
                int userId = Convert.ToInt32((LoginTb.Text));
                using (Контекст db = new Контекст())
                {
                    userCheck = (db.Фотографии.Where(a => a.код_пользователя == userId).Select(b => b.код_пользователя)).ToList();
                //   userCheck = (db.Фотографии.Select(b => b.код_пользователя)).ToList();
                }

                // LoginTb.Text =(userCheck[0]).ToString();
                //  LoginTb.Text += "Конец";
                if (userId == userCheck[0])
                {
                    var dialog = new MessageDialog("Авторизация прошла успешно!!");
                    await dialog.ShowAsync();
                    MainFrame.Content = new PersonalAccount(userCheck[0]);
                }
            }
            catch
            {

                var dialog2 = new MessageDialog("Пользователь не найден!");
                LoginTb.Text = "в НАЛИЧИИ " + userCheck.Count;

                 await dialog2.ShowAsync();
                 


            }
        }
    }
}
