using TrackMoney.Models;
using TrackMoney.Repositories;

namespace TrackMoney.Services;

internal class BalanceService(
    IBalanceRepository balanceRepository,
    IExpenseTypeRepository expenseTypeRepository) : IBalanceService
{
    private readonly IBalanceRepository balanceRepository = balanceRepository;
    private readonly IExpenseTypeRepository expenseTypeRepository = expenseTypeRepository;

    public async Task<bool> AddToBalanceAsync(ExpenseType expenseType, double quantity)
    {
        if (expenseType.Code == AppConstants.PROCEED_CODE)
            quantity = Math.Abs(quantity);
        else
            quantity = -1 * Math.Abs(quantity);

        var result = await balanceRepository.InsertOrUpdateAsync(new BalanceItem() { OperationType = expenseType.Code, Amount = quantity });
        return result != null && result.Id > 0;
    }

    public async Task<List<ExpenseType>> GetExpenseTypesAsync()
    {
        var types = await expenseTypeRepository.GetAsync();
        return types?.Where(x => x.Code != AppConstants.PROCEED_CODE).ToList() ?? [];
    }

    public async Task<ExpenseType> GetProceedTypeAsync()
    {
        var types = await expenseTypeRepository.GetAsync();
        return types?.FirstOrDefault(x => x.Code == AppConstants.PROCEED_CODE) ?? new ExpenseType() { Code = AppConstants.PROCEED_CODE };
    }

    public Task<bool> RemoveFromBalanceAsync(BalanceItem balance)
    {
       return balanceRepository.DeleteAsync(balance);
    }
}
