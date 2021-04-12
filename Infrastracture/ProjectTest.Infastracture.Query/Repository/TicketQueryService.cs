using Dapper;
using Microsoft.Extensions.Configuration;
using ProjectTest.CoreDomain.TicketUser.Data;
using ProjectTest.CoreDomain.TicketUser.Dtoes;
using ProjectTest.Infastracture.Query.Repository.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectTest.Infastracture.Query.Repository
{
    public class TicketQueryService : ITicketQueryService
    {
        private readonly string ConnectionString;
        public TicketQueryService(IConfiguration  configuration)
        {
            ConnectionString = configuration.GetConnectionString("TestProject");
        }
        public async Task<List<GetTicketForAdminUserQuery>> GetTicketForAdminUsers()
        {
        


          var query=  ExecuteCommand(ConnectionString, t => t.Query<GetTicketForAdminUserQuery>(QuerySelector.AdminQuery)).ToList();

            return query;
        }

        public async Task<List<GetTicketForUserQuery>> GetTicketForUser()
        {

            var query = ExecuteCommand(ConnectionString, t => t.Query<GetTicketForUserQuery>(QuerySelector.UserQuery, new { IsAdmin = false })).ToList();
            return query;
        }
        private void ExecuteCommand(string connection, Action<SqlConnection> task)
        {
            using (var cnn = new SqlConnection(connection))
            {
                cnn.Open();
                task(cnn);
            }
        }
        private T ExecuteCommand<T>(string connection, Func<SqlConnection, T> task)
        {
            using (var cnn = new SqlConnection(connection))
            {
                cnn.Open();
                return task(cnn);
            }
        }


    }
}
