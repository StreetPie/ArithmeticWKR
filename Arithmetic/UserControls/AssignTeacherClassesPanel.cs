using System;
using System.Linq;
using System.Windows.Forms;
using Arithmetic.Database;
using Arithmetic.Models;

namespace Arithmetic.UserControls
{
    public partial class AssignTeacherClassesPanel : UserControl
    {
        private readonly AppDbContext _context;
        private readonly User _teacher;

        public AssignTeacherClassesPanel(AppDbContext context, User teacher)
        {
            InitializeComponent();
            _context = context;
            _teacher = teacher;

            LoadClasses();
        }

        private void LoadClasses()
        {
            var allClasses = _context.Classes.ToList();
            var assignedIds = _context.TeacherClasses
                .Where(tc => tc.UserId == _teacher.Id)
                .Select(tc => tc.ClassId)
                .ToHashSet();

            checkedListBoxClasses.Items.Clear();
            foreach (var c in allClasses)
            {
                bool isChecked = assignedIds.Contains(c.Id);
                checkedListBoxClasses.Items.Add(c, isChecked);
            }

            labelTeacher.Text = $"Учитель: {_teacher.LastName} {_teacher.FirstName}";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var selectedClasses = checkedListBoxClasses.CheckedItems
                .OfType<Class>()
                .Select(c => c.Id)
                .ToList();

            var current = _context.TeacherClasses
                .Where(tc => tc.UserId == _teacher.Id)
                .ToList();

            foreach (var classId in selectedClasses)
            {
                _context.TeacherClasses.Add(new TeacherClass
                {
                    UserId = _teacher.Id,
                    ClassId = classId
                });
            }



            _context.SaveChanges();
            MessageBox.Show("Классы обновлены.");
        }
    }
}
