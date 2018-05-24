using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConn.Adapter
{
    public interface IDbAdapter
    {
        object ExecuteDbScalar(IDbCommandDef commandDef);

        IEnumerable<T> LoadObject<T>(IDbCommandDef commandDef) where T : class;

        int ExecuteQuery(IDbCommandDef commandDef);

        IEnumerable<T> LoadObject<T>(IDbCommandDef commandDef, Func<IDataReader, T> mapper) where T : class;
    }
}
