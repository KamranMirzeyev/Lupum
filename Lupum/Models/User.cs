using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lupum.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public bool Status { get; set; }

        [StringLength(50),Required]
        public string Fullname { get; set; }

        [StringLength(50), Required]
        public string Email { get; set; }

        [StringLength(100), Required]
        public string Password { get; set; }

        [Required]
        public int GroupId { get; set; }

        public Group Group { get; set; }
    }
}