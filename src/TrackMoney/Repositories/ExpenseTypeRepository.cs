using TrackMoney.Models;
using TrackMoney.Services;
using TrackMoney.Utils;

namespace TrackMoney.Repositories;

internal class ExpenseTypeRepository(ISqliteService sqliteService) : Repository<ExpenseType>(sqliteService), IExpenseTypeRepository
{
    public async Task InitDefaultsAsync()
    {
        var types = await GetAsync();

        if (types.NullOrEmpty() || types.NotAny(x=> x.Code == AppConstants.PROCEED_CODE)) 
            await InsertOrUpdateAsync(new ExpenseType() { Code = AppConstants.PROCEED_CODE, Description = "Proceed" });

        if (types.NullOrEmpty() || types.NotAny(x=> x.Code == AppConstants.RAW_MATERIAL_CODE)) 
            await InsertOrUpdateAsync(new ExpenseType() { Code = AppConstants.RAW_MATERIAL_CODE, Description = "RawMaterial" });

        if (types.NullOrEmpty() || types.NotAny(x=> x.Code == AppConstants.ENERGY_UTILITY_CODE)) 
            await InsertOrUpdateAsync(new ExpenseType() { Code = AppConstants.ENERGY_UTILITY_CODE, Description = "EnergyUtility" });

        if (types.NullOrEmpty() || types.NotAny(x=> x.Code == AppConstants.SHOP_RENT_CODE)) 
            await InsertOrUpdateAsync(new ExpenseType() { Code = AppConstants.SHOP_RENT_CODE, Description = "ShopRent" });
        
    }
}
