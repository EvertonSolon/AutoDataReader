using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Entities.Base;

namespace WebApi.Entities
{
    public class User : BaseEntity
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        public string Password { get; set; }
    }
}
