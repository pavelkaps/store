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
        public BookRepository DBBook;
        public BookGenreRepository DBGenre;
        public MagazineTypeRepository DBType;
        public MagazineRepository DBMagazine;

        public MainWindow()
        {
            DBBook = new BookRepository();
            DBGenre = new BookGenreRepository();
            DBType = new MagazineTypeRepository();
            DBMagazine = new MagazineRepository();
           
            InitializeComponent();
            
            EntityBox.SelectedIndex = 0;
            MagazineGrid.Visibility = Visibility.Collapsed;
            BookLoad();
         }

        private void Add(object sender, RoutedEventArgs e)
        {
            //BookOrMagazine form = new BookOrMagazine(this);
            //form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            //if (form.ShowDialog() == true)
            //{
            //    BookGrid.ItemsSource = null;                  //refresh DataGrig
            //    BookLoad();
            //}

            //BookGenre t = new BookGenre();
            //t.Genre = "Приключения";
            //Book newBook = new Book();
            //newBook.BookGenre = t;
            //DBBook.Insert(newBook);

            //MagazineType tp = new MagazineType();
            //tp.type = "Стиль";
            //Magazine newMagazine = new Magazine();
            //newMagazine.MagazineType = tp;
            //DBMagazine.Insert(newMagazine);


            BookGenre t = (BookGenre)DBGenre.Find(2);
            Book n = new Book();
            n.BookGenre = t;
            DBBook.Insert(n);

         }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
           
        }

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Book path = BookGrid.SelectedItem as Book;
            AboutBook frm = new AboutBook(path);
            frm.Show();
        }

        private void LoadGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = "  " + (e.Row.GetIndex() + 1) + "  ";
        }
        

        private void BookLoad()
        {
            BookGrid.ItemsSource = DBBook.Load().Local.ToBindingList();
            TypeLabel.Content = "Выберите жанр:";
            TypeBox.ItemsSource = BookStringList(DBGenre.Load().Local.ToList());
            TypeBox.SelectedIndex = 0;
        }

        private List<string> BookStringList(List<BookGenre> a)
        {
            List<string>  list = new List<string>();
            list.Add("Все");
            foreach (BookGenre p in a)
            {
                list.Add(p.Genre);
            }
            return list;
        }

        private void MagazineLoad()
        {
            MagazineGrid.ItemsSource = DBMagazine.Load().Local.ToBindingList();
            TypeLabel.Content = "Выберите тип:";
            TypeBox.ItemsSource = MagazineStringList(DBType.Load().Local.ToList());
            TypeBox.SelectedIndex = 0;
        }

        private List<string> MagazineStringList(List<MagazineType> a)
        {
            List<string> list = new List<string>();
            list.Add("Все");
            foreach (MagazineType p in a)
            {
                list.Add(p.type);
            }
            return list;
        }

        
        private void EntityBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги") { MagazineGrid.Visibility = Visibility.Collapsed; BookGrid.Visibility = Visibility.Visible;  }
            if (selectedItem.Content.ToString() == "Журналы") { BookGrid.Visibility = Visibility.Collapsed; MagazineGrid.Visibility = Visibility.Visible; MagazineLoad(); } //MagazineLoad();BookLoad();

        }

        public BookRepository GetBookDb()
        {
            return DBBook;
        }

        public MainWindow GetMainWindow()
        {
            return (this);
        }

        public BookGenreRepository GetGenreDB()
        {
            return DBGenre;
        }

        public MagazineRepository GetMagazineDB()
        {

            return DBMagazine;
        }

        public MagazineTypeRepository GetTypeDB(){
            return DBType;
        }
        }

    }

