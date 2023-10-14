using FirstProject.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.Controllers
{
    public class ErrorController : Controller
    {
  
            [Route("Error/{statusCode}")]
            public IActionResult Error(int statusCode)
            {
                var feature = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

                return View(new ErrorViewModel { StatusCode = statusCode, OriginalPath = feature?.OriginalPath });
            }
        
    }
}
