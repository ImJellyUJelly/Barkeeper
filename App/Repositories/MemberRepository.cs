using App.Contexts;
using App.Models;

namespace App.Repositories;

public class MemberRepository : IMemberRepository
{
    private readonly BarkeeperContext _context;

    public MemberRepository(BarkeeperContext context)
    {
        _context = context;
    }

    public List<Member> GetAllMembers()
    {
        return _context.Members.ToList();
    }
}
