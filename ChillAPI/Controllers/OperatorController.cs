using DataAccessService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ChillAPI.Controllers
{
    public class OperatorController : Controller
    {
        private readonly DAS _context;

        public OperatorController(DAS context)
        {
            _context = context;
        }
        // GET: OperatorController
        public async Task<ActionResult> Index()
        {
            return View(await _context.GetOperators());
        }

        // GET: OperatorController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var @operator = await _context.GetSpecificOperator(id);

            if (@operator == null)
            {
                return NotFound();
            }

            return View(@operator);
        }
    }
}
