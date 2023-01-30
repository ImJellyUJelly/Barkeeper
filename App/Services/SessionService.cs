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

    public void CreateSession(bool isEvent)
    {
        var session = GetCurrentSession();
        if (session is null)
        {
            session = new Session
            {
                IsEvent = isEvent,
                EventDate = DateTime.Now
            };
        }

        SessionRepository.CreateSession(session);
    }

    public Session GetCurrentSession()
    {
        return SessionRepository.GetSessionByDate(DateTime.Now);
    }

    public bool BoughtDuringEvent(DateTime date)
    {
        return SessionRepository.GetSessionByDate(DateTime.Now).IsEvent;
    }
}