using StudentEvaluation_System.BLL;
using StudentEvaluation_System.DAL.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentEvaluation_System.UIL
{
    public partial class CourseInformation : Form
    {
        public CourseInformation()
        {
            InitializeComponent();
        }

        private void CourseInformation_Load(object sender, EventArgs e)
        {
            LoadCoursesDataGridView();
            StudentInformation_panel3.Visible = false;
            Evaluation_panel3.Visible = false;
        }
        public void LoadCoursesDataGridView()
        {
            CourseBLL aCourseBLL = new CourseBLL();
            DataTable dt = aCourseBLL.ViewCoursesInGridviewBLL();
            ViewCoursesdataGridView1.DataSource = dt;
        }

        private void Course_Savebutton1_Click(object sender, EventArgs e)
        {
            Course aCourse = new Course();
            aCourse.CourseID = COURSE_CourseIDtextBox1.Text;
            aCourse.CourseTitles = COURSE_CourseTitletextBox2.Text;
            aCourse.Section = COURSE_SectiontextBox3.Text;
            aCourse.Semister = COURSE_SemistercomboBox1.Text;

            CourseBLL aCourseBLL = new CourseBLL();
            bool res = aCourseBLL.SAVECourseBLL(aCourse);
            if (res)
            {
                MessageBox.Show("Course Save Successfully!!!");
                clearCourseTextBoxes();
                LoadCoursesDataGridView();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void CourseUpdatebutton2_Click(object sender, EventArgs e)
        {
            Course aCourse = new Course();
            aCourse.CourseID = COURSE_CourseIDtextBox1.Text;
            aCourse.CourseTitles = COURSE_CourseTitletextBox2.Text;
            aCourse.Section = COURSE_SectiontextBox3.Text;
            aCourse.Semister = COURSE_SemistercomboBox1.Text;
            int id = int.Parse(Ruff_label7.Text);
            CourseBLL aCourseBLL = new CourseBLL();
            bool res = aCourseBLL.UpdateCourseBLL(aCourse, id);
            if (res)
            {
                MessageBox.Show("Course Updates Successfully!!!");
                clearCourseTextBoxes();
                LoadCoursesDataGridView();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void ViewCoursesdataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Ruff_label7.Text = ViewCoursesdataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            COURSE_CourseIDtextBox1.Text = ViewCoursesdataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            COURSE_CourseTitletextBox2.Text = ViewCoursesdataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            COURSE_SemistercomboBox1.Text = ViewCoursesdataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            COURSE_SectiontextBox3.Text = ViewCoursesdataGridView1.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void CourseDeletebutton3_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Ruff_label7.Text);
            CourseBLL aCourseBLL = new CourseBLL();
            bool res = aCourseBLL.DeleteBLL(id);
            if (res)
            {
                MessageBox.Show("Course deleted Successfully!!!");
                clearCourseTextBoxes();
                LoadCoursesDataGridView();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void Clearbutton1_Click(object sender, EventArgs e)
        {
            clearCourseTextBoxes();
        }
        public void clearCourseTextBoxes()
        {
            Ruff_label7.Text = "";
            COURSE_CourseIDtextBox1.Text = "";
            COURSE_CourseTitletextBox2.Text = "";
            COURSE_SectiontextBox3.Text = "";
            COURSE_SemistercomboBox1.Text = "";
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COURSEpanel3.Visible = true;
            StudentInformation_panel3.Visible = false;
            Evaluation_panel3.Visible = false;
            ClearComboBox();
        }
        public void ClearComboBox()
        {
            
            Evaluation_CourseDetailscomboBox1.Items.Clear();
            SelectCourse_comboBox1.Items.Clear();
        }
        private void studentInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearComboBox();
            Evaluation_panel3.Visible = false;
            COURSEpanel3.Visible = false;
            StudentInformation_panel3.Visible = true;
            StudentInformationBLL aStudent = new StudentInformationBLL();
            DataTable dt = aStudent.LoadComboboxBLL();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SelectCourse_comboBox1.Items.Add(dt.Rows[i][0]);
            }
        }

        private void evaluationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearComboBox();
            COURSEpanel3.Visible = false;
            StudentInformation_panel3.Visible = false;
            Evaluation_panel3.Visible = true;
            StudentInformationBLL aStudent = new StudentInformationBLL();
            DataTable dt = aStudent.LoadComboboxBLL();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Evaluation_CourseDetailscomboBox1.Items.Add(dt.Rows[i][0]);
            }
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            COURSEpanel3.Visible = false;
            StudentInformation_panel3.Visible = false;
            Evaluation_panel3.Visible = false;
        }

        private void SelectCourse_comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadStudentInformation();
        }
        public void LoadStudentInformation()
        {
            string Details = SelectCourse_comboBox1.Text;
            StudentInformationBLL aStudent = new StudentInformationBLL();
            DataTable dt2 = aStudent.ViewStudentInformationBLL(Details);
            StudentInformationdataGridView1.DataSource = dt2;
        }

        private void StudentSAVEbutton1_Click(object sender, EventArgs e)
        {
            string Details = SelectCourse_comboBox1.Text;
            StudentInformation aStudent = new StudentInformation();
            aStudent.StudentID = StudentIDtextBox2.Text;
            aStudent.name = StudentNAmetextBox1.Text;
            StudentInformationBLL aStudents = new StudentInformationBLL();
            bool res = aStudents.SAVEStudentBLL(aStudent, Details);
            if (res)
            {
                MessageBox.Show("Student Information Saved Successfully!!!");
                LoadStudentInformation();
                StudentIDtextBox2.Text = "";
                StudentNAmetextBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void StudentUpdatebutton2_Click(object sender, EventArgs e)
        {
            string Details = SelectCourse_comboBox1.Text;
            StudentInformation aStudent = new StudentInformation();
            aStudent.StudentID = StudentIDtextBox2.Text;
            aStudent.name = StudentNAmetextBox1.Text;
            StudentInformationBLL aStudents = new StudentInformationBLL();
            bool res = aStudents.UpdateStudentBLL(aStudent, Details);
            if (res)
            {
                MessageBox.Show("Student Information Updated Successfully!!!");
                LoadStudentInformation();
                StudentIDtextBox2.Text = "";
                StudentNAmetextBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void StudentInformationdataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            SelectCourse_comboBox1.Text = StudentInformationdataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            StudentNAmetextBox1.Text = StudentInformationdataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            StudentIDtextBox2.Text = StudentInformationdataGridView1.SelectedRows[0].Cells[0].Value.ToString();
        }

        private void StudentDeletebutton3_Click(object sender, EventArgs e)
        {
            string Details = SelectCourse_comboBox1.Text;
            StudentInformation aStudent = new StudentInformation();
            aStudent.StudentID = StudentIDtextBox2.Text;
            aStudent.name = StudentNAmetextBox1.Text;
            StudentInformationBLL aStudents = new StudentInformationBLL();
            bool res = aStudents.DeleteStudentBLL(aStudent, Details);
            if (res)
            {
                MessageBox.Show("Student Information Deleted Successfully!!!");
                LoadStudentInformation();
                StudentIDtextBox2.Text = "";
                StudentNAmetextBox1.Text = "";

            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void StudentCancelbutton4_Click(object sender, EventArgs e)
        {
            LoadStudentInformation();
            StudentIDtextBox2.Text = "";
            StudentNAmetextBox1.Text = "";
            SelectCourse_comboBox1.Text = "";
        }

        private void Evaluation_CourseDetailscomboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEvaluationStudentInformation();
        }
        public void LoadEvaluationStudentInformation()
        {
            string Details = Evaluation_CourseDetailscomboBox1.Text;
            StudentInformationBLL aStudent = new StudentInformationBLL();
            DataTable dt2 = aStudent.ViewStudentInformationBLL(Details);
            EvaluationdataGridView1.DataSource = dt2;
        }

        private void EvaluationdataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string Details = Evaluation_CourseDetailscomboBox1.Text;
            StudentInformation aStudent = new StudentInformation();
            aStudent.StudentID = EvaluationdataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            aStudent.CID = EvaluationdataGridView1.SelectedRows[0].Cells[2].Value.ToString();

            StudentInformationBLL aStudents = new StudentInformationBLL();
            DataTable dt2 = aStudents.EvaluationInformationInTextboxBLL(aStudent, Details);
            try
            {
                EvaluationCoursetextBox1.Text = dt2.Rows[0][16].ToString();
                Evaluation_StudentNametextBox2.Text = dt2.Rows[0][3].ToString();
                EvaluationStudenIDtextBox3.Text = dt2.Rows[0][2].ToString();

                Quiz_1textBox12.Text = dt2.Rows[0][7].ToString();
                Quiz_2textBox10.Text = dt2.Rows[0][8].ToString();
                Quiz_3textBox14.Text = dt2.Rows[0][9].ToString();
                QUIZ_textBox9.Text = dt2.Rows[0][10].ToString();
                Attendance_textBox8.Text = dt2.Rows[0][4].ToString();
                AssignmenttextBox4.Text = dt2.Rows[0][6].ToString();
                MidtermtextBox5.Text = dt2.Rows[0][11].ToString();
                FinaltextBox6.Text = dt2.Rows[0][12].ToString();
                PresentationtextBox7.Text = dt2.Rows[0][5].ToString();
                TotalMarkstextBox13.Text = dt2.Rows[0][13].ToString();
                EvaluationGrade.Text = dt2.Rows[0][14].ToString();

            }
            catch
            {
                MessageBox.Show("dufgy");

            }
        }

        private void Quiz_1textBox12_TextChanged(object sender, EventArgs e)
        {
            
            float Quiz1 = 0;
            float Quiz2 = 0;
            float Quiz3 = 0;
            float Quiz = 0;
            float.TryParse(Quiz_1textBox12.Text,out Quiz1);
            float.TryParse(Quiz_2textBox10.Text, out Quiz2);
           float.TryParse(Quiz_3textBox14.Text, out Quiz3);
            Quiz = (Quiz1 + Quiz2 + Quiz3) / 3;
            QUIZ_textBox9.Text=Quiz.ToString();


        }

        private void Quiz_2textBox10_TextChanged(object sender, EventArgs e)
        {
            float Quiz1 = 0;
            float Quiz2 = 0;
            float Quiz3 = 0;
            float Quiz = 0;
            float.TryParse(Quiz_1textBox12.Text, out Quiz1);
            float.TryParse(Quiz_2textBox10.Text, out Quiz2);
            float.TryParse(Quiz_3textBox14.Text, out Quiz3);
            Quiz = (Quiz1 + Quiz2 + Quiz3) / 3;
            QUIZ_textBox9.Text = Quiz.ToString();

        }

        private void Quiz_3textBox14_TextChanged(object sender, EventArgs e)
        {
            float Quiz1 = 0;
            float Quiz2 = 0;
            float Quiz3 = 0;
            float Quiz = 0;
            float.TryParse(Quiz_1textBox12.Text, out Quiz1);
            float.TryParse(Quiz_2textBox10.Text, out Quiz2);
            float.TryParse(Quiz_3textBox14.Text, out Quiz3);
            Quiz = (Quiz1 + Quiz2 + Quiz3) / 3;
            QUIZ_textBox9.Text = Quiz.ToString();
        }
        public void CalculateTotalMarks()
        {
            float Quiz = 0;
            float Attendance = 0;
            float Assignment = 0;
            float Midterm = 0;
            float Final = 0;
            float presentation = 0;
            float total = 0;
            float.TryParse(QUIZ_textBox9.Text, out Quiz);
            float.TryParse(Attendance_textBox8.Text, out Attendance);
            float.TryParse(AssignmenttextBox4.Text, out Assignment);
            float.TryParse(MidtermtextBox5.Text, out Midterm);
            float.TryParse(FinaltextBox6.Text, out Final);
            float.TryParse(PresentationtextBox7.Text, out presentation);
            total = (Quiz + Attendance + Assignment + Midterm + Final + presentation);
            TotalMarkstextBox13.Text = total.ToString();
        }

        private void Attendance_textBox8_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalMarks();
        }

        private void QUIZ_textBox9_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalMarks();
        }

        private void AssignmenttextBox4_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalMarks();
        }

        private void PresentationtextBox7_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalMarks();
        }

        private void MidtermtextBox5_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalMarks();
        }

        private void FinaltextBox6_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalMarks();
        }

        private void TotalMarkstextBox13_TextChanged(object sender, EventArgs e)
        {
            float total = 0;
            string grade = "";
            float.TryParse(TotalMarkstextBox13.Text,out total);
            if (total < 40)
            {
                grade = "F";
            }
            else if (total > 79)
            {
                grade = "A+";
            }
            else if (total >= 40 && total<45)
            {
                grade = "D";
            }
            else if (total > 44 && total < 50)
            {
                grade = "C";
            }
            else if (total > 49 && total < 55)
            {
                grade = "C+";
            }
            else if (total > 54 && total < 60)
            {
                grade = "B-";
            }
            else if (total > 59 && total < 65)
            {
                grade = "B";
            }
            else if (total > 64 && total < 70)
            {
                grade = "B+";
            }
            else if (total > 69 && total < 75)
            {
                grade = "A-";
            }
            else
            {
                grade = "A";
            }

            EvaluationGrade.Text = grade;
        }

        private void SaveorUpdateEvaluationbutton1_Click(object sender, EventArgs e)
        {
            Course aCourse = new Course();
            aCourse.CourseID = EvaluationCoursetextBox1.Text;

            StudentInformation aStudent = new StudentInformation();
            aStudent.StudentID = EvaluationStudenIDtextBox3.Text;
            aStudent.Quiz1 = float.Parse(Quiz_1textBox12.Text);
            aStudent.Quiz2 = float.Parse(Quiz_2textBox10.Text);
            aStudent.Quiz3 = float.Parse(Quiz_3textBox14.Text);
            aStudent.QUIZ = float.Parse(QUIZ_textBox9.Text);
            aStudent.Assignment = float.Parse(AssignmenttextBox4.Text);
            aStudent.Attendance = float.Parse(Attendance_textBox8.Text);
            aStudent.Presentation = float.Parse(PresentationtextBox7.Text);
            aStudent.Mid = float.Parse(MidtermtextBox5.Text);
            aStudent.Final = float.Parse(FinaltextBox6.Text);
            aStudent.Total = float.Parse(TotalMarkstextBox13.Text);
            aStudent.EvaluationGrade = EvaluationGrade.Text;

            StudentInformationBLL aStudents = new StudentInformationBLL();
            bool res = aStudents.SaveEvaluationBLL(aStudent, aCourse);
            if (res)
            {
                MessageBox.Show("Marks Evaluated Successfully!!!");
                clearCourseTextBoxes();
                LoadCoursesDataGridView();
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Evaluation_StudentNametextBox2.Text = "";
            EvaluationStudenIDtextBox3.Text = "";
            EvaluationCoursetextBox1.Text = "";
            Quiz_1textBox12.Text = "";
            Quiz_2textBox10.Text = "";
            Quiz_3textBox14.Text = "";
            QUIZ_textBox9.Text = "";
            AssignmenttextBox4.Text = "";
            Attendance_textBox8.Text = "";
            PresentationtextBox7.Text = "";
            MidtermtextBox5.Text = "";
            FinaltextBox6.Text = "";
            TotalMarkstextBox13.Text = "";
            EvaluationGrade.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            LOGIN aLogin = new LOGIN();
            aLogin.Show();
            this.Hide();
        }
    }
}
