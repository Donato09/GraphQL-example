using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrulliManager.ViewModel
{
    public class CreateTrulloInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int PropertyId { get; set; }
    }
}
