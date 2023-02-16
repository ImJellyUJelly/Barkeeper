using App.Models;
using App.Repositories;

namespace App.Services;
public class GeneralOptionsService : IGeneralOptionsService
{
    private IGeneralOptionsRepository GeneralOptionsRepository { get; }

    public GeneralOptionsService(IGeneralOptionsRepository generalOptionsRepository)
    {
        GeneralOptionsRepository = generalOptionsRepository;
    }

    public GeneralOptions GetGeneralOptions()
    {
        return GeneralOptionsRepository.GetGeneralOptions();
    }

    public void UpdateGeneralOptions(int productButtonSize)
    {
        var generalOptions = GetGeneralOptions();
        generalOptions.ProductButtonSize = productButtonSize;
        GeneralOptionsRepository.UpdateGeneralOptions(generalOptions);
    }
}
