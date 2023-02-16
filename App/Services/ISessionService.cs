using App.Models;

namespace App.Services;

public interface ISessionService
{
    Session GetCurrentSession();
    void CreateSession();
    void EndSession(Session session);
    bool BoughtDuringEvent(DateTime date);
    IList<Session> GetSessions(int year);
}