using System.Linq;
using System.Windows;

namespace WPF_app
{
    /// <summary>
    /// Логика взаимодействия для InsertPage.xaml
    /// </summary>
    public partial class InsertPage : Window
    {
        private wpfCrudEntities _db = new wpfCrudEntities();

        public InsertPage()
        {
            InitializeComponent();
            Load();
        }

        private void Load()
        {
            cmbGender.ItemsSource = _db.Genders.ToList();
            cmbGender.DisplayMemberPath = "name";
            cmbGender.SelectedValuePath = "ID";
        }


        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            Members newMember = new Members()
            {
                name = tbName.Text,
                gender = (int)cmbGender.SelectedValue
            };

            _db.Members.Add(newMember);
            _db.SaveChanges();
            this.Hide();
            MainWindow.dataGrid.ItemsSource = _db.Members.ToList();
        }
    }
}
