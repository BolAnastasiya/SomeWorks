using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace lab9
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class PersonalAccount : Page
    {
        public PersonalAccount(int userId)
        {
            this.InitializeComponent();
            UserId = userId;
            this.Loaded += MainFrame_Loaded;
            //avatar.Margin = new Thickness(339, 131, 469, 175);
            avatar.Width = 257;
            avatar.Height = 257;
        }
        List<int> codephotos = new List<int>();
        List<String> Urlavatar = new List<String>();
        List<String> Urlvideos = new List<string>();
        List<String> commAuthor = new List<string>();
        int UserId = 0;


        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            using (Контекст db = new Контекст())
            {
                codephotos = db.Фотографии.Where(a => a.код_пользователя == UserId).Select(b => b.код_фотографии).ToList();
                Urlavatar = db.Пользователи.Where(a => a.код_пользователя == UserId).Select(b => b.аватар).ToList();
                Urlvideos = db.Фотографии.Where(a => a.код_пользователя == UserId).Select(b => b.адрес).ToList();
                //   var albums = db.Видеозаписи.Join( p => p.Код_видеозаписи).Select(b => b.Адрес).ToList();
                //commUser = db.Комментарий.Where(p => p.Код_фотографии == codePhotos[0]).Select(c => c.Коментарий).ToList();
                //commAuthor = db.Фотографии.Where(d => d.Код_пользователя == UserId).Select(v => v.Комментарий_автора).ToList();

            }
            if (codephotos.Count == 0)
            {
                MainFrame2.Content = new MainPage();
            }
            else
            {
                
                Windows.UI.Xaml.Media.Imaging.BitmapImage bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                bitmap.UriSource = new Uri(Urlavatar[0]);
                avatar.Source = bitmap;
                TbName.Text = $"User{UserId}";
                TbName.Text += "...";

                Listvideos.ItemsSource = Urlvideos;

            }
        }


        private void Listvideos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            media.Source = new Uri(Convert.ToString(Listvideos.SelectedItem));
        }

        // Pereacha user = new Pereacha();
        //   BlogUsers = new BlogUsers();
        private async void BtnGoOtherPage_Click(object sender, RoutedEventArgs e)
        {


            //    (Application.Current as App).sss = UserId.ToString();
            //  Frame.Navigate(typeof(BlogUsers), (Application.Current as App).sss);
            // MainFrame.Navigate(typeof(BlogUsers));
            // MainFrame2.BackStack.Clear();
          //  MainFrame2.Content = new BlogUsers(UserId);
            media.Pause();
            media.Source = null;
        }
    }
}

