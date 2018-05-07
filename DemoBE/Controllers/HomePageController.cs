using System.Linq;
using DemoBE.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBE.Controllers
{
    [Route("api/[controller]")]
    public class HomePageController : Controller
    {
        private readonly DemoContext _context;

        public HomePageController(DemoContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get(){
            var vm = _context.HomePages.FirstOrDefault(h => h.Id == 1);
            return Json(vm);
        }
    }
}