using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStatusCRUD.Domain;
using UserStatusCRUD.Models.Requests;

namespace UserStatusCRUD.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<UserStatus> ReadAll();
        UserStatus ReadById(int Id);
        int Insert(UserAddRequest model);
        void Update(UserUpdateRequest model);
    }
}
