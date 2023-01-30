using App.Contexts;
using App.Models;

namespace App.Repositories;

public class SessionRepository : ISessionRepository
{
    private BarkeeperContext Context { get; }

    public SessionRepository(BarkeeperContext context)
    {
        Context = context;
    }

    public void CreateSession(Session session)
    {
        Context.Sessions.Add(session);
        Context.SaveChanges();
    }

    public Session GetSessionByDate(DateTime date)
    {
        var session = Context.Sessions
            .Where(session => session.EventDate.Year == date.Year)
            .Where(session => session.EventDate.Month == date.Month)
            .Where(session => session.EventDate.Day == date.Day)
            .FirstOrDefault();

        return session ?? new Session { EventDate = DateTime.Now };
    }
}