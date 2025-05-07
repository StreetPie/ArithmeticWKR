using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;
using Arithmetic.Services;

namespace Arithmetic.UserControls
{
    public partial class MoveStudentPanel : UserControl
    {
        private readonly AppDbContext _context;
        private readonly User _student;

        public event EventHandler StudentMoved;

        public MoveStudentPanel(AppDbContext context, User student)
        {
            InitializeComponent();
            _context = context;
            _student = student;

            LoadClasses();
        }

        private void LoadClasses()
        {
            var classes = _context.Classes.ToList();
            comboClasses.DataSource = classes;
            comboClasses.DisplayMember = "Name";
            comboClasses.ValueMember = "Id";
            comboClasses.SelectedValue = _student.ClassId;

            labelCurrentClass.Text = $"Текущий класс: {_student.Class?.Name}";
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (comboClasses.SelectedItem is Class selectedClass)
            {
                if (selectedClass.Id == _student.ClassId)
                {
                    MessageBox.Show("Ученик уже в этом классе.");
                    return;
                }

                _student.ClassId = selectedClass.Id;
                _context.SaveChanges();

                MessageBox.Show("Ученик переведён.");
                StudentMoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
