using App.Models;

namespace App.Services;

public interface IGeneralOptionsService
{
    GeneralOptions GetGeneralOptions();
    void UpdateGeneralOptions(int productButtonSize);
}
