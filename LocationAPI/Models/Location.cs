﻿using LocationsApi.Models;

namespace LocationAPI.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; } 
        public List<TimeSlot> Availability { get; set; } = new();
    }
}