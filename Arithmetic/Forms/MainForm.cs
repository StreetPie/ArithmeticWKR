using System;
using System.Windows.Forms;
using Arithmetic.Models;
using Arithmetic.Services;

namespace Arithmetic.Forms
{
    public partial class MainForm : Form
    {
        private readonly UserSessionService _session;

        public MainForm(UserSessionService session)
        {
            _session = session;
            InitializeComponent();

            var user = _session.CurrentUser;
            labelWelcome.Text = $"Здравствуйте, {user.FirstName} {user.LastName}";

            if (user.RoleId == 1)
            {
               // labelClass.Text = $"Класс: {user.Class?.Name}";
            }
        }
    }

}
