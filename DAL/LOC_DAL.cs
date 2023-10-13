using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using System.Data.Common;

namespace FirstProject.DAL
{
    public class LOC_DAL : LOC_DALBase
    {
        #region Method: PR_LOC_Country_CountryDropDown
        public DataTable PR_LOC_Country_CountryDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_CountryDropDown");
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

        #region Method: PR_LOC_State_StateDropDown
        public DataTable PR_LOC_State_StateDropDown()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_StateDropDown");
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

        #region Method: PR_LOC_State_StateDropDownByCountryID
        public DataTable PR_LOC_State_StateDropDownByCountryID(int CountryID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_StateDropDownByCountryID");
                sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);
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


        //#region Method: PR_LOC_State_SelectByCountryNameStateName

        //public DataTable PR_LOC_State_SelectByCountryNameStateName(int CountryID, string StateName)
        //{
        //    SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
        //    DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_State_SelectByCountryNameStateName");
        //    sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);
        //    sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.NVarChar, StateName);
        //    DataTable dt = new DataTable();
        //    using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
        //    {
        //        dt.Load(dr);
        //    }
        //    return dt;
        //}


        //#endregion

        //#region Method: PR_LOC_City_SelectByCountryNameStateNameCityName

        //public DataTable PR_LOC_City_SelectByCountryNameStateNameCityName(int CountryID, int StateID, string CityName)
        //{
        //    SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
        //    DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_City_SelectByCountryNameStateNameCityName");
        //    sqlDB.AddInParameter(dbCMD, "@CountryID", SqlDbType.Int, CountryID);
        //    sqlDB.AddInParameter(dbCMD, "@StateName", SqlDbType.Int, StateID);
        //    sqlDB.AddInParameter(dbCMD, "@CityName", SqlDbType.NVarChar, CityName);
        //    DataTable dt = new DataTable();
        //    using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
        //    {
        //        dt.Load(dr);
        //    }
        //    return dt;
        //}


        //#endregion

        #region Method: PR_LOC_Country_SearchForCountryName

        public DataTable PR_LOC_Country_SearchForCountryName(string CountryName)
        {
            SqlDatabase sqlDB = new SqlDatabase(ConnectionString);
            DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_LOC_Country_SearchForCountryName");
            sqlDB.AddInParameter(dbCMD, "@CountryName", SqlDbType.NVarChar, CountryName);
            DataTable dt = new DataTable();
            using (IDataReader dr = sqlDB.ExecuteReader(dbCMD))
            {
                dt.Load(dr);
            }
            return dt;
        }


        #endregion
    }
}
