using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrulliManager.ViewModel
{
    public class CreatePropertyInput
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Spa { get; set; }
        public bool SwimmingPool { get; set; }
    }
}
