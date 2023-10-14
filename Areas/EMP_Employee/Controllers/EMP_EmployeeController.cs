using FirstProject.Areas.EMP_Department.Models;
using FirstProject.Areas.EMP_Employee.Models;
using FirstProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FirstProject.Areas.EMP_Employee.Controllers
{
    [Area("EMP_Employee")]
    [Route("[controller]/[action]")]
    public class EMP_EmployeeController : Controller
    {
        EMP_DAL dalEMP = new EMP_DAL();

        #region Function: Select All Record
        public IActionResult Index()
        {
            DataTable dt = dalEMP.PR_EMP_Employee_SelectAll();
            List<EMP_EmployeeModel> Employee = new List<EMP_EmployeeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EMP_EmployeeModel employeeModel = new EMP_EmployeeModel();
                employeeModel.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                employeeModel.EmployeeName = dr["EmployeeName"].ToString();
                employeeModel.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                employeeModel.DepartmentName = dr["DepartmentName"].ToString();
                employeeModel.EmployeeEmail = dr["EmployeeEmail"].ToString();
                employeeModel.MobileNo = dr["MobileNo"].ToString();
                employeeModel.Gender = dr["Gender"].ToString();
                employeeModel.Salary = dr["Salary"].ToString();
                employeeModel.Address = dr["Address"].ToString();
                employeeModel.Created = Convert.ToDateTime(dr["Created"]);
                employeeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Employee.Add(employeeModel);
            }
            ViewBag.Employee = Employee;
            return View("EmployeeList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(int? EmployeeId)
        {
            if (ModelState.IsValid)
            {
                #region Department DropDown
                DataTable dt1 = dalEMP.PR_EMP_Employee_DepartmentDropDown();
                List<DepartmentDropDown> DepartmentList = new List<DepartmentDropDown>();
                foreach (DataRow dr in dt1.Rows)
                {
                    DepartmentDropDown vlst = new DepartmentDropDown();
                    vlst.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                    vlst.DepartmentName = dr["DepartmentName"].ToString();
                    DepartmentList.Add(vlst);
                }
                ViewBag.List = DepartmentList;
                #endregion

                #region Hobby DropDown
                DataTable dt2 = dalEMP.PR_EMP_Hobby_DropDown();
                List<HobbyDropDown> HobbyList = new List<HobbyDropDown>();
                foreach (DataRow dr2 in dt2.Rows)
                {
                    HobbyDropDown dlst = new HobbyDropDown();
                    dlst.HobbyID = Convert.ToInt32(dr2["HobbyID"]);
                    dlst.HobbyName = dr2["HobbyName"].ToString();
                    HobbyList.Add(dlst);
                }
                ViewBag.HobbyList = HobbyList;
                #endregion

                if (EmployeeId != null)
                {
                    //if update the record
                    DataTable dt = dalEMP.PR_EMP_Employee_SelectByPk(EmployeeId);

                    EMP_EmployeeModel modelEMP_Employee = new EMP_EmployeeModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        modelEMP_Employee.EmployeeID = Convert.ToInt32(dr["EmployeeID"].ToString());
                        modelEMP_Employee.EmployeeName = dr["EmployeeName"].ToString();
                        modelEMP_Employee.DepartmentID = Convert.ToInt32(dr["DepartmentID"].ToString());
                        modelEMP_Employee.EmployeeEmail = dr["EmployeeEmail"].ToString();
                        modelEMP_Employee.MobileNo = dr["MobileNo"].ToString();
                        modelEMP_Employee.Gender = dr["Gender"].ToString();
                        modelEMP_Employee.Salary = dr["Salary"].ToString();
                        modelEMP_Employee.Address = dr["Address"].ToString();
                    }
                    return View("EmployeeAddEdit", modelEMP_Employee);
                }
            }

            return View("EmployeeAddEdit");
        }

        #endregion

        #region Function: Save the record
        [HttpPost]
        public IActionResult Save(EMP_EmployeeModel modelEMP_Employee)
        {
            if (modelEMP_Employee.EmployeeID == null)
            {
                //if record insert
                if (Convert.ToBoolean(dalEMP.PR_EMP_Employee_Insert(modelEMP_Employee)))
                {
                    if (Convert.ToBoolean(dalEMP.PR_EWH_EmployeeWiseHobby_Insert(modelEMP_Employee)))
                    {
                        TempData["Success"] = "Record Inserted successfully";
                    }
                }
            }
            else
            {
                //if record update
                if (Convert.ToBoolean(dalEMP.PR_EMP_Employee_UpdateByPk(modelEMP_Employee)))
                {
                    TempData["Success"] = "Record Updated successfully";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Add");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(int Employeeid)
        {
            if (Convert.ToBoolean(dalEMP.PR_EMP_Employee_DeleteByPk(Employeeid)))
            {
                TempData["success"] = "Record deleted successfully.";
                return RedirectToAction("Index");
            }
            return View("EmployeeList");
        }
        #endregion

        #region Function: Delete Multiple
        [HttpPost]
        public IActionResult DeleteMultiple(int[] Ids)
        {
            string result = string.Empty;
            if (Ids.Count() > 0)
            {
                foreach (int id in Ids)
                {
                    dalEMP.PR_EMP_Employee_DeleteByPk(id);
                }
                TempData["success"] = "Record deleted successfully.";
                result = "success";
            }
            return new JsonResult(result);
        }
        #endregion

        #region Function: Search Record
        [HttpPost]
        public IActionResult Search(string EmployeeName, string Gender, string EmployeeEmail)
        {
            DataTable dt = dalEMP.PR_EMP_Employee_SearchForNameGenderEmail(EmployeeName, Gender, EmployeeEmail);
            List<EMP_EmployeeModel> Employee = new List<EMP_EmployeeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EMP_EmployeeModel employeeModel = new EMP_EmployeeModel();
                employeeModel.EmployeeID = Convert.ToInt32(dr["EmployeeID"]);
                employeeModel.EmployeeName = dr["EmployeeName"].ToString();
                employeeModel.DepartmentName = dr["DepartmentName"].ToString();
                employeeModel.EmployeeEmail = dr["EmployeeEmail"].ToString();
                employeeModel.MobileNo = dr["MobileNo"].ToString();
                employeeModel.Gender = dr["Gender"].ToString();
                employeeModel.Salary = dr["Salary"].ToString();
                employeeModel.Address = dr["Address"].ToString();
                employeeModel.Created = Convert.ToDateTime(dr["Created"]);
                employeeModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Employee.Add(employeeModel);
            }
            ViewBag.Employee = Employee;
            return View("EmployeeList");
        }
        #endregion

        #region Function: Clear Search Result
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion
    }
}

