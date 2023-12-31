﻿using FirstProject.Areas.LOC_City.Models;
using FirstProject.Areas.LOC_Country.Models;
using FirstProject.Areas.LOC_State.Models;
using FirstProject.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FirstProject.Areas.LOC_City.Controllers
{
    [Area("LOC_City")]
    [Route("[controller]/[action]")]
    public class LOC_CityController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region Function: Select All Record
        public IActionResult Index(LOC_CityModel modelLOC_City)
        {
            CountryDropDown();

            StateDropDown();

            DataTable dt = dalLOC.PR_LOC_City_SelectAll(modelLOC_City);
            List<LOC_CityModel> City = new List<LOC_CityModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_CityModel CityModel = new LOC_CityModel();
                CityModel.CityID = Convert.ToInt32(dr["CityID"]);
                CityModel.CountryName = dr["CountryName"].ToString();
                CityModel.StateName = dr["StateName"].ToString();
                CityModel.CityName = dr["CityName"].ToString();
                CityModel.Created = Convert.ToDateTime(dr["Created"]);
                CityModel.Modified = Convert.ToDateTime(dr["Modified"]);
                City.Add(CityModel);
            }
            ViewBag.City = City;

            return View("CityList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(int? CityID)
        {
            if (ModelState.IsValid)
            {
                #region  Country Drop down
                DataTable dt1 = dalLOC.PR_LOC_Country_CountryDropDown();
                List<CountryDropDown> CountryList = new List<CountryDropDown>();
                foreach (DataRow dr1 in dt1.Rows)
                {
                    CountryDropDown vlst = new CountryDropDown();
                    vlst.CountryID = Convert.ToInt32(dr1["CountryID"]);
                    vlst.CountryName = dr1["CountryName"].ToString();
                    CountryList.Add(vlst);
                }
                ViewBag.CountryList = CountryList;
                #endregion

                #region State Drop Down By Country

                List<StateDropDown> StateList = new List<StateDropDown>();
                ViewBag.StateList = StateList;

                #endregion


                if (CityID != null)
                {
                    LOC_CityModel modelLOC_City = new LOC_CityModel();

                    //if update the record
                    DataTable dt = dalLOC.PR_LOC_City_SelectByPk(CityID);
                    foreach (DataRow dr in dt.Rows)
                    {
                        modelLOC_City.CityID = Convert.ToInt32(dr["CityID"].ToString());
                        modelLOC_City.CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                        modelLOC_City.StateID = Convert.ToInt32(dr["StateID"].ToString());
                        modelLOC_City.CityName = dr["CityName"].ToString();
                    }

                    //DropDownByCountry(modelLOC_City.CountryID);

                    return View("CityAddEdit", modelLOC_City);
                }
            }
            return View("CityAddEdit");
        }
        #endregion

        #region Function: Save the record
        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            if (modelLOC_City.CityID == null)
            {
                //if record insert
                if (Convert.ToBoolean(dalLOC.PR_LOC_City_Insert(modelLOC_City)))
                {
                    TempData["Success"] = "Record Inserted successfully";
                }
            }
            else
            {
                //if record update
                if (Convert.ToBoolean(dalLOC.PR_LOC_City_UpdateByPk(modelLOC_City)))
                {
                    TempData["success"] = "Record Updated successfully.";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Add");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(int CityID)
        {
            if (Convert.ToBoolean(dalLOC.PR_LOC_City_DeleteByPk(CityID)))
            {
                TempData["success"] = "Record deleted successfully.";
            }
            return RedirectToAction("Index");
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
                    dalLOC.PR_LOC_City_DeleteByPk(id);
                }
                TempData["success"] = "Record deleted successfully.";
                result = "success";
            }
            return new JsonResult(result);
        }
        #endregion

        #region Function: State DropDown by CountryID
        [HttpPost]
        public IActionResult DropDownByCountry(int CountryID)
        {
            DataTable dt = dalLOC.PR_LOC_State_StateDropDownByCountryID(CountryID);
            List<StateDropDown> StateList = new List<StateDropDown>();
            foreach (DataRow dr in dt.Rows)
            {
                StateDropDown modelLOC_State = new StateDropDown();
                modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                modelLOC_State.StateName = dr["StateName"].ToString();
                StateList.Add(modelLOC_State);
            }
            var StateModel = StateList;
            return Json(StateModel);
        }
        #endregion

        #region Function: Country Drop Down
        public void CountryDropDown()
        {
            DataTable dt1 = dalLOC.PR_LOC_Country_CountryDropDown();
            List<CountryDropDown> CountryList = new List<CountryDropDown>();
            foreach (DataRow dr1 in dt1.Rows)
            {
                CountryDropDown vlst = new CountryDropDown();
                vlst.CountryID = Convert.ToInt32(dr1["CountryID"]);
                vlst.CountryName = dr1["CountryName"].ToString();
                CountryList.Add(vlst);
            }
            ViewBag.List = CountryList;
        }
        #endregion

        #region Function: State Drop Down
        public void StateDropDown()
        {
            DataTable dt2 = dalLOC.PR_LOC_State_StateDropDown();
            List<StateDropDown> List1 = new List<StateDropDown>();
            foreach (DataRow dr2 in dt2.Rows)
            {
                StateDropDown vlst2 = new StateDropDown();
                vlst2.StateID = Convert.ToInt32(dr2["StateID"]);
                vlst2.StateName = dr2["StateName"].ToString();
                List1.Add(vlst2);
            }
            ViewBag.StateList = List1;
        }
        #endregion

        #region Funtion: Clear Search Result
        public IActionResult Cancel()
        {
            return RedirectToAction("Index");
        }
        #endregion
    }
}
