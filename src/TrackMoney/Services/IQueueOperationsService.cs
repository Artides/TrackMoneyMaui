using TrackMoney.Operations;

namespace TrackMoney.Services;

internal interface IQueueOperationsService
{
    void Enqueue(IBaseOperation operation);
    Task ExecuteNextOperation();
}
