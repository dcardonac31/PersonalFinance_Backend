using PersonalFinance.Common.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonalFinance.Common.Dapper
{
    public interface IDapperHelper
    {
        Task<IEnumerable<T>> ExecuteQuerySelect<T>(string cnx, string query, object filter = null);
        Task<IEnumerable<T>> ExecuteStoreProcedure<T>(string cnx, string storeProcedure, object filter = null) where T : class;
        int ExecuteQueryScalar(string cnx, string query, object filter = null);
        int ExecuteStoreProcedureScalar(string cnx, string storeProcedure, object filter = null);
        Task<QueryMultipleResponse<T>> ExecuteStoreProcedureQueryMultiple<T>(string cnx, string storeProcedure, object filter = null) where T : class;

    }
}
