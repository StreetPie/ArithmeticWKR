using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Arithmetic.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arithmetic.Forms
{
    public partial class LoginForm2 : Form
    {
        private readonly AppDbContext _dbContext;
        private readonly IServiceProvider _serviceProvider;

        public LoginForm2(AppDbContext dbContext, IServiceProvider serviceProvider)
        {
            _dbContext = dbContext;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            LoadClasses();
        }

        private void LoadClasses()
        {
            var classes = _dbContext.Classes.OrderBy(c => c.Name).ToList();
            comboBoxClasses.DataSource = classes;
            comboBoxClasses.DisplayMember = "Name";
            comboBoxClasses.ValueMember = "Id";
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            int classId = (int)comboBoxClasses.SelectedValue;
            var users = _dbContext.Users.Where(u => u.ClassId == classId && u.RoleId == (radioButtonStudent.Checked ? 1 : 2)).OrderBy(u => u.Login).ToList();
            comboBoxUsers.DataSource = users;
            comboBoxUsers.DisplayMember = "Login";
            comboBoxUsers.ValueMember = "Id";
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            LoadClasses(); // Перезагрузить список под нужную роль
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = comboBoxUsers.SelectedItem as Arithmetic.Models.User;

            if (user != null && textBoxPassword.Text == user.Password)
            {
                Form formToOpen = null;
                switch (user.RoleId)
                {
                    case 1:
                        formToOpen = _serviceProvider.GetRequiredService<MainForm>();
                        break;
                    case 2:
                        formToOpen = _serviceProvider.GetRequiredService<TeacherForm>();
                        break;
                    case 3:
                        formToOpen = _serviceProvider.GetRequiredService<AdminForm>();
                        break;
                }

                if (formToOpen != null)
                {
                    formToOpen.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
