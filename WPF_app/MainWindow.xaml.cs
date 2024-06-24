using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace WPF_app
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static DataGrid dataGrid;
        public wpfCrudEntities _db = new wpfCrudEntities();
        public MainWindow()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            dgEntities.ItemsSource = _db.Members.ToList();
            dataGrid = dgEntities;
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            InsertPage IPage = new InsertPage();
            IPage.ShowDialog();
            
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (dgEntities.SelectedItem as Members).ID;

            UpdatePage UPage = new UpdatePage(id);
            UPage.ShowDialog();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            int id = (dgEntities.SelectedItem as Members).ID;
            var deleteMember = _db.Members.Where(m => m.ID == id).Single();

            MessageBoxResult result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника {deleteMember.name}?", "Удаление записи", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                _db.Members.Remove(deleteMember);
                _db.SaveChanges();
                dgEntities.ItemsSource = _db.Members.ToList();
            }
        }
    }
}
