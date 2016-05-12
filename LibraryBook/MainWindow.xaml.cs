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
        public EntityRepository<Book> BookRepository;
        public EntityRepository<BookGenre> GenreRepository;
        public EntityRepository<MagazineType> TypeRepository;
        public EntityRepository<Magazine> MagazineRepository;
        public LibraryContext LibraryContext;
        public List<BookGenre> AllList;
        public MainWindow()
        {
            LibraryContext = new LibraryContext();

            BookRepository = new EntityRepository<Book>(LibraryContext);
            GenreRepository = new EntityRepository<BookGenre>(LibraryContext);
            TypeRepository = new EntityRepository<MagazineType>(LibraryContext);
            MagazineRepository = new EntityRepository<Magazine>(LibraryContext);

            InitializeComponent();

            EntityBox.SelectedIndex = 0;
            MagazineGrid.Visibility = Visibility.Collapsed;
            
            LoadCombobox();
            BookLoad();
        }
        private void LoadCombobox()
        {
            LoadBookCombobox();
            LoadMagazineCombobox();
            
            TypeBox.Visibility = Visibility.Collapsed;
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            BookOrMagazine form = new BookOrMagazine(this);
            form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            if (form.ShowDialog() == true)
            {
                UpdateDataGrid();
                LoadMagazineCombobox();
                LoadBookCombobox();
            }
        }

        public void LoadBookCombobox(){

            BookGenre AllMenu = new BookGenre { Title = "Все", Id = 99 };

            AllList = new List<BookGenre>();
            AllList.Add(AllMenu);
            foreach (BookGenre item in GetGenreDB().Load())
            {
                AllList.Add(item);
            }
            GenreBox.ItemsSource = AllList;
            
            GenreBox.SelectedValuePath = "Id";
            GenreBox.DisplayMemberPath = "Title";
           
        }

        public void LoadMagazineCombobox()
        {
            MagazineType AllType = new MagazineType { Title = "Все", Id = 0 };

            List<MagazineType> AllList = new List<MagazineType>();
            AllList.Add(AllType);
            foreach (MagazineType item in GetTypeDB().Load())
            {
                AllList.Add(item);
            }
            TypeBox.ItemsSource = AllList;
            TypeBox.SelectedValuePath = "Id";
            TypeBox.DisplayMemberPath = "Title";
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {

        }

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Book path = BookGrid.SelectedItem as Book;
                AboutBook frm = new AboutBook(path, this);
                frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                frm.ShowDialog();
                UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите книгу", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void LoadGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = "  " + (e.Row.GetIndex() + 1) + "  ";
        }


        private void BookLoad()
        {

            BookGrid.ItemsSource = BookRepository.Load();//.ToBindingList();
            TypeLabel.Text = "Выберите жанр:";
            
            SeachBook.Visibility = Visibility.Visible;
            SeachMagazine.Visibility = Visibility.Collapsed;

            GenreBox.Visibility = Visibility.Visible;
            TypeBox.Visibility = Visibility.Collapsed;
            LoadBookCombobox();
        }

        private void MagazineLoad()
        {
            MagazineGrid.ItemsSource = MagazineRepository.Load();//.Local.ToBindingList();
            TypeLabel.Text = "Выберите тип:";
            
            SeachMagazine.Visibility = Visibility.Visible;
            SeachBook.Visibility = Visibility.Collapsed;

            TypeBox.Visibility = Visibility.Visible;
            GenreBox.Visibility = Visibility.Collapsed;
            LoadMagazineCombobox();
        }

        private void EntityBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги") { MagazineGrid.Visibility = Visibility.Collapsed; BookGrid.Visibility = Visibility.Visible; BookLoad(); }
            if (selectedItem.Content.ToString() == "Журналы") { BookGrid.Visibility = Visibility.Collapsed; MagazineGrid.Visibility = Visibility.Visible; MagazineLoad(); } 
            
        }

        public void DefaultDataGrid()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)EntityBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги") { MagazineGrid.Visibility = Visibility.Collapsed; BookGrid.Visibility = Visibility.Visible; BookLoad(); }
            if (selectedItem.Content.ToString() == "Журналы") { BookGrid.Visibility = Visibility.Collapsed; MagazineGrid.Visibility = Visibility.Visible; MagazineLoad(); } 
        }
        public void UpdateDataGrid()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)EntityBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги")
            {
                BookGrid.ItemsSource = null;
                BookLoad();
            }
            else
            {
                MagazineGrid.ItemsSource = null;
                MagazineLoad();
            }
        }

        public EntityRepository<Book> GetBookDb()
        {
            return BookRepository;
        }

        public MainWindow GetMainWindow()
        {
            return (this);
        }

        public EntityRepository<BookGenre> GetGenreDB()
        {
            return GenreRepository;
        }

        public EntityRepository<Magazine> GetMagazineDB()
        {
            return MagazineRepository;
        }

        public EntityRepository<MagazineType> GetTypeDB()
        {
            return TypeRepository;
        }

        private void MagazineGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Magazine path = MagazineGrid.SelectedItem as Magazine;
                AboutMagazine frm = new AboutMagazine(this, path);
                frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                frm.ShowDialog();
                UpdateDataGrid();
            }
            catch (Exception)
            {
                MessageBox.Show("Выберите журнал", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Seach_Click(object sender, RoutedEventArgs e)
        {
            SeachForm form = new SeachForm(this);
            form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            form.SetAsBook();
            form.Show();
        }

        private void SeachMagazine_Click(object sender, RoutedEventArgs e)
        {
            SeachForm form = new SeachForm(this);
            form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            form.SetAsMagazine();
            form.Show();
        }

        private void TypeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookGenre GenreBook = (BookGenre)GenreBox.SelectedItem;
           
             BookGrid.ItemsSource = GenreBook.Books;
        }

        private void TypeSelect(object sender, SelectionChangedEventArgs e)
        {
            MagazineType TypeMagazine = (MagazineType)TypeBox.SelectedItem;
            MagazineGrid.ItemsSource = TypeMagazine.Magazines;
        }

        public void SetSourceForBookDataGrid(List<Book> a)
        {
            BookGrid.ItemsSource = null;
            //BookLoad();
            BookGrid.ItemsSource = a;
        }
        public void SetSourceForMagazineDataGrid(List<Magazine> a)
        {
            MagazineGrid.ItemsSource = null;
            //BookLoad();
            MagazineGrid.ItemsSource = a;
        }

    }
}
