using System;
using System.Collections.Generic;
using System.Text;

namespace TrulliManager.Database.Models
{
    public class Trullo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public int PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
