using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectTest.Infastracture.Query.Repository.Query
{
    public  class QuerySelector
    {
        public static string AdminQuery =>"SELECT dbo.Tickets.Title, " +
                "dbo.Tickets.Description, dbo.userProfiles.FirstName," +
                " dbo.userProfiles.LastName, dbo.userProfiles.Email," +
                " dbo.UserTicket.CreateDate, dbo.UserTicket.ReadStatus " +
                " FROM dbo.userProfiles INNER JOIN " +
                " dbo.UserTicket on  dbo.userProfiles.Id = dbo.UserTicket.SenderUser or dbo.userProfiles.Id = dbo.UserTicket.ReciveUser INNER JOIN "+
                " dbo.Tickets ON dbo.Tickets.Id = dbo.UserTicket.TicketId";
                 

        public static string UserQuery { get; set; } = "SELECT dbo.Tickets.Title, " +
                " dbo.Tickets.Description, dbo.userProfiles.FirstName," +
                " dbo.userProfiles.LastName, dbo.userProfiles.Email," +
                " dbo.UserTicket.CreateDate, dbo.UserTicket.ReadStatus" +
                " FROM dbo.userProfiles INNER JOIN " +
                " dbo.UserTicket on  dbo.userProfiles.Id = dbo.UserTicket.SenderUser or dbo.userProfiles.Id = dbo.UserTicket.ReciveUser INNER JOIN " +
                 " dbo.Tickets ON dbo.Tickets.Id = dbo.UserTicket.TicketId"+
                  " where dbo.userProfiles.IsAdmin=@IsAdmin";
            
    }
}
