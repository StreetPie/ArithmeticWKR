using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;

namespace Arithmetic.UserControls
{
    public partial class EditUserPanel : UserControl
    {
        private readonly AppDbContext _context;
        private readonly User _user;

        public event EventHandler UserUpdated;

        public EditUserPanel(AppDbContext context, User user)
        {
            InitializeComponent();
            _context = context;
            _user = user;
            LoadData();
        }

        private void LoadData()
        {
            txtFirstName.Text = _user.FirstName;
            txtLastName.Text = _user.LastName;
            datePicker.Value = _user.DateOfBirth;

            if (_user.RoleId == 1)
            {
                comboClass.DataSource = _context.Classes.ToList();
                comboClass.DisplayMember = "Name";
                comboClass.ValueMember = "Id";
                comboClass.SelectedValue = _user.ClassId;
                comboClass.Visible = true;
                labelClass.Visible = true;
            }
            else
            {
                comboClass.Visible = false;
                labelClass.Visible = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _user.FirstName = txtFirstName.Text;
            _user.LastName = txtLastName.Text;
            _user.DateOfBirth = datePicker.Value;

            if (_user.RoleId == 1 && comboClass.SelectedItem is Class selectedClass)
            {
                _user.ClassId = selectedClass.Id;
            }

            _context.Users.Update(_user);
            _context.SaveChanges();

            MessageBox.Show("Изменения сохранены.");
            UserUpdated?.Invoke(this, EventArgs.Empty);
        }
    }
}
