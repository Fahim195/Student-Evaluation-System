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
    class StudentInformationBLL
    {
        public DataTable LoadComboboxBLL()
        {
            StudentInformatioDAL aStudentInformation = new StudentInformatioDAL();
            DataTable dt = aStudentInformation.LoadComboboxDAL();
            return dt;
        }
        public DataTable ViewStudentInformationBLL(string Details)
        {
            StudentInformatioDAL aStudentInformation = new StudentInformatioDAL();
            DataTable dt = aStudentInformation.ViewStudentInformationDAL(Details);
            return dt;
        }
        public bool SAVEStudentBLL(StudentInformation aStudent, string Details)
        {
            if (aStudent.StudentID == "" || aStudent.name == "" ||Details=="")
            {
                return false;
            }
            else
            {
                StudentInformatioDAL aStudents = new StudentInformatioDAL();
                bool res = aStudents.SAVEStudentDAL(aStudent, Details);
                return res;
            }
        
      }
        public bool UpdateStudentBLL(StudentInformation aStudent, string Details)
        {
            if (aStudent.StudentID == "" || aStudent.name == "" || Details == "")
            {
                return false;
            }
            else
            {
                StudentInformatioDAL aStudents = new StudentInformatioDAL();
                bool res = aStudents.UpdateStudentDAL(aStudent, Details);
                return res;
            }
        }
        public bool DeleteStudentBLL(StudentInformation aStudent, string Details)
        {
            if (aStudent.StudentID == "" || aStudent.name == "" || Details == "")
            {
                return false;
            }
            else
            {
                StudentInformatioDAL aStudents = new StudentInformatioDAL();
                bool res = aStudents.DeleteStudentDAL(aStudent, Details);
                return res;
            }
        }
        public DataTable EvaluationInformationInTextboxBLL(StudentInformation aStudent, string details)
        {
            StudentInformatioDAL aStudentInformation = new StudentInformatioDAL();
            DataTable dt = aStudentInformation.EvaluationInformationInTextboxDAL(aStudent, details);
            return dt;
        }
        public bool SaveEvaluationBLL(StudentInformation aStudent, Course aCourse)
        {
            StudentInformatioDAL aStudents = new StudentInformatioDAL();
            bool res = aStudents.SaveEvaluationDAL(aStudent,aCourse);
            return res;
        }
    }
}
