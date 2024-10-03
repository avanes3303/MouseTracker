using Microsoft.AspNetCore.Mvc;
using MouseTracker.Models;

namespace MouseTracker.Controllers
{
    public class MouseController : Controller
    {
        private readonly AppDbContext _context;

        public MouseController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveCoordinates([FromBody] List<MouseMovement> movements)
        {
            if (movements == null || !movements.Any())
            {
                return BadRequest();
            }

            _context.MouseMovements.AddRange(movements);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
