using App.Models;

namespace App.Repositories;

public interface ISessionRepository
{
    void CreateSession(Session session);
    Session? GetSessionByDate(DateTime date);
    Session? GetCurrentSession(DateTime date);
    void UpdateSession(Session session);
    IList<Session> GetSessionsFromYear(int year);
}