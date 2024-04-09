using TrackMoney.Models;

namespace TrackMoney.Repositories;

internal interface IExpenseTypeRepository : IRepository<ExpenseType>
{
    Task InitDefaultsAsync();
}
