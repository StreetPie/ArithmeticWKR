using System;
using System.Windows.Forms;
using Arithmetic.Models;


namespace Arithmetic.Forms
{
    public partial class TeacherForm : Form
    {
        private readonly User _user;

      //  public TeacherForm(User user)
            public TeacherForm()
        {
            InitializeComponent();
            //_user = user;
        }

        private void TeacherForm_Load(object sender, EventArgs e)
        {

        }
        private void buttonTaskConstructor_Click(object sender, EventArgs e)
        {
            var constructorForm = new TaskConstructorForm();
            constructorForm.ShowDialog();
        }


    }
}
