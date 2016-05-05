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
    /// Логика взаимодействия для AddBook.xaml
    /// </summary>
    public partial class AddBook : Window
    {
        Book newBook;
        MainWindow main;
        
        public AddBook(MainWindow m)
        {
            main = m;
            
            InitializeComponent();
            BookLoad();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            newBook = new Book();
            if (TitleBox.Text == "") { newBook.Title = "N/A"; } else { newBook.Title = TitleBox.Text; };
            if (AuthorBox.Text == "") { newBook.Author = "N/A"; } else { newBook.Author = AuthorBox.Text; };
            if (PublisherBox.Text == "") { newBook.Publisher = "N/A"; } else { newBook.Publisher = PublisherBox.Text; };
            if (DescriptionBox.Text == "") { newBook.Description = "N/A"; } else { newBook.Description = DescriptionBox.Text; };
            if (YearBox.Text == "") { newBook.Year = 0; } else { newBook.Year = int.Parse(YearBox.Text); };
            if (AvailabilityCheck.IsChecked == true) { newBook.Availability = true; } else { newBook.Availability = false; };
            if (CirculationBox.Text == "") { newBook.Сirculation = 0; } else { newBook.Сirculation = int.Parse(CirculationBox.Text); }
            newBook.Rating = int.Parse(Rate.Text);
            
            newBook.SetAvailability();

            newBook.BookGenre = (BookGenre)GenreBox.SelectedItem;
            main.GetBookDb().InsertWithId(newBook,newBook.BookGenre.Id);
          
            this.DialogResult = true;
            Close();
        }

        private void BookLoad()
        {

            GenreBox.ItemsSource = main.GetGenreDB().Load().Local.ToList();
            GenreBox.SelectedIndex = 0;
            GenreBox.SelectedValuePath = "Id";
            GenreBox.DisplayMemberPath = "Genre";

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            Close();
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
