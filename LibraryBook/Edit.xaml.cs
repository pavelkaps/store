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
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        Book book;
        MainWindow main;
        public Edit(Book _book, MainWindow _main)
        {
            main = _main;
            book = _book;
            InitializeComponent();
            SetBookOnForm();
        }

        public void SetBookOnForm(){
            TitleBox.Text = book.Title ;
            AuthorBox.Text = book.Author;
            PublisherBox.Text = book.Publisher;
            YearBox.Text = book.Year.ToString();
            
            DescriptionBox.Text = book.Description;
            CirculationBox.Text = book.Сirculation.ToString();
            Rate.Text = book.Rating.ToString();
            BookLoad();
            if (book.Availability == true) { AvailabilityCheck.IsChecked = true; }
            if (book.Availability == false) {AvailabilityCheck.IsChecked = false;}

        }

        private void BookLoad()
        {

            GenreBox.ItemsSource = main.GetGenreDB().Load().Local.ToList();
            
            GenreBox.SelectedValuePath = "Id";
            GenreBox.DisplayMemberPath = "Genre";
            GenreBox.SelectedValue = book.BookGenre.Id;

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

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            
            if (TitleBox.Text == "") {  book.Title = "N/A"; } else { book.Title = TitleBox.Text; };
            if (AuthorBox.Text == "") { book.Author = "N/A"; } else { book.Author = AuthorBox.Text; };
            if (PublisherBox.Text == "") { book.Publisher = "N/A"; } else { book.Publisher = PublisherBox.Text; };
            if (DescriptionBox.Text == "") { book.Description = "N/A"; } else { book.Description = DescriptionBox.Text; };
            if (YearBox.Text == "") { book.Year = 0; } else { book.Year = int.Parse(YearBox.Text); };
            if (AvailabilityCheck.IsChecked == true) { book.Availability = true; } else { book.Availability = false; };
            if (CirculationBox.Text == "") { book.Сirculation = 0; } else { book.Сirculation = int.Parse(CirculationBox.Text); }
            book.Rating = int.Parse(Rate.Text);

            book.SetAvailability();
            
            //book.BookGenre = (BookGenre)GenreBox.SelectedItem;

            main.DBBook.Update(book);
            this.DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public Book GetBook()
        {
            return book;
        }
    }
}
