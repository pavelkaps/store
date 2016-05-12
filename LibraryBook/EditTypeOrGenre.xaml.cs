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
    /// Логика взаимодействия для EditTypeOrGenre.xaml
    /// </summary>
    public partial class EditTypeOrGenre : Window
    {
        MainWindow main;
        public EditTypeOrGenre(MainWindow main)
        {
            InitializeComponent();
            this.main = main;

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)TypeBox.SelectedItem;

            if (selectedItem.Content.ToString() == "Жанр") { BookGenre genre = (BookGenre)ListBox.SelectedItem; if (TextBox.Text != "") { genre.Title = TextBox.Text; } else { genre.Title = "N/A"; }; main.GetGenreDB().Update(); MessageBox.Show("Жанр успешно изменен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information); }
            if (selectedItem.Content.ToString() == "Тип") { MagazineType type = (MagazineType)ListBox.SelectedItem; if (TextBox.Text != "") { type.Title = TextBox.Text; } else { type.Title = "N/A"; }; main.GetTypeDB().Update(); MessageBox.Show("Тип успешно изменен", "Успешно", MessageBoxButton.OK, MessageBoxImage.Information); }
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)TypeBox.SelectedItem;

            if (selectedItem.Content.ToString() == "Жанр") { BookGenre genre = (BookGenre)ListBox.SelectedItem; main.GetGenreDB().Delete(genre.Id); MessageBox.Show("Жанр успешно удален", "Успешно удалено", MessageBoxButton.OK, MessageBoxImage.Information); }
            if (selectedItem.Content.ToString() == "Тип") { MagazineType type = (MagazineType)ListBox.SelectedItem; main.GetTypeDB().Delete(type.Id); MessageBox.Show("Тип успешно удален", "Успешно удалено", MessageBoxButton.OK, MessageBoxImage.Information); }
          
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Change(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Жанр") { ListBox.ItemsSource = main.GetGenreDB().Load().ToList(); }
            if (selectedItem.Content.ToString() == "Тип") { ListBox.ItemsSource = main.GetTypeDB().Load().ToList(); }
            ListBox.SelectedIndex = 0;
            
        }
    }
}
