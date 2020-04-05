using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Objects.Models;

namespace Objects.Models.Identity
{
    public class User : IEntityWithId
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        [Required]
        public string UserName
        {
            get;
            set;
        }

        [Required]
        public string Email
        {
            get;
            set;
        }

        [Required]
        public string PasswordHash
        {
            get;
            set;
        }

        public bool IsAdmin
        {
            get;
            set;
        }

        public bool IsDeleted
        {
            get;
            set;
        }
    }
}
