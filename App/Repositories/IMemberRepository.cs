using App.Models;

namespace App.Repositories;

public interface IMemberRepository
{
    List<Member> GetAllMembers();
}
