using FirstProject.DAL;
using FirstProject.Models;
using FirstProject.Models.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FirstProject.Controllers
{
    public class HomeController : Controller
    {
        MST_DAL dalMST = new MST_DAL();
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration configuration;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataTable dt1 = dalMST.PR_MST_CountryStateCityEmployeeDashboard();
            DataTable dt2 = dalMST.PR_MST_CityRecentAdd();
            DataTable dt3 = dalMST.PR_MST_EmployeeRecentAdd();
            


            var viewModel = new DataTable_ViewModel
            {
                DataTable1 = dt1,
                DataTable2 = dt2,
                DataTable3 = dt3,
            };

            return View(viewModel);
        }

        public IActionResult Chart()
        {
            DataTable dt = dalMST.PR_EMP_ChartOfDepartmentByEmployee();

            // Convert the DataTable to a list of dictionaries
            var dataList = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                var dataItem = new Dictionary<string, object>();
                foreach (DataColumn column in dt.Columns)
                {
                    dataItem[column.ColumnName] = row[column];
                }
                dataList.Add(dataItem);
            }

            return View(dataList);
        }

        public IActionResult PieChart()
        {
            DataTable dt = dalMST.PR_Employee_Count_SelectAll();

            // Convert the DataTable to a list of dictionaries
            var dataList = new List<Dictionary<string, object>>();
            foreach (DataRow row in dt.Rows)
            {
                var dataItem = new Dictionary<string, object>();
                foreach (DataColumn column in dt.Columns)
                {
                    dataItem[column.ColumnName] = row[column];
                }
                dataList.Add(dataItem);
            }

            return View(dataList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}