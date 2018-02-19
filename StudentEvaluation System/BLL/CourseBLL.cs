using StudentEvaluation_System.DAL;
using StudentEvaluation_System.DAL.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEvaluation_System.BLL
{
    class CourseBLL
    {
        public DataTable ViewCoursesInGridviewBLL()
        {
            CourseDAL aCourseDAL = new CourseDAL();
            DataTable dt = aCourseDAL.ViewCoursesInGridviewDAL();
            return dt;
        }
        public bool SAVECourseBLL(Course aCourse)
        {
            if (aCourse.CourseID == "" || aCourse.CourseTitles == "" || aCourse.Semister == "" || aCourse.Section == "")
            {
                return false;
            }
            else
            {
                CourseDAL aCourseDAL = new CourseDAL();
                bool res = aCourseDAL.SAVECourseDAL(aCourse);
                return res;
            }
        }
        public bool UpdateCourseBLL(Course aCourse, int id)
        {
            if (aCourse.CourseID == "" || aCourse.CourseTitles == "" || aCourse.Semister == "" || aCourse.Section == "")
            {
                return false;
            }
            else
            {
                CourseDAL aCourseDAL = new CourseDAL();
                bool res = aCourseDAL.UpdateCourseDAL(aCourse, id);
                return res;
            }
        }
        public bool DeleteBLL(int id)
        {
            if (id == 0 || id < 0)
            {
                return false;
            }
            else
            {
                CourseDAL aCourseDAL = new CourseDAL();
                bool res = aCourseDAL.DeleteDAL(id);
                return res;
            }
        }
    }
}
