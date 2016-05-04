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
    /// Логика взаимодействия для AboutBook.xaml
    /// </summary>
    public partial class AboutBook : Window
    
    {

        Book book;
        MainWindow main;
        public AboutBook(Book _book, MainWindow _main)
        {
            InitializeComponent();
            book = _book;
            main = _main;
            SetBook();
        }
        
        public void SetBook(){
            TitleBox.Text = "\"" + book.Title + "\"";
            AuthorBox.Text = book.Author;
            PublisherBox.Text = book.Publisher;
            YearBox.Text = book.Year.ToString();
            GenreBox.Text = book.BookGenre.Genre;
            DescriptionBox.Text = book.Description;
            CirculationBox.Text = book.Сirculation.ToString();
            Rate.Text = book.Rating.ToString();
            id.Text = "id: " + book.Id;
            if (book.Availability == true) { NoAvailability.Text = ""; Availability.Text = "В наличии"; }
            if (book.Availability == false) { Availability.Text = ""; NoAvailability.Text = "Нет в наличии"; }

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            main.GetBookDb().Delete(book.Id);
            MessageBox.Show("Запись удалена");
            main.UpdateDataGrid();
            Close();

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Edit form = new Edit(book, main);
            form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (form.ShowDialog() == true)
            {
                book = form.GetBook();
                SetBook();
            }
            
        }
    }
}
