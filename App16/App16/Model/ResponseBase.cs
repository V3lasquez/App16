using System;
using System.Collections.Generic;
using System.Text;

namespace App16.Model
{
    public class Location
    {
        public string country { get; set; }
        public string city { get; set; }
    }

    public class Place
    {
        public string name { get; set; }
        public double rating { get; set; }
        public Location location { get; set; }
        public string image_url { get; set; }
        public string date { get; set; }
        public double price { get; set; }
        public double longitud { get; set; }
        public double latitud { get; set; }
    }

    public class ResponseBase
    {
        public List<Place> places { get; set; }
    }
}
