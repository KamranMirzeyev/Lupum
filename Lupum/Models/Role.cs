using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum.Models
{
    public class Role
    {
        public int Id { get; set; }

        [Required]
        public int GroupId { get; set; }

        [Required]
        public int ActionId { get; set; }

        public bool CanView { get; set; }

        public bool CanAdd { get; set; }

        public bool CanEdit { get; set; }

        public bool CanDelete { get; set; }

        public bool OwnerData { get; set; }

        public Action Action { get; set; }

        public Group Group { get; set; }
    }
}