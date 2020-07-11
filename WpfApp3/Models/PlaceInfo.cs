using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WpfApp3.Models
{
    internal class PlaceInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }

        public IEnumerable<ConfirmedCount> Counts { get; set; }
    }
}
