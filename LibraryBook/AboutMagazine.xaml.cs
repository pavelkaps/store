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
using System.Windows.Shapes;

namespace LibraryBook
{
    /// <summary>
    /// Логика взаимодействия для AboutMagazine.xaml
    /// </summary>
    public partial class AboutMagazine : Window
    {
        MainWindow main;
        Magazine magazine;
        public AboutMagazine(MainWindow _main, Magazine a)
        {
            main = _main;
            magazine = a;
            InitializeComponent();
            SetMagazine();
        }
        public void SetMagazine()
        {
            
                TitleBox.Text = "\"" + magazine.Title + "\"";
                PublisherBox.Text = magazine.Publisher;
                EditionBox.Text = magazine.Edition.ToString();
                DescriptionBox.Text = magazine.Description;
                CirculationBox.Text = magazine.Сirculation.ToString();
                GenreBox.Text = magazine.MagazineType.type;
                Rate.Text = magazine.Rating.ToString();
                id.Text = "id: " + magazine.Id;
                if (magazine.Availability == true) { NoAvailability.Text = ""; Availability.Text = "В наличии"; }
                if (magazine.Availability == false) { Availability.Text = ""; NoAvailability.Text = "Нет в наличии"; }
            
            
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            main.GetMagazineDB().Delete(magazine.Id);
            MessageBox.Show("Запись удалена");
            main.UpdateDataGrid();
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            EditMagazine form = new EditMagazine(magazine, main);
            form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (form.ShowDialog() == true)
            {
                magazine = form.GetMagazine();
                SetMagazine();
            }
        }
    }
}
