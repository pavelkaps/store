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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace LibraryBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookRepository DBBook;
        BookGenreRepository DBGenre;
        MagazineTypeRepository DBType;
        MagazineRepository DBMagazine;
        public ObservableCollection<Book> Books { get; private set; }
        private BookContext db;
        public MainWindow()
        {
            DBBook = new BookRepository();
            DBGenre = new BookGenreRepository();
            DBType = new MagazineTypeRepository();
            DBMagazine = new MagazineRepository();
            db = new BookContext();
            Books = new ObservableCollection<Book>(db.dbBooks);
            InitializeComponent();
            //BookGrid.ItemsSource = DBBook.Load(); 
         }

        private void Add(object sender, RoutedEventArgs e)
        {

            BookGenre t1 = new BookGenre();
            t1.Genre = "Приключения";
            Book pl1 = new Book();
            pl1.BookGenre = t1;

            DBBook.Insert(pl1);
            

        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
           
        }

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Book path = BookGrid.SelectedItem as Book;
            MessageBox.Show(" ID: " + path.Id + "\n Исполнитель: " + path.Author +  "\n Год: " + path.Year);
        }


        }

        


       
    }

