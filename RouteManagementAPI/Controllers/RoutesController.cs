// Controllers/RoutesController.cs
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RouteManagementAPI.Data;
using RouteManagementAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

// Создание псевдонимов
using MyRoute = RouteManagementAPI.Models.Route;
using MyRouteContext = RouteManagementAPI.Data.RouteContext;

namespace RouteManagementAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RoutesController : ControllerBase
    {
        private readonly MyRouteContext _context;

        public RoutesController(MyRouteContext context)
        {
            _context = context;

            if (!_context.Routes.Any())
            {
                _context.Routes.Add(new MyRoute
                {
                    Source = "Город А",
                    Destination = "Город Б",
                    DepartureTime = DateTime.Now.AddHours(2),
                    Dimension1 = "Высокая",
                    Dimension2 = "Эконом",
                    Dimension3 = "Ночное"
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Routes
        [HttpGet]
        [Authorize(Roles = "Employee,User")]
        public ActionResult<IEnumerable<MyRoute>> GetRoutes()
        {
            return _context.Routes.ToList();
        }

        // GET: api/Routes/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Employee,User")]
        public ActionResult<MyRoute> GetRoute(int id)
        {
            var route = _context.Routes.Find(id);

            if (route == null)
            {
                return NotFound();
            }

            return route;
        }

        // POST: api/Routes
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public ActionResult<MyRoute> PostRoute(MyRoute route)
        {
            _context.Routes.Add(route);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetRoute), new { id = route.Id }, route);
        }

        // PUT: api/Routes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Employee")]
        public IActionResult PutRoute(int id, MyRoute route)
        {
            if (id != route.Id)
            {
                return BadRequest();
            }

            _context.Entry(route).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Routes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Employee")]
        public IActionResult DeleteRoute(int id)
        {
            var route = _context.Routes.Find(id);
            if (route == null)
            {
                return NotFound();
            }

            _context.Routes.Remove(route);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpGet("Search")]
        public ActionResult<IEnumerable<MyRoute>> SearchRoutes([FromQuery] DateTime departureTime)
        {
            var routes = _context.Routes.Where(r => r.DepartureTime == departureTime).ToList();
            return Ok(routes);
        }
    }
}
