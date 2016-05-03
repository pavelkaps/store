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
    /// Логика взаимодействия для AddType.xaml
    /// </summary>
    public partial class AddType : Window
    {
        MainWindow Main;
        public AddType(MainWindow _main)
        {
            Main = _main;
            InitializeComponent();
            TypeBox.SelectedIndex = 0;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            switch (ChangeType())
            {
                case 1:
                    BookGenre newGenre = new BookGenre();
                    newGenre.Genre = TextBox.Text;
                    Main.GetGenreDB().Insert(newGenre);
                    break;
                case 2:
                    MagazineType newType = new MagazineType();
                    newType.type = TextBox.Text;
                    Main.GetTypeDB().Insert(newType);
                    break;
            }

            this.DialogResult = true;
            Close();
        }

        public int ChangeType(){
            ComboBoxItem selectedItem = (ComboBoxItem)TypeBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Жанр") { return 1; }
            if (selectedItem.Content.ToString() == "Тип") { return 2; }
            return 0;

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
        }

    }
}
