using System;
using System.Collections.Generic;
using System.Text;

namespace AppProjekt.Models
{
    public class Measurement
    {
        public channel Channel { get; set; }
        public IEnumerable<feeds> Feeds { get; set; }
    }
}
