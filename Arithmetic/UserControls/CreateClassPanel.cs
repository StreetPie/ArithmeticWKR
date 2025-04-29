using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;

namespace Arithmetic.UserControls
{
    public partial class CreateClassPanel : UserControl
    {
        private readonly AppDbContext _context;

        public CreateClassPanel(AppDbContext context)
        {
            InitializeComponent();
            _context = context;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string name = txtClassName.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Введите название класса");
                return;
            }

            bool exists = _context.Classes.Any(c => c.Name.ToLower() == name.ToLower());
            if (exists)
            {
                MessageBox.Show("Класс с таким названием уже существует");
                return;
            }

            var newClass = new Class { Name = name };
            _context.Classes.Add(newClass);
            _context.SaveChanges();

            MessageBox.Show("Класс создан");
            txtClassName.Clear();
        }
    }
}
