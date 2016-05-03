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
    /// Логика взаимодействия для BookOrMagazine.xaml
    /// </summary>
    public partial class BookOrMagazine : Window
    {
        AddBook AddBookForm;
        AddMagazine AddMagazineForm;
        AddType AddTypeForm;
        MainWindow main;
        
        public BookOrMagazine(MainWindow _main)
        {
            main = _main;
            InitializeComponent();
        }

        private void AddBook(object sender, RoutedEventArgs e)
        {
            AddBookForm = new AddBook(main);
            AddBookForm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (AddBookForm.ShowDialog() == true)
            {
                this.DialogResult = true;
                this.Close();
            }
            this.DialogResult = false;
            Close();
        }

        private void AddMagazine(object sender, RoutedEventArgs e)
        {
            AddMagazineForm = new AddMagazine(main);
            AddMagazineForm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (AddMagazineForm.ShowDialog() == true)
            {
                this.DialogResult = true;
                this.Close();
            }

            this.DialogResult = false;
            Close();
        }

        private void AddType(object sender, RoutedEventArgs e)
        {
            AddTypeForm = new AddType(main);
            AddTypeForm.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            if (AddTypeForm.ShowDialog() == true)
            {
                this.DialogResult = true;
                this.Close();
            }
            this.DialogResult = false;
            Close();
        }

        

    }
}
