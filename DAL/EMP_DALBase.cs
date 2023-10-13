using FirstProject.Areas.EMP_Department.Models;
using FirstProject.Areas.EMP_Employee.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace FirstProject.DAL
{
    public class EMP_DALBase : DAL_Helper
    {
        #region Employee Regions 

        #region Method: PR_EMP_Employee_SelectAll
        public DataTable PR_EMP_Employee_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_SelectAll");
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

        #region Method: PR_EMP_Employee_SelectByPk
        public DataTable PR_EMP_Employee_SelectByPk(int? EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_SelectByPk");
                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);
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

        #region Method: PR_EMP_Employee_Insert
        public bool? PR_EMP_Employee_Insert(EMP_EmployeeModel modelEMP_Employee)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_Insert");
                sqlDB.AddInParameter(dbCMD, "@EmployeeName", SqlDbType.NVarChar, modelEMP_Employee.EmployeeName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, modelEMP_Employee.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@EmployeeEmail", SqlDbType.NVarChar, modelEMP_Employee.EmployeeEmail);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, modelEMP_Employee.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, modelEMP_Employee.Gender);
                sqlDB.AddInParameter(dbCMD, "@Salary", SqlDbType.NVarChar, modelEMP_Employee.Salary);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.NVarChar, modelEMP_Employee.Address);
                sqlDB.AddOutParameter(dbCMD, "@EmployeeID", SqlDbType.Int, 4);

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                modelEMP_Employee.EmployeeID = Convert.ToInt32(dbCMD.Parameters["@EmployeeID"].Value);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_EMP_Employee_UpdateByPk
        public bool? PR_EMP_Employee_UpdateByPk(EMP_EmployeeModel modelEMP_Employee)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_UpdateByPk");
                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, modelEMP_Employee.EmployeeID);
                sqlDB.AddInParameter(dbCMD, "@EmployeeName", SqlDbType.NVarChar, modelEMP_Employee.EmployeeName);
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, modelEMP_Employee.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@EmployeeEmail", SqlDbType.NVarChar, modelEMP_Employee.EmployeeEmail);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, modelEMP_Employee.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, modelEMP_Employee.Gender);
                sqlDB.AddInParameter(dbCMD, "@Salary", SqlDbType.NVarChar, modelEMP_Employee.Salary);
                sqlDB.AddInParameter(dbCMD, "@Address", SqlDbType.NVarChar, modelEMP_Employee.Address);

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            } 
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_EMP_Employee_DeleteByPk
        public bool? PR_EMP_Employee_DeleteByPk(int EmployeeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Employee_DeleteByPk");
                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, EmployeeID);
                DataTable dt = new DataTable();

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #endregion

        #region Department Regions

        #region Method: PR_EMP_Department_SelectAll
        public DataTable PR_EMP_Department_SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Department_SelectAll");
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

        #region Method: PR_EMP_Department_SelectByPk
        public DataTable PR_EMP_Department_SelectByPk(int? DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Department_SelectByPk");
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
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

        #region Method: PR_EMP_Department_Insert
        public bool? PR_EMP_Department_Insert(EMP_DepartmentModel modelEMP_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Department_Insert");
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.NVarChar, modelEMP_Department.DepartmentName);
                
                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return ( result == -1 ? false : true );
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_EMP_Department_UpdateByPk
        public bool? PR_EMP_Department_UpdateByPk(EMP_DepartmentModel modelEMP_Department)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Department_UpdateByPk");
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, modelEMP_Department.DepartmentID);
                sqlDB.AddInParameter(dbCMD, "@DepartmentName", SqlDbType.NVarChar, modelEMP_Department.DepartmentName);
                DataTable dt = new DataTable();

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region Method: PR_EMP_Department_DeleteByPk
        public bool? PR_EMP_Department_DeleteByPk(int DepartmentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EMP_Department_DeleteByPk");
                sqlDB.AddInParameter(dbCMD, "@DepartmentID", SqlDbType.Int, DepartmentID);
                DataTable dt = new DataTable();

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        #endregion

        #endregion


        #region Method: PR_EWH_EmployeeWiseHobby_Insert
        public bool? PR_EWH_EmployeeWiseHobby_Insert(EMP_EmployeeModel modelEMP_Employee)
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_EWH_EmployeeWiseHobby_Insert");
                sqlDB.AddInParameter(dbCMD, "@EmployeeID", SqlDbType.Int, modelEMP_Employee.EmployeeID);
                sqlDB.AddInParameter(dbCMD, "@HobbyID", SqlDbType.Int, modelEMP_Employee.Hobby.HobbyID);

                int result = sqlDB.ExecuteNonQuery(dbCMD);
                return (result == -1 ? false : true);

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion



        
    }
}
