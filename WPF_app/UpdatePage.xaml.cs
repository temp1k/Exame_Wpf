using System.Linq;
using System.Windows;

namespace WPF_app
{
    /// <summary>
    /// Логика взаимодействия для UpdatePage.xaml
    /// </summary>
    public partial class UpdatePage : Window
    {
        wpfCrudEntities _db = new wpfCrudEntities();
        int Id;
        Members updateMember;

        public UpdatePage(int memberId)
        {
            InitializeComponent();
            Id = memberId;
            Load();
        }

        private void Load()
        {
            updateMember = (from m in _db.Members
                            where m.ID == Id
                            select m).Single();

            tbName.Text = updateMember.name;

            cmbGender.ItemsSource = _db.Genders.ToList();
            cmbGender.DisplayMemberPath = "name";
            cmbGender.SelectedValuePath = "ID";
            cmbGender.SelectedValue = updateMember.gender;
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            updateMember.name = tbName.Text;
            updateMember.gender = (int)cmbGender.SelectedValue;
            _db.SaveChanges();
            MainWindow.dataGrid.ItemsSource = _db.Members.ToList();
            this.Hide();
        }
    }
}
