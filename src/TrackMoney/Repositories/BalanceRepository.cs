using TrackMoney.Models;
using TrackMoney.Services;

namespace TrackMoney.Repositories;

internal class BalanceRepository(ISqliteService sqliteService) : Repository<BalanceItem>(sqliteService), IBalanceRepository
{
    
}
