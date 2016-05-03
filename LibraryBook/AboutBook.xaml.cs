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
        public AboutBook(Book _book)
        {
            InitializeComponent();
            book = _book;
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
            

        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
