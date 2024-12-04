// Models/Route.cs
using System;

namespace RouteManagementAPI.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }

        // Три логических атрибута/измерения
        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
    }
}
