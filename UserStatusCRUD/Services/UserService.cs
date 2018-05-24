using DatabaseConn.Adapter;
using DatabaseConn.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using UserStatusCRUD.Domain;
using UserStatusCRUD.Models.Requests;
using UserStatusCRUD.Services.Interfaces;

namespace UserStatusCRUD.Services
{
    public class UserService : IUserService
    {
        IBaseService _baseService;

        public UserService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public IEnumerable<UserStatus> ReadAll()
        {
            return _baseService.SqlAdapter.LoadObject<UserStatus>(new DbCommandDef
            {
                DbCommandText = "dbo.TheStatus_SelectAll",
                DbCommandType = System.Data.CommandType.StoredProcedure
            });
        }

        public UserStatus ReadById(int id)
        {
            return _baseService.SqlAdapter.LoadObject<UserStatus>(new DbCommandDef
            {
                DbCommandText = "dbo.TheStatus_SelectById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", id)
                }
            }).FirstOrDefault();
        }

        public int Insert(UserAddRequest model)
        {
            SqlParameter id = SqlDbParameter.Instance.BuildParam("@Id", 0, System.Data.SqlDbType.Int, 0, System.Data.ParameterDirection.Output);
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.TheStatus_Insert",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", model.UserName),
                    new SqlParameter("@UserStatus", model.Status),
                    id
                }
            });
            return id.Value.ToInt32();
        }

        public void Update(UserUpdateRequest model)
        {
            _baseService.SqlAdapter.ExecuteQuery(new DbCommandDef
            {
                DbCommandText = "dbo.TheStatus_UpdateById",
                DbCommandType = System.Data.CommandType.StoredProcedure,
                DbParameters = new SqlParameter[]
                {
                    new SqlParameter("@Id", model.Id),
                    new SqlParameter("@UserStatus", model.Status)
                }
            });
        }
    }
}