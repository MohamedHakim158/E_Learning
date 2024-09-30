using E_Learning.Areas.Home.Data;
using Microsoft.AspNetCore.Mvc;

namespace E_Learning.Areas.Home.Controllers
{
    public class HomeController : Controller
    {
        ICourseCardService _courseCardService;
        public HomeController(ICourseCardService courseCardService)
        {
            _courseCardService = courseCardService;
        }

        public IActionResult HomeIndex()
        {
            var ccs = _courseCardService.getAll();
            return View("Area_Index", ccs);
        }
    }
}
