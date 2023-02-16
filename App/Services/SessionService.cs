using App.Models;
using App.Repositories;

namespace App.Services;

public class SessionService : ISessionService
{
    public ISessionRepository SessionRepository { get; }

    public SessionService(ISessionRepository sessionRepository)
    {
        SessionRepository = sessionRepository;
    }

    public void CreateSession()
    {
        var session = GetCurrentSession();
        if (session is null)
        {
            var today = DateTime.Now;
            session = new Session
            {
                StartDate = today,
                EndDate = null
            };
        }

        SessionRepository.CreateSession(session);
    }

    public Session GetCurrentSession()
    {
        return SessionRepository.GetCurrentSession(DateTime.Now);
    }

    public bool BoughtDuringEvent(DateTime date)
    {
        return SessionRepository.GetSessionByDate(DateTime.Now) is not null ? true : false;
    }

    public void EndSession(Session session)
    {
        if (session is null) { return; }

        session.EndDate = DateTime.Now;
        SessionRepository.UpdateSession(session);
    }

    public IList<Session> GetSessions(int year)
    {
        return SessionRepository.GetSessionsFromYear(year);
    }
}