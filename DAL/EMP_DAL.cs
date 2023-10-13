using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace FirstProject.DAL
{
    public class EMP_DAL : EMP_DALBase
    {
        #region Method: PR_EMP_Employee_SearchForNameGenderEmail
        public DataTable PR_EMP_Employee_SearchForNameGenderEmail(string EmployeeName, string Gender, string EmployeeEmail)
        {
            SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_SearchForNameGenderEmail");
            sqlDB.AddInParameter(dbCMD, "@EmployeeName", SqlDbType.NVarChar, EmployeeName);
            sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, Gender);
            sqlDB.AddInParameter(dbCMD, "@EmployeeEmail", SqlDbType.NVarChar, EmployeeEmail);
            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }
        #endregion

        #region Method: PR_EMP_Department_SearchForName
        public DataTable PR_EMP_Department_SearchForName(string DepartmentName)
        {
            SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Department_SearchForName");
            sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.NVarChar, DepartmentName);
            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }
        #endregion




        #region Method: PR_EMP_Employee_DepartmentDropDown
        public DataTable PR_EMP_Employee_DepartmentDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_DepartmentDropDown");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_EMP_Hobby_DropDown
        public DataTable PR_EMP_Hobby_DropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Hobby_DropDown");
                DataTable dt = new DataTable();
                using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
