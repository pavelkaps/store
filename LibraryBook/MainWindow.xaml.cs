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


namespace LibraryBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookRepository DBBook;
        public MainWindow()
        {
            //DBBook = new BookRepository();
            //InitializeComponent();
            //DataView1.ItemsSource = DBBook.Load();
         }

        private void Add(object sender, RoutedEventArgs e)
        {
             //Book user1 = new Book();
             //DBBook.Insert(user1);

                }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
           
        }
            
        }

        


       
    }

