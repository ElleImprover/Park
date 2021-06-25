using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkWebsite.Models
{
    public class Park:IComparable<Park>
    {
        public string ParkId { get; set; }
        public string SanctuaryName { get; set; }
        public string Parkname { get; set; }
        public string Description { get; set; }
        public string Borough { get; set; }
        public string Directions { get; set; }
       // public List<string> HabitatType { get; set; }
        public string HabitatType { get; set; }

        public Decimal Acres { get; set; }


        public int CompareTo(Park park2)
        { 
            if (null == park2)
                return 1;
            return string.Compare(this.Parkname, park2.Parkname);
        }
    }
}
