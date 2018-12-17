using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum.Models
{
    public class Action
    {
        public int Id { get; set; }

        [StringLength(50), Required]
        public string Name { get; set; }

        public List<Role> Roles { get; set; }
    }
}