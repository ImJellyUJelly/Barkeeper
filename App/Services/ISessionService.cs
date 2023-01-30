using App.Models;

namespace App.Services;

public interface ISessionService
{
    Session GetCurrentSession();
    void CreateSession(bool isEvent);
    bool BoughtDuringEvent(DateTime date);
}