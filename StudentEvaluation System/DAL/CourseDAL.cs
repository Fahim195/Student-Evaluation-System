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
    class CourseDAL
    {
        public DataTable ViewCoursesInGridviewDAL()
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Select id,Courseid,CourseDetails,Section,Semister from Course";
            SqlCommand action = new SqlCommand(query, connection);
            DataTable dTable = new DataTable();
            SqlDataAdapter Sda = new SqlDataAdapter();
            Sda.SelectCommand = action;
            Sda.Fill(dTable);
            return dTable;
        }
        public bool SAVECourseDAL(Course aCourse)
        {
            string Details =aCourse.CourseID + " " + aCourse.Section + " " + aCourse.Semister;
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "insert into Course values('"+aCourse.CourseID+"','"+aCourse.CourseTitles+"','"+aCourse.Section+"','"+aCourse.Semister+"','"+Details+"')";
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
        public bool UpdateCourseDAL(Course aCourse,int id)
        {
            string Details = aCourse.CourseID + " " + aCourse.Section + " " + aCourse.Semister;
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "UPDATE Course set CourseID='" + aCourse.CourseID + "',CourseDetails='" + aCourse.CourseTitles + "',section='" + aCourse.Section + "',semister='" + aCourse.Semister + "' , details='"+Details+"'  where  ID="+id+"";
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
        public bool DeleteDAL(int id)
        {
            SqlConnection connection = DBconnection.OpenConnection();
            string query = "Delete Course where ID="+id+"";
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
