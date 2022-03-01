using App.Models;
using App.Repositories;

namespace App.Services;

public class MemberService : IMemberService
{
    private readonly IMemberRepository _memberRepository;

    public MemberService(IUnitOfWork unitOfWork)
    {
        _memberRepository = unitOfWork.GetMemberRepository();
    }

    public List<Member> GetMembers()
    {
        return _memberRepository.GetAllMembers();
    }
}
