using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrulliManager.Database.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public bool Spa { get; set; }
        public bool SwimmingPool { get; set; }
        public ICollection<Trullo> Trulli { get; set; }
    }
}
