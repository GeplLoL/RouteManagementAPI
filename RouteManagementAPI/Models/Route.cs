// Models/Route.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace RouteManagementAPI.Models
{
    public class Route
    {
        public int Id { get; set; }

        [Required]
        public string Source { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        public string Dimension1 { get; set; }
        public string Dimension2 { get; set; }
        public string Dimension3 { get; set; }
    }
}
