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
            
            LoadCombobox();
            BookLoad();
        }
        private void LoadCombobox()
        {
            TypeBox.ItemsSource = GetTypeDB().Load().Local.ToList();
            TypeBox.SelectedValuePath = "Id";
            TypeBox.DisplayMemberPath = "type";
            
            
            GenreBox.ItemsSource = GetGenreDB().Load().Local.ToList();
            GenreBox.SelectedValuePath = "Id";
            GenreBox.DisplayMemberPath = "Genre";
            
            TypeBox.Visibility = Visibility.Collapsed;
        }
        private void Add(object sender, RoutedEventArgs e)
        {
            BookOrMagazine form = new BookOrMagazine(this);
            form.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

            if (form.ShowDialog() == true)
            {
                UpdateDataGrid();
            }
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {

        }

        private void grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Book path = BookGrid.SelectedItem as Book;
            AboutBook frm = new AboutBook(path, this);
            frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            frm.ShowDialog();
            
            UpdateDataGrid();
        }

        private void LoadGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = "  " + (e.Row.GetIndex() + 1) + "  ";
        }


        private void BookLoad()
        {
            BookGrid.ItemsSource = DBBook.Load().Local.ToBindingList();
            TypeLabel.Text = "Выберите жанр:";
            
            SeachBook.Visibility = Visibility.Visible;
            SeachMagazine.Visibility = Visibility.Collapsed;

            GenreBox.Visibility = Visibility.Visible;
            TypeBox.Visibility = Visibility.Collapsed;
        }

        private void MagazineLoad()
        {
            MagazineGrid.ItemsSource = DBMagazine.Load().Local.ToBindingList();
            TypeLabel.Text = "Выберите тип:";
            
            SeachMagazine.Visibility = Visibility.Visible;
            SeachBook.Visibility = Visibility.Collapsed;

            TypeBox.Visibility = Visibility.Visible;
            GenreBox.Visibility = Visibility.Collapsed;
        }

        private void EntityBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги") { MagazineGrid.Visibility = Visibility.Collapsed; BookGrid.Visibility = Visibility.Visible; BookLoad(); }
            if (selectedItem.Content.ToString() == "Журналы") { BookGrid.Visibility = Visibility.Collapsed; MagazineGrid.Visibility = Visibility.Visible; MagazineLoad(); } //MagazineLoad();BookLoad();

        }

        public void DefaultDataGrid()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)EntityBox.SelectedItem;
            if (selectedItem.Content.ToString() == "Книги") { MagazineGrid.Visibility = Visibility.Collapsed; BookGrid.Visibility = Visibility.Visible; BookLoad(); }
            if (selectedItem.Content.ToString() == "Журналы") { BookGrid.Visibility = Visibility.Collapsed; MagazineGrid.Visibility = Visibility.Visible; MagazineLoad(); } //MagazineLoad();BookLoad();
        }
        public void UpdateDataGrid()
        {
            BookGrid.ItemsSource = null;
            BookLoad();
            MagazineGrid.ItemsSource = null;
            MagazineLoad();
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

        public MagazineTypeRepository GetTypeDB()
        {
            return DBType;
        }



        private void MagazineGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Magazine path = MagazineGrid.SelectedItem as Magazine;
            AboutMagazine frm = new AboutMagazine(this, path);
            frm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            frm.ShowDialog();
            UpdateDataGrid();
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
            BookGenre BookGenre = (BookGenre)GenreBox.SelectedItem;
             BookGrid.ItemsSource = BookGenre.Books;
        }

        private void TypeSelect(object sender, SelectionChangedEventArgs e)
        {
            MagazineType TypeMagazine = (MagazineType)TypeBox.SelectedItem;
            MagazineGrid.ItemsSource = TypeMagazine.journals;
        }

    }
}
