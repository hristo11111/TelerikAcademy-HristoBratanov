using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _04.StudentsRegistration
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.form1.Controls.Add(new LiteralControl("<br>"));
            Button SubmitButton = new Button();
            SubmitButton.Text = "Submit";
            SubmitButton.ID = "ButtonSubmit";
            SubmitButton.Click += ShowStudentInfo;
            this.form1.Controls.Add(SubmitButton);


        }

        private void ShowStudentInfo(object sender, EventArgs e)
        {
            string fName = this.TbFirstName.Text;
            string lName = this.TbLastName.Text;
            long facultyNum = long.Parse(this.TbFacultyNumber.Text);
            string university = this.DropDownListUniversity.SelectedItem.ToString();
            string specialty = this.DropDownListSpecialty.SelectedItem.ToString();
            List<string> courses = new List<string>();

            foreach (ListItem listitem in this.ListBoxCourses.Items)
            {
                if (listitem.Selected)
                {
                    courses.Add(listitem.ToString());
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Student: " + fName + " ");
            sb.Append(lName + " ");
            sb.Append("faculty number: " + facultyNum + " ");
            sb.Append("university: " + university + " ");
            sb.Append("specialty: " + specialty + " ");
            sb.Append("courses: ");
            foreach (var item in courses)
            {
                sb.Append(item + " ");
            }

            this.form1.Controls.Add(new Literal { Text = sb.ToString() });
        }
    }
}