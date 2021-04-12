//using Dapper;
//using ProjectTest.CoreDomain.UserProfile.Data;
//using ProjectTest.CoreDomain.UserProfile.Dtoes;
//using ProjectTest.CoreDomain.UserProfile.Queries;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;

//namespace ProjectTest.Infastracture.Query.Repository
//{
//    public class UserProfileQueryService : IUserProfileQueryService
//    {
//        private readonly SqlConnection sqlConnection;
//        public UserProfileQueryService(SqlConnection _sqlConnection)
//        {
//            sqlConnection = _sqlConnection;
//        }
//        public GetUserProfileDetail Query(GetUserProfileQuery query)
//        {
//            string queryUser = "SELECT  [Id]"+
//             ",[FirstName]"+
//             ",[LastName]"+
//             ",[Email]"+
//             "FROM[TestProjectDb2].[dbo].[userProfiles]"+
//             "where[Id] = @id";
//            return sqlConnection.QuerySingleOrDefault<GetUserProfileDetail>(queryUser, new {id= query.GetUserProfileId });
//        }

//        public List<GetUserProfileDetail> Query()
//        {
//            string queryUser = "SELECT  [Id]" +
//             ",[FirstName]" +
//             ",[LastName]" +
//             ",[Email]" +
//             "FROM[TestProjectDb2].[dbo].[userProfiles]";
//            return sqlConnection.QuerySingleOrDefault<List<GetUserProfileDetail>>(queryUser).ToList();

//        }
//    }
//}
