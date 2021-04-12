using ProjectTest.CoreDomain.UserProfile.Dtoes;
using ProjectTest.CoreDomain.UserProfile.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.CoreDomain.UserProfile.Data
{
    public interface IUserProfileQueryService
    {
        GetUserProfileDetail Query(GetUserProfileQuery query);
        List<GetUserProfileDetail> Query();


    }
}
