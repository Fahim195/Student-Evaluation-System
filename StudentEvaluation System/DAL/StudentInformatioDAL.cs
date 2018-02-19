using StudentEvaluation_System.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation_System.DAL
{
    class StudentInformatioDAL
    {
        public DataTable LoadComboboxDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Details from Course";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;
        }
        public DataTable ViewStudentInformationDAL(string Details)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select Students.StudentID,Students.Name,Course.CourseID from Students join Course on Course.ID = Students.CID where  Course.Details='"+ Details+ "'";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool SAVEStudentDAL(StudentInformation aStudent, string Details)
        {
            
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "insert into Students(CID,StudentID,Name) values((select ID from Course where Course.Details='"+Details+"'),'"+aStudent.StudentID+"','"+aStudent.name+"' )";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UpdateStudentDAL(StudentInformation aStudent, string Details)
        {

            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Update Students  Set CID=(select ID from Course where Course.Details='" + Details + "'),StudentID='" + aStudent.StudentID + "',Name='" + aStudent.name + "' ";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteStudentDAL(StudentInformation aStudent, string Details)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Delete Students  where CID=(select ID from Course where CourseID='" + Details + "') and StudentID='" + aStudent.StudentID + "' and Name='" + aStudent.name + "' ";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
          public DataTable EvaluationInformationInTextboxDAL(StudentInformation aStudent,string details)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "select *  from Students join Course on Course.ID=Students.CID where Students.StudentID='" + aStudent.StudentID+"' and students.CID=(select ID from course where details='"+details+"')";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool SaveEvaluationDAL(StudentInformation aStudent,Course aCourse)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Update Students  Set Attendance=" + aStudent.Attendance + ",Presentation=" + aStudent.Presentation + ",Assignment=" + aStudent.Assignment + ",Quiz1=" + aStudent.Quiz1 + ",Quiz2=" + aStudent.Quiz2 + ",Quiz3=" + aStudent.Quiz3 + ",QUIZ=" + aStudent.QUIZ + " ,Midterm=" + aStudent.Mid + ",Final=" + aStudent.Final+",TotalMarks="+aStudent.Total+",EvaluationGrade='"+aStudent.EvaluationGrade+"' where  Students.StudentID='" + aStudent.StudentID + "' and students.CID=(select ID from course where CourseID='"+aCourse.CourseID+"')";
            SqlCommand Action = new SqlCommand(query, connection);
            int Result = Action.ExecuteNonQuery();
            if (Result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
