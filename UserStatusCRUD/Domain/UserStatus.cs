using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserStatusCRUD.Domain
{
    public class UserStatus
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Status { get; set; }
    }
}