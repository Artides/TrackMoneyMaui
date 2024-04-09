using TrackMoney.Models;

namespace TrackMoney.Services;

internal interface IBalanceService
{
    Task<List<ExpenseType>> GetExpenseTypesAsync();
    Task<ExpenseType> GetProceedTypeAsync();
    Task<bool> AddToBalanceAsync(ExpenseType expenseType, double quantity);
    Task<bool> RemoveFromBalanceAsync(BalanceItem balance);

}
