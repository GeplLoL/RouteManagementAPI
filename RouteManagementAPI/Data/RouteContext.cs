// Data/RouteContext.cs
using Microsoft.EntityFrameworkCore;
using RouteManagementAPI.Models;

using MyRoute = RouteManagementAPI.Models.Route;

namespace RouteManagementAPI.Data
{
    public class RouteContext : DbContext
    {
        public RouteContext(DbContextOptions<RouteContext> options) : base(options) { }

        public DbSet<MyRoute> Routes { get; set; }
    }
}
