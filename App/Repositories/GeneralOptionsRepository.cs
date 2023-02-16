using App.Contexts;
using App.Models;

namespace App.Repositories;

public class GeneralOptionsRepository : IGeneralOptionsRepository
{
    private BarkeeperContext Context { get; }

    public GeneralOptionsRepository(BarkeeperContext context)
    {
        Context = context;
    }

    public GeneralOptions GetGeneralOptions()
    {
        var options = Context.GeneralOptions.FirstOrDefault();
        if (options is null)
        {
            return new GeneralOptions() { ProductButtonSize = 85 };
        }

        return options;
    }

    public void UpdateGeneralOptions(GeneralOptions options)
    {
        var generalOptions = Context.GeneralOptions.ToList();
        if (generalOptions is null || generalOptions.Count < 1)
        {
            Context.GeneralOptions.Add(options);
        }
        else
        {
            generalOptions.First().ProductButtonSize = options.ProductButtonSize;
        }

        Context.SaveChanges();
    }
}

