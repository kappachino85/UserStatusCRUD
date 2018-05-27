using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UserStatusCRUD.Models.Requests
{
    public class UserAddRequest
    {
        public string UserName { get; set; }

        public string Status { get; set; }

    }
}