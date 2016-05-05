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
    /// Логика взаимодействия для AddMagazine.xaml
    /// </summary>
    public partial class AddMagazine : Window
    {
        Magazine newMagazine;
        MainWindow Main;

        public AddMagazine(MainWindow _main)
        {
            Main = _main;
            InitializeComponent();
            MagazineLoad();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            newMagazine = new Magazine();
            if (TitleBox.Text == "") { newMagazine.Title = "N/A"; } else { newMagazine.Title = TitleBox.Text; };
            if (PublisherBox.Text == "") { newMagazine.Publisher = "N/A"; } else { newMagazine.Publisher = PublisherBox.Text; };
            if (DescriptionBox.Text == "") { newMagazine.Description = "N/A"; } else { newMagazine.Description = DescriptionBox.Text; };
            if (EditionBox.Text == "") { newMagazine.Edition = 0; } else { newMagazine.Edition = int.Parse(EditionBox.Text); }
            if (CirculationBox.Text == "") { newMagazine.Сirculation = 0; } else { newMagazine.Сirculation = int.Parse(CirculationBox.Text); }
            if (AvailabilityCheck.IsChecked == true) { newMagazine.Availability = true; } else { newMagazine.Availability = false; };
            
            newMagazine.Rating = int.Parse(Rate.Text);
            newMagazine.SetAvailability();
            
            
            newMagazine.MagazineType = (MagazineType)TypeBox.SelectedItem;
            Main.GetMagazineDB().InsertWithId(newMagazine, newMagazine.MagazineType.Id);
            this.DialogResult = true;
            Close();
        }
        private void MagazineLoad()
        {

            TypeBox.ItemsSource = Main.GetTypeDB().Load().Local.ToList();
            TypeBox.SelectedIndex = 0;
            TypeBox.SelectedValuePath = "Id";
            TypeBox.DisplayMemberPath = "type";

        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(Rate.Text) < 10)
            {
                int count = int.Parse(Rate.Text) + 1;
                Rate.Text = count.ToString();
            }
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(Rate.Text) > 0)
            {
                int count = int.Parse(Rate.Text) - 1;
                Rate.Text = count.ToString();
            }
        }
    }
}
