using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserStatusCRUD.Models.Requests
{
    public class UserUpdateRequest : UserAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}