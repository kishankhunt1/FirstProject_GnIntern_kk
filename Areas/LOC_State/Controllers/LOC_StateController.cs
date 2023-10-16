using FirstProject.Areas.LOC_Country.Models;
using FirstProject.Areas.LOC_State.Models;
using FirstProject.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;

namespace FirstProject.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    [Route("[Controller]/[action]")]
    public class LOC_StateController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region Function: Select All Record
        public IActionResult Index(LOC_StateModel modelLOC_State)
        {
            #region  Country Drop down
            DataTable dt1 = dalLOC.PR_LOC_Country_CountryDropDown();
            List<CountryDropDown> CountryList = new List<CountryDropDown>();
            foreach (DataRow dr in dt1.Rows)
            {
                CountryDropDown vlst = new CountryDropDown();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = dr["CountryName"].ToString();
                CountryList.Add(vlst);
            }
            ViewBag.List = CountryList;
            #endregion


            DataTable dt = dalLOC.PR_LOC_State_SelectAll(modelLOC_State);
            List<LOC_StateModel> State = new List<LOC_StateModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_StateModel StateModel = new LOC_StateModel();
                StateModel.StateID = Convert.ToInt32(dr["StateID"]);
                StateModel.CountryName = dr["CountryName"].ToString();
                StateModel.StateName = dr["StateName"].ToString();
                StateModel.Created = Convert.ToDateTime(dr["Created"]);
                StateModel.Modified = Convert.ToDateTime(dr["Modified"]);
                State.Add(StateModel);
            }
            ViewBag.State = State;
            return View("StateList");
        }
        #endregion

        #region Function: Add Record
        public IActionResult Add(int? StateID)
        {
            if (ModelState.IsValid)
            {
                #region  Country Drop down
                DataTable dt1 = dalLOC.PR_LOC_Country_CountryDropDown();
                List<CountryDropDown> CountryList = new List<CountryDropDown>();
                foreach (DataRow dr in dt1.Rows)
                {
                    CountryDropDown vlst = new CountryDropDown();
                    vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                    vlst.CountryName = dr["CountryName"].ToString();
                    CountryList.Add(vlst);
                }
                ViewBag.List = CountryList;
                #endregion

                if (StateID != null)
                {
                    //if update the record
                    DataTable dt = dalLOC.PR_LOC_State_SelectByPk(StateID);

                    LOC_StateModel modelLOC_State = new LOC_StateModel();

                    foreach (DataRow dr in dt.Rows)
                    {
                        modelLOC_State.StateID = Convert.ToInt32(dr["StateID"].ToString());
                        modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"].ToString());
                        modelLOC_State.StateName = dr["StateName"].ToString();
                    }
                    return View("StateAddEdit", modelLOC_State);
                }
            }
            return View("StateAddEdit");
        }
        #endregion

        #region Function: Save the record
        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {
            if (modelLOC_State.StateID == null)
            {
                //if record insert
                if (Convert.ToBoolean(dalLOC.PR_LOC_State_Insert(modelLOC_State)))
                {
                    TempData["Success"] = "Record Inserted successfully";
                }
            }
            else
            {
                //if record update
                if (Convert.ToBoolean(dalLOC.PR_LOC_State_UpdateByPk(modelLOC_State)))
                {
                    TempData["success"] = "Record Updated successfully.";
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Add");
        }
        #endregion

        #region Function: Delete record
        public IActionResult Delete(int StateID)
        {
            if (Convert.ToBoolean(dalLOC.PR_LOC_State_DeleteByPk(StateID)))
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
                    dalLOC.PR_LOC_State_DeleteByPk(id);
                }
                TempData["success"] = "Record deleted successfully.";
                result = "success";
            }
            return new JsonResult(result);
        }
        #endregion

        #region Function: Clear Search Result
        public IActionResult Clear()
        {
            return RedirectToAction("Index");
        }
        #endregion

        #region Function: Edit Many Records
        public IActionResult EditMany()
        {

            #region  Country Drop down
            DataTable dt1 = dalLOC.PR_LOC_Country_CountryDropDown();
            List<CountryDropDown> CountryList = new List<CountryDropDown>();
            foreach (DataRow dr in dt1.Rows)
            {
                CountryDropDown vlst = new CountryDropDown();
                vlst.CountryID = Convert.ToInt32(dr["CountryID"]);
                vlst.CountryName = dr["CountryName"].ToString();
                CountryList.Add(vlst);
            }
            var countries = new List<SelectListItem>();
            foreach (var country in CountryList)
            {
                countries.Add(new SelectListItem
                {
                    Value = country.CountryName,
                    Text = country.CountryName
                });
            }
            ViewBag.Countries = countries;
            #endregion

            DataTable dt = dalLOC.PR_LOC_State_SelectAllForEditMultiple();
            List<LOC_StateModel> State = new List<LOC_StateModel>();
            foreach (DataRow dr in dt.Rows)
            {
                LOC_StateModel modelLOC_StateModel = new LOC_StateModel();
                modelLOC_StateModel.StateID = Convert.ToInt32(dr["StateID"]);
                modelLOC_StateModel.StateName = dr["StateName"].ToString();
                modelLOC_StateModel.CountryID = Convert.ToInt32(dr["CountryID"]);
                modelLOC_StateModel.CountryName = dr["CountryName"].ToString();
                modelLOC_StateModel.Modified = Convert.ToDateTime(dr["Modified"]);
                State.Add(modelLOC_StateModel);
            }




            return View("StateEditMany", State);
        }
        #endregion

        #region Function: Edit Many Post
        [HttpPost]
        public IActionResult EditManyPost(List<LOC_StateModel> State)
        {
            foreach (var state in State)
            {
                if (state.StateID != null)
                {
                    if (Convert.ToBoolean(dalLOC.PR_LOC_State_UpdateByPk(state)))
                    {
                        TempData["success"] = "Record Updated successfully.";
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
    #endregion

}

