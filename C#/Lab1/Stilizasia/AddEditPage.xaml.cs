using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Stilizasia
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Hotel _currentHotel = new Hotel();

        public AddEditPage(Hotel selectedHotel)
        {
            InitializeComponent();
            ComboCountries.ItemsSource = HotelsEntities.GetContext().Country.ToList();
            if(selectedHotel != null)
                _currentHotel = selectedHotel;

            DataContext = selectedHotel;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if(string.IsNullOrWhiteSpace(_currentHotel.Name_hotel))
            {
                errors.AppendLine("Укажите название отеля");
            }
            if(_currentHotel.Count_of_stars < 1 || _currentHotel.Count_of_stars > 5)
            {
                errors.AppendLine("Количество звёзд - от 1 до 5");
            }
            if(_currentHotel.Country == null)
            {
                errors.AppendLine("Выберите страну");
            }
            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if(_currentHotel.id == 0)
            {
                HotelsEntities.GetContext().Hotel.Add(_currentHotel);
            }
            try
            {
                HotelsEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

    }
}
