using App.Models;

namespace App.Repositories;

public interface ISessionRepository
{
    void CreateSession(Session session);
    Session GetSessionByDate(DateTime date);
}