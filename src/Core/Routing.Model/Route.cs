using System;
using System.Collections.Generic;

namespace Routing.Model
{
    public class Route
    {
        public string From { get; set; }
        public string To { get; set; }
        public double Cost { get; set; }

        public override string ToString()
        {
            return string.Join(",", From, To, Cost);
        }
    }
}
