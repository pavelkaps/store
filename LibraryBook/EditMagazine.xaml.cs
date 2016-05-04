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
    /// Логика взаимодействия для EditMagazine.xaml
    /// </summary>
    public partial class EditMagazine : Window
    {
        Magazine magazine;
        MainWindow main;
        public EditMagazine(Magazine _magazine, MainWindow _main)
        {
            main = _main;
            magazine = _magazine;
            InitializeComponent();
            SetMagazineForm();
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
        public void SetMagazineForm()
        {
            TitleBox.Text =magazine.Title;
            PublisherBox.Text = magazine.Publisher;
            EditionBox.Text = magazine.Edition.ToString();
            DescriptionBox.Text = magazine.Description;
            CirculationBox.Text = magazine.Сirculation.ToString();
            Rate.Text = magazine.Rating.ToString();

            if (magazine.Availability == true) { AvailabilityCheck.IsChecked = true; }
            if (magazine.Availability == false) { AvailabilityCheck.IsChecked = false; }
            MagazineLoad();
        }
        private void MagazineLoad()
        {

            TypeBox.ItemsSource = main.GetTypeDB().Load().Local.ToList();

            TypeBox.SelectedValuePath = "Id";
            TypeBox.DisplayMemberPath = "type";
            TypeBox.SelectedValue = magazine.MagazineType.Id;

        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (TitleBox.Text == "") { magazine.Title = "N/A"; } else { magazine.Title = TitleBox.Text; };
            if (PublisherBox.Text == "") { magazine.Publisher = "N/A"; } else { magazine.Publisher = PublisherBox.Text; };
            if (DescriptionBox.Text == "") { magazine.Description = "N/A"; } else { magazine.Description = DescriptionBox.Text; };
            if (EditionBox.Text == "") { magazine.Edition = 0; } else { magazine.Edition = int.Parse(EditionBox.Text); }
            if (CirculationBox.Text == "") { magazine.Сirculation = 0; } else { magazine.Сirculation = int.Parse(CirculationBox.Text); }
            if (AvailabilityCheck.IsChecked == true) { magazine.Availability = true; } else { magazine.Availability = false; };

            magazine.Rating = int.Parse(Rate.Text);
            magazine.SetAvailability();

            //magazine.MagazineType = (MagazineType)TypeBox.SelectedItem;
            main.GetMagazineDB().Update(magazine);

            this.DialogResult = true;
            Close();
        }

        public Magazine GetMagazine()
        {
            return magazine;
        }
    }
}
