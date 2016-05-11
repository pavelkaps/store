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
        List<Book> SearchBooks;
        List<Magazine> SearchJournals;
        public SeachForm(MainWindow _main)
        {
            main = _main;
            InitializeComponent();
            BookBox.SelectedIndex = 0;
            MagazineBox.SelectedIndex = 0;
            
            AvailabilityCheck.Visibility = Visibility.Collapsed;
            Rate.Visibility = Visibility.Collapsed; 
            Up.Visibility = Visibility.Collapsed; 
            Down.Visibility = Visibility.Collapsed;
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
           
                switch(searchId(1)){

                    case 1: 
                SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (Book book in SearchBooks.ToArray())
                {
                if(book.Id!=int.Parse(SearchBox.Text)) SearchBooks.Remove(book);
                }
                break;

                case 2: SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                if(book.Title!=SearchBox.Text)SearchBooks.Remove(book);
                }
                break;

                case 3: SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                if(book.Author!=SearchBox.Text)SearchBooks.Remove(book);

                }
                break;

                case 4: SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                if(book.Year!=int.Parse(SearchBox.Text))SearchBooks.Remove(book);
                }
                break;

                case 5:
                SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                    if (book.Сirculation != int.Parse(SearchBox.Text)) SearchBooks.Remove(book);
                }
                break;

                case 6:
                SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                if(book.Rating!=int.Parse(Rate.Text))SearchBooks.Remove(book);
                }
                break;
                
                case 7:
                SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                if(book.Availability!= AvailabilityCheck.IsChecked)SearchBooks.Remove(book);
                }
                break;

                case 8:
                SearchBooks = main.GetBookDb().Load().Local.ToList();
                foreach (var book in SearchBooks.ToArray())
                {
                    if (book.Publisher != SearchBox.Text) SearchBooks.Remove(book);

                }
                break;
            }
           
            }
            
            if (selectedItem.Content.ToString() == "Журналы")
            {
                switch (searchId(2))
                {

                    case 1:
                        SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Id != int.Parse(SearchBox.Text)) SearchJournals.Remove(magazine);
                        }
                        break;

                    case 2: SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Title != SearchBox.Text) SearchJournals.Remove(magazine);
                        }
                        break;

                    case 3: SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Edition != int.Parse(SearchBox.Text)) SearchJournals.Remove(magazine);
                        }
                        break;

     

                    case 5:
                        SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Сirculation != int.Parse(SearchBox.Text)) SearchJournals.Remove(magazine);
                        }
                        break;

                    case 6:
                        SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Rating != int.Parse(Rate.Text)) SearchJournals.Remove(magazine);
                        }
                        break;

                    case 7:
                        SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Availability != AvailabilityCheck.IsChecked) SearchJournals.Remove(magazine);
                        }
                        break;

                    case 8:
                        SearchJournals = main.GetMagazineDB().Load().Local.ToList();
                        foreach (var magazine in SearchJournals.ToArray())
                        {
                            if (magazine.Publisher != SearchBox.Text) SearchJournals.Remove(magazine);

                        }
                        break;
                }
            }

            main.SetSourceForBookDataGrid(SearchBooks);
            main.SetSourceForMagazineDataGrid(SearchJournals);
            Close();
            
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
            //if (!Char.IsDigit(e.Text, 0) ) e.Handled = true;
        }

        public int searchId(int id)
        {
            ComboBoxItem selectedItem = (ComboBoxItem)BookBox.SelectedItem;

            if (id == 1)
            {
                if (selectedItem.Content.ToString() == "Id") { return 1; }
                if (selectedItem.Content.ToString() == "Заголовок") { return 2; }
                if (selectedItem.Content.ToString() == "Автор") { return 3; }

                if (selectedItem.Content.ToString() == "Издатель") { return 8; }
                if (selectedItem.Content.ToString() == "Год") { return 4; }
                if (selectedItem.Content.ToString() == "Тираж") { return 5; }

                if (selectedItem.Content.ToString() == "Рейтинг") { return 6; }
                if (selectedItem.Content.ToString() == "Наличие") { return 7; }
            }
            
            ComboBoxItem selectedItemMagazine = (ComboBoxItem)MagazineBox.SelectedItem;
            if (id == 2)
            {
                if (selectedItemMagazine.Content.ToString() == "Id") { return 1; }
                if (selectedItemMagazine.Content.ToString() == "Заголовок") { return 2; }
                if (selectedItemMagazine.Content.ToString() == "Выпуск") { return 3; }

                if (selectedItemMagazine.Content.ToString() == "Издатель") { return 8; }

                if (selectedItemMagazine.Content.ToString() == "Тираж") { return 5; }

                if (selectedItemMagazine.Content.ToString() == "Рейтинг") { return 6; }
                if (selectedItemMagazine.Content.ToString() == "Наличие") { return 7; }

            }

            return 0;
        }

        private void Enabled(object sender, DependencyPropertyChangedEventArgs e)
        {
           
        }

        private void EnabledBook(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)BookBox.SelectedItem;
            SearchBox.Visibility = Visibility.Visible;
            if (selectedItem.Content.ToString() == "Наличие") { SearchBox.Visibility = Visibility.Collapsed; AvailabilityCheck.Visibility = Visibility.Visible;  }
            if (selectedItem.Content.ToString() == "Рейтинг") { SearchBox.Visibility = Visibility.Collapsed; Rate.Visibility = Visibility.Visible; Up.Visibility = Visibility.Visible; Down.Visibility = Visibility.Visible;  }
            
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

        private void SelectedMagazine(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)MagazineBox.SelectedItem;
            SearchBox.Visibility = Visibility.Visible;
            if (selectedItem.Content.ToString() == "Наличие") { SearchBox.Visibility = Visibility.Collapsed; AvailabilityCheck.Visibility = Visibility.Visible; }
            if (selectedItem.Content.ToString() == "Рейтинг") { SearchBox.Visibility = Visibility.Collapsed; Rate.Visibility = Visibility.Visible; Up.Visibility = Visibility.Visible; Down.Visibility = Visibility.Visible; }
            
        }

        
       

         


    }
}
