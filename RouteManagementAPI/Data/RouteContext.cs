// Data/RouteContext.cs
using Microsoft.EntityFrameworkCore;
using RouteManagementAPI.Models;

// Создание псевдонима для вашего класса Route
using BusRoute = RouteManagementAPI.Models.Route;

namespace RouteManagementAPI.Data
{
    public class RouteContext : DbContext
    {
        public RouteContext(DbContextOptions<RouteContext> options) : base(options) { }

        public DbSet<BusRoute> Routes { get; set; }
    }
}
