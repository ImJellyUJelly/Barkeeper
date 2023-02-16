using App.Models;

namespace App.Repositories;

public interface IGeneralOptionsRepository
{
    GeneralOptions GetGeneralOptions();
    void UpdateGeneralOptions(GeneralOptions generalOptions);
}
