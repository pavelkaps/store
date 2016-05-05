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
    /// Логика взаимодействия для SeachForm.xaml
    /// </summary>
    public partial class SeachForm : Window
    {
        MainWindow main;
        public SeachForm(MainWindow _main)
        {
            main = _main;
            InitializeComponent();
            BookBox.SelectedIndex = 0;
            MagazineBox.SelectedIndex = 0;
            SeachTextBox.MaxLength = 5;
        }

        public void SetAsBook()
        {
            MagazineBox.Visibility = Visibility.Collapsed;
            BookBox.Visibility = Visibility.Visible;
        }

        public void SetAsMagazine()
        {
            BookBox.Visibility = Visibility.Collapsed;
            MagazineBox.Visibility = Visibility.Visible;
        }

        private void Seach_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)main.EntityBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги"){
            
            }
            if (selectedItem.Content.ToString() == "Журналы"){
            
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            main.DefaultDataGrid();
            Close();
        }


        private void SeachTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) ) e.Handled = true;
        }

       

         


    }
}
