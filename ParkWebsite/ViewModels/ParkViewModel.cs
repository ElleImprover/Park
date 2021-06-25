using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ParkWebsite.Models;

namespace ParkWebsite.ViewModels
{
    public class ParkViewModel
    {
        public Park Park { get; set; }
        public List<Park> Parks{ get; set;}

        public ParkViewModel()
        {
            Parks = new List<Park>();
        }

    }
}
