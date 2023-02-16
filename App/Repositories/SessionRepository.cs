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

    public Session? GetSessionByDate(DateTime date)
    {
        return Context.Sessions
            .Where(session => session.StartDate.Year <= date.Year && ((DateTime)session.EndDate).Year >= date.Year)
            .Where(session => session.StartDate.Month <= date.Month && ((DateTime)session.EndDate).Month >= date.Month)
            .Where(session => session.StartDate.Day <= date.Day && ((DateTime)session.EndDate).Day >= date.Day)
            .FirstOrDefault();
    }

    public Session? GetCurrentSession(DateTime date)
    {
        return Context.Sessions
            .Where(session => session.StartDate.Year <= date.Year)
            .Where(session => session.StartDate.Month <= date.Month)
            .Where(session => session.StartDate.Day <= date.Day)
            .Where(session => session.EndDate == null)
            .FirstOrDefault();
    }

    public void UpdateSession(Session session)
    {
        var updatedSession = Context.Sessions.FirstOrDefault(s => s.Id == session.Id);
        if (updatedSession is null) return;

        updatedSession.EndDate = session.EndDate;
        Context.SaveChanges();
    }

    public IList<Session> GetSessionsFromYear(int year)
    {
        return Context.Sessions.Where(session => session.StartDate.Year == year).ToList();
    }
}