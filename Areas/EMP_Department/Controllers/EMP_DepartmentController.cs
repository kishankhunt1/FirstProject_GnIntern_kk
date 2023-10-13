﻿using FirstProject.Areas.EMP_Department.Models;
using FirstProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FirstProject.Areas.EMP_Department.Controllers
{
    [Area("EMP_Department")]
    [Route("[controller]/[action]")]
    public class EMP_DepartmentController : Controller
    {
        EMP_DAL dalEMP = new EMP_DAL();

        #region Function: Select All Record
        public IActionResult Index()
        {
            DataTable dt = dalEMP.PR_EMP_Department_SelectAll();
            List<EMP_DepartmentModel> Department = new List<EMP_DepartmentModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EMP_DepartmentModel departmentModel = new EMP_DepartmentModel();
                departmentModel.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                departmentModel.DepartmentName = dr["DepartmentName"].ToString();
                departmentModel.Created = Convert.ToDateTime(dr["Created"]);
                departmentModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Department.Add(departmentModel);
            }
            ViewBag.Department = Department;
            return View("DepartmentList");
        }
        #endregion

        #region Add Record
        public IActionResult Add(int? DepartmentId)
        {
            if (ModelState.IsValid)
            {
                if (DepartmentId != null)
                {
                    //if update the record
                    DataTable dt = dalEMP.PR_EMP_Department_SelectByPk(DepartmentId);

                    EMP_DepartmentModel modelEMP_Department = new EMP_DepartmentModel();
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelEMP_Department.DepartmentID = Convert.ToInt32(dr["DepartmentID"].ToString());
                        modelEMP_Department.DepartmentName = dr["DepartmentName"].ToString();
                    }
                    return View("DepartmentAddEdit", modelEMP_Department);
                }
            }
            return View("DepartmentAddEdit");
        }
        #endregion

        #region Save the record
        [HttpPost]
        public IActionResult Save(EMP_DepartmentModel modelEMP_Department)
        {
            if (ModelState.IsValid)
            {
                if (modelEMP_Department.DepartmentID == null)
                {
                    //if record insert
                    if (Convert.ToBoolean(dalEMP.PR_EMP_Department_Insert(modelEMP_Department)))
                    {
                        TempData["Success"] = "Record Inserted successfully";
                    }
                }
                else
                {
                    //if record update
                    if (Convert.ToBoolean(dalEMP.PR_EMP_Department_UpdateByPk(modelEMP_Department)))
                    {
                        TempData["success"] = "Record Updated successfully.";
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Add");
        }
        #endregion

        #region Delete record
        public IActionResult Delete(int DepartmentID)
        {
            if (Convert.ToBoolean(dalEMP.PR_EMP_Department_DeleteByPk(DepartmentID)))
            {
                TempData["success"] = "Record deleted successfully.";
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Delete Multiple
        [HttpPost]
        public IActionResult DeleteMultiple(int[] Ids)
        {
            string result = string.Empty;
            if (Ids.Count() > 0)
            {
                foreach (int id in Ids)
                {
                    dalEMP.PR_EMP_Department_DeleteByPk(id);
                }
                TempData["success"] = "Record deleted successfully.";
                result = "success";
            }
            return new JsonResult(result);
        }
        #endregion

        #region Search Record
        [HttpPost]
        public IActionResult Search(string DepartmentName)
        {
            DataTable dt = dalEMP.PR_EMP_Department_SearchForName(DepartmentName);

            List<EMP_DepartmentModel> Department = new List<EMP_DepartmentModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EMP_DepartmentModel departmentModel = new EMP_DepartmentModel();
                departmentModel.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
                departmentModel.DepartmentName = dr["DepartmentName"].ToString();
                departmentModel.Created = Convert.ToDateTime(dr["Created"]);
                departmentModel.Modified = Convert.ToDateTime(dr["Modified"]);
                Department.Add(departmentModel);
            }
            ViewBag.Department = Department;

            return View("DepartmentList");
        }
        #endregion

        #region Function: Cancel 
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion
    }
}
